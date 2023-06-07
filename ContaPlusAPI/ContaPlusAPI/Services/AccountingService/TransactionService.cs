using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IRepository.InventoryRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Services.AccountingService
{
    public class TransactionService : ITransactionService
    {
        private readonly ITransactionRepository _transactionRepository;
        private readonly IInventoryRepository _inventoryRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly IClientSupplierRepository _clientSupplierRepository;
        private readonly IDocumentRepository _documentRepository;
        private readonly ILogger<Transaction> _logger;


        public TransactionService(ITransactionRepository transactionRepository, IInventoryRepository inventoryRepository, ICompanyRepository companyRepository, IClientSupplierRepository clientSupplierRepository, IDocumentRepository documentRepository, ILogger<Transaction> logger)
        {
            _transactionRepository = transactionRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _clientSupplierRepository = clientSupplierRepository;
            _documentRepository = documentRepository;
            _logger = logger;
        }

        public async Task CreateIncomeTransaction(Transaction model, Guid companyId, int clientId)
        {
            _logger.LogInformation("Start creating income transaction.");

            var company = await _companyRepository.GetCompanyById(companyId);
            var client = await _clientSupplierRepository.GetClientById(clientId);

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            _logger.LogInformation("Create transaction.");
            var transaction = await CreateNewIncomeTransaction(model, debitGeneralAccount, creditGeneralAccount, company, TransactionType.Income, client);

            if (transaction.PaidAmount == 0)
                transaction.PaymentStatus = PaymentStatus.Unpaid;

            await _transactionRepository.AddTransaction(transaction);


            if (transaction.TransactionType == TransactionType.Income)
            {
                _logger.LogInformation("Create invoice document for Income.");
                var invoice = new Document
                {
                    DocumentType = DocumentType.Invoice,
                    DocumentDate = DateTime.UtcNow,
                    Transaction = transaction

                };

                await _documentRepository.CreateInvoice(invoice);
            }

            if (client != null)
            {

                if (transaction.PaidAmount != 0 || transaction.PaidAmount <= transaction.TransactionAmount)
                {
                    _logger.LogInformation("Create receipt document.");
                    var receipt = new Document
                    {
                        DocumentType = DocumentType.CustomerReceipt,
                        DocumentDate = DateTime.UtcNow,
                        Transaction = transaction
                    };

                    await _documentRepository.CreateReceipt(receipt);
                }
            }

            _logger.LogInformation("Updating the cash balance of the company.");
            company.CashBalance += model.PaidAmount;

            _logger.LogInformation("Updating the debit and credit account.");
            await UpdateDebitAccountBalance(model.DebitAccount, -model.PaidAmount, model.TransactionType, company);
            await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, model.TransactionType, company);
        }

        public async Task CreateExpenseTransaction(Transaction model, Guid companyId, int supplierId)
        {
            _logger.LogInformation("Start creating expense transaction.");
            var company = await _companyRepository.GetCompanyById(companyId);

            var supplier = await _clientSupplierRepository.GetSupplierById(supplierId);

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            var transaction = await CreateNewExpenseTransaction(model, debitGeneralAccount, creditGeneralAccount, company, TransactionType.Expense, supplier);

            await _transactionRepository.AddTransaction(transaction);

            if (company.CashBalance >= model.PaidAmount)
            {
                company.CashBalance -= model.PaidAmount;

                _logger.LogInformation("Updating the cash balance of the company.");
                await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, model.TransactionType, company);
                await UpdateCreditAccountBalance(model.CreditAccount, -model.PaidAmount, model.TransactionType, company);
            }
            else
                throw new Exception("Insufficient cash balance.");
                _logger.LogWarning("Insufficient cash balance.");
        }

        private async Task<Transaction> CreateNewIncomeTransaction(Transaction model, GeneralChartOfAccounts debitGeneralAccount, GeneralChartOfAccounts creditGeneralAccount, Company company, TransactionType transactionType, Client client)
        {
            bool clientExists = false;

            if (client != null)
                clientExists = true;

            _logger.LogInformation("Create new income transaction.");
            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = model.TransactionDate,
                DueDate = model.DueDate,
                TransactionType = transactionType,
                Description = model.Description,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Company = company,
                Client = clientExists ? client : null
            };
            _logger.LogInformation($"New income transaction created {transaction}.");

            await VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            return transaction;
        }

        private async Task<Transaction> CreateNewExpenseTransaction(Transaction model, GeneralChartOfAccounts debitGeneralAccount, GeneralChartOfAccounts creditGeneralAccount, Company company, TransactionType transactionType, Supplier supplier)
        {
            bool supplierExists = false;

            if (supplier != null)
                supplierExists = true;

            _logger.LogInformation("Create new expense transaction.");
            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = model.DueDate,
                TransactionType = transactionType,
                Description = model.Description,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Company = company,
                Supplier = supplierExists ? supplier : null
            };
            _logger.LogInformation($"New expense transaction created {transaction}.");

            await VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            return transaction;
        }

        private async Task UpdateCreditAccountBalance(GeneralChartOfAccounts account, decimal amount, TransactionType transactionType, Company company)
        {
            var currentBalance = transactionType == TransactionType.Income || transactionType == TransactionType.Sale || transactionType == TransactionType.CustomerReceipt ? amount : -amount;

            var existingAccountCompany = await _transactionRepository.GetCompanyChartOfAccountsByAccountCode(account.AccountCode, company.CompanyId);
            var existingAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(account.AccountCode);

            if (existingAccountCompany != null)
            {
                _logger.LogInformation("Updating company current balance.");
                existingAccountCompany.CurrentBalance += currentBalance;

                _logger.LogInformation("Updating company chart of accounts balance.");
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany, company.CompanyId);
            }
            else
            {
                _logger.LogInformation("Adding new chart of accounts code in company chart of accounts.");
                var newAccountCompany = new CompanyChartOfAccounts
                {
                    AccountCode = account.AccountCode,
                    CurrentBalance = currentBalance,
                    Company = company,
                    LastUpdatedDate = DateTime.UtcNow,
                    GeneralChartOfAccounts = existingAccount
                };
                await _transactionRepository.AddCompanyChartOfAccounts(newAccountCompany, company.CompanyId);
            }
        }

        private async Task UpdateDebitAccountBalance(GeneralChartOfAccounts account, decimal amount, TransactionType transactionType, Company company)
        {
            var currentBalance = transactionType == TransactionType.Income || transactionType == TransactionType.Sale || transactionType == TransactionType.CustomerReceipt ? -amount : amount;

            var existingAccountCompany = await _transactionRepository.GetCompanyChartOfAccountsByAccountCode(account.AccountCode, company.CompanyId);
            var existingAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(account.AccountCode);

            if (existingAccountCompany != null)
            {
                _logger.LogInformation("Updating company current balance.");
                existingAccountCompany.CurrentBalance += currentBalance;

                _logger.LogInformation("Updating company chart of accounts balance.");
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany, company.CompanyId);
            }
            else
            {
                _logger.LogInformation("Adding new chart of accounts code in company chart of accounts.");
                var newAccountCompany = new CompanyChartOfAccounts
                {
                    AccountCode = account.AccountCode,
                    CurrentBalance = -currentBalance,
                    Company = company,
                    LastUpdatedDate = DateTime.UtcNow,
                    GeneralChartOfAccounts = existingAccount
                };
                await _transactionRepository.AddCompanyChartOfAccounts(newAccountCompany, company.CompanyId);
            }
        }

        private async Task UpdateProductQuantity(int productId, int? newQuantity, Guid companyId, Transaction transaction)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var product = await _inventoryRepository.GetProductByIdForCompany(productId, companyId);

            if (product != null)
            {
                if (transaction.TransactionType == TransactionType.Purchase)
                {
                    if (newQuantity.HasValue)
                        product.Quantity += newQuantity.Value;
                }
                else if (transaction.TransactionType == TransactionType.Sale)
                {
                    if (newQuantity.HasValue)
                    {
                        _logger.LogInformation("Checking quantity.");
                        if (product.Quantity < newQuantity.Value)
                        {
                            throw new Exception("Quantity is not available.");
                        }
                        if (!product.IsService)
                            product.Quantity -= newQuantity.Value;

                        _logger.LogInformation("Creating product sale.");
                        var productSale = new ProductSale
                        {
                            Product = product,
                            SoldQuantity = newQuantity.Value,
                            SaleDate = DateTime.UtcNow,
                            Transaction = transaction,
                            Company = company
                        };

                        if (productSale.Company.TvaPayer)
                            productSale.TvaFromSellingPrice = productSale.CalculateTvaFromSellingPrice();

                        productSale.TotalPriceWithoutTva = productSale.CalculateTotalPriceWithoutTva();

                        if(productSale.Company.TvaPayer)
                            productSale.TotalPriceWithTva = productSale.CalculateTotalPriceWithTva();

                        await _inventoryRepository.AddProductSale(productSale);
                    }
                    else
                    {
                        if (product.Quantity == null)
                        {
                            _logger.LogInformation("Creating product sale.");
                            var productSale = new ProductSale
                            {
                                Product = product,
                                SoldQuantity = 1,
                                TotalPriceWithoutTva = product.Price,
                                SaleDate = DateTime.UtcNow,
                                Transaction = transaction,
                                Company = company
                            };


                            if (productSale.Company.TvaPayer)
                                productSale.TvaFromSellingPrice = productSale.CalculateTvaFromSellingPrice();

                            if (productSale.Company.TvaPayer)
                                productSale.TotalPriceWithTva = productSale.CalculateTotalPriceWithTva();

                            await _inventoryRepository.AddProductSale(productSale);
                        }
                    }
                }

                _logger.LogInformation("Updating the product.");
                await _inventoryRepository.UpdateProductForCompany(product, company.CompanyId);
            }
            else if (transaction.TransactionType == TransactionType.Purchase)
            {
                throw new Exception("This type of transaction cannot be done here.");
            }
        }

        public async Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId, List<Product> productSaleItems)
        {
            var company = await _companyRepository.GetCompanyById(companyId);

            var client = await _clientSupplierRepository.GetClientByIdForCompany(model.Client.ClientId, company.CompanyId);

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = model.TransactionDate,
                DueDate = model.DueDate,
                TransactionType = TransactionType.Sale,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Description = model.Description,
                Client = client,
                Company = company
            };

            await VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            if (transaction.TransactionType == TransactionType.Sale)
            {
                var invoice = new Document
                {
                    DocumentType = DocumentType.Invoice,
                    DocumentDate = DateTime.UtcNow,
                    Transaction = transaction
                };

                await _documentRepository.CreateInvoice(invoice);

                if (transaction.PaidAmount != 0)
                {
                    var receipt = new Document
                    {
                        DocumentType = DocumentType.CustomerReceipt,
                        DocumentDate = DateTime.UtcNow,
                        Transaction = transaction
                    };

                    await _documentRepository.CreateReceipt(receipt);
                }
            }

            await UpdateDebitAccountBalance(model.DebitAccount, -model.PaidAmount, transaction.TransactionType, company);
            await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, transaction.TransactionType, company);

            foreach (var product in productSaleItems)
            {
                 await UpdateProductQuantity(product.ProductId, product.Quantity, companyId, transaction);
            }
        }

        public async Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId, List<Product> productPurchaseItems)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var supplier = await _clientSupplierRepository.GetSupplierByIdForCompany(model.Supplier.SupplierId, company.CompanyId);

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);


            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = model.TransactionDate,
                DueDate = model.DueDate,
                TransactionType = TransactionType.Purchase,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Supplier = supplier,
                Company = company
            };

            await VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, company);
            await UpdateCreditAccountBalance(model.CreditAccount, -model.PaidAmount, transaction.TransactionType, company);

            foreach (var product in productPurchaseItems)
            {
                var chartOfAccountsCode = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(product.ChartOfAccountsCode.AccountCode);

                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Quantity = product.Quantity,
                    Price = product.Price,
                    Company = company,
                    CreatedAt = DateTime.UtcNow,
                    IsService = false,
                    ChartOfAccountsCode = chartOfAccountsCode,
                    Description = product.Description
                };

                await _inventoryRepository.AddProductForCompany(newProduct, company.CompanyId);
            }

            var goodsReceivedNote = new Document
            {
                DocumentType = DocumentType.GoodsReceivedNote,
                DocumentDate = DateTime.UtcNow,
                Transaction = transaction
            };

            await _documentRepository.CreateGoodsReceiptNote(goodsReceivedNote);
        }

        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _transactionRepository.GetIncomeTransactions(companyId);
        }

        public async Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId)
        {
            return await _transactionRepository.GetExpenseTransactions(companyId);
        }

        public Task UpdateTransaction(Transaction transaction)
        {
            return _transactionRepository.UpdateTransaction(transaction);
        }

        public Task DeleteTransaction(int transactionId, Guid companyId)
        {
            return _transactionRepository.DeleteTransaction(transactionId, companyId);
        }

        public Task DeletePartialPaymentTransaction(int transactionId, Guid companyId)
        {
            return _transactionRepository.DeletePartialPaymentTransaction(transactionId, companyId);
        }

        public async Task PayExistingTransaction(int transactionId, decimal amount)
        {
            var transaction = await _transactionRepository.GetTransactionById(transactionId);

            var newPaidAmount = transaction.PaidAmount += amount;

            await VerifyPaymentStatus(transaction.TransactionAmount, newPaidAmount, transaction);

            if (transaction.TransactionType == TransactionType.Income && (transaction.PaymentStatus == PaymentStatus.Paid || transaction.PaymentStatus == PaymentStatus.Partial))
            {
                var receipt = new Document
                {
                    DocumentType = DocumentType.CustomerReceipt,
                    DocumentDate = DateTime.UtcNow,
                    Transaction = transaction
                };

                await _documentRepository.CreateReceipt(receipt);
            }

            await _transactionRepository.UpdateTransaction(transaction);
        }

        public async Task<PaymentStatus> VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction)
        {
            if (paidAmount > transaction.TransactionAmount)
                throw new Exception($"The paid amount is bigger than the total amount of {transaction.TransactionAmount}");

            decimal remainingAmount = totalAmount - paidAmount;
            transaction.RemainingAmount = remainingAmount;

            if (transaction.PaidAmount == transaction.TransactionAmount)
                transaction.RemainingAmount = 0;

            if (remainingAmount == 0)
                transaction.PaymentStatus = PaymentStatus.Paid;

            if (paidAmount == 0)
                transaction.PaymentStatus = PaymentStatus.Unpaid;

            if (paidAmount < totalAmount)
                transaction.PaymentStatus = PaymentStatus.Partial;

            if (transaction.DueDate < DateTime.UtcNow && transaction.PaymentStatus != PaymentStatus.Paid)
            {
                transaction.PaymentStatus = PaymentStatus.Overdue;
            }

            await _transactionRepository.UpdateTransaction(transaction);
            return transaction.PaymentStatus;
        }

        public async Task<ICollection<Transaction>> GetClientUnpaidTransactions(int clientId)
        {
            return await _transactionRepository.GetClientUnpaidTransactions(clientId);
        }
        
        public async Task<ICollection<Transaction>> GetSupplierUnpaidTransactions(int supplierId)
        {
            return await _transactionRepository.GetSupplierUnpaidTransactions(supplierId);
        }
    }
}

