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
        private readonly IPaymentStatusVerifier _paymentStatusVerifier;
        private readonly IClientSupplierRepository _clientSupplierRepository;
      

        public TransactionService(ITransactionRepository transactionRepository, IInventoryRepository inventoryRepository, ICompanyRepository companyRepository, IPaymentStatusVerifier paymentStatusVerifier, IClientSupplierRepository clientSupplierRepository)
        {
            _transactionRepository = transactionRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _paymentStatusVerifier = paymentStatusVerifier;
            _clientSupplierRepository = clientSupplierRepository;
        }

        public async Task CreateIncomeTransaction(Transaction model, Guid companyId, int clientId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var client = await _clientSupplierRepository.GetClientById(clientId);

            var existingTransaction = await _transactionRepository.GetTransactionByDocumentNumberAndSeries(model.DocumentNumber, model.DocumentSeries);

            if (existingTransaction != null)
            {
                UpdateExistingTransaction(existingTransaction, model.PaidAmount, model.PaymentStatus, model.TransactionAmount);
                await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
            }

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            if (existingTransaction == null || (existingTransaction != null && existingTransaction.RemainingAmount != 0))
            {
                var transaction = CreateNewIncomeTransaction(existingTransaction, model, debitGeneralAccount, creditGeneralAccount, company, TransactionType.Income, client);


                await _transactionRepository.AddTransaction(transaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }

                company.CashBalance += model.PaidAmount;

                await UpdateDebitAccountBalance(model.DebitAccount, -model.PaidAmount, transaction.TransactionType, company);
                await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, transaction.TransactionType, company);
            }
        }

        public async Task CreateExpenseTransaction(Transaction model, Guid companyId, int supplierId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);

            var supplier = await _clientSupplierRepository.GetSupplierById(supplierId);

            var existingTransaction = await _transactionRepository.GetTransactionByDocumentNumberAndSeries(model.DocumentNumber, model.DocumentSeries);

            if (existingTransaction != null)
            {
                UpdateExistingTransaction(existingTransaction, model.PaidAmount, model.PaymentStatus, model.TransactionAmount);
                await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
            }

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            if (existingTransaction == null || (existingTransaction != null && existingTransaction.RemainingAmount != 0))
            {
                var transaction = CreateNewExpenseTransaction(existingTransaction, model, debitGeneralAccount, creditGeneralAccount, company, TransactionType.Expense, supplier);

                await _transactionRepository.AddTransaction(transaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }

                if (company.CashBalance >= model.PaidAmount)
                {
                    company.CashBalance -= model.PaidAmount;
                    await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, company);
                    await UpdateCreditAccountBalance(model.CreditAccount, -model.PaidAmount, transaction.TransactionType, company);
                }
                else
                    throw new Exception("Insufficient cash balance.");


            }
        }


        private static void UpdateExistingTransaction(Transaction existingTransaction, decimal paidAmount, PaymentStatus paymentStatus, decimal totalAmount)
        {
            existingTransaction.PaidAmount = paidAmount;
            existingTransaction.PaymentStatus = paymentStatus;

            if (existingTransaction.PaymentStatus == PaymentStatus.Paid)
            {
                existingTransaction.RemainingAmount = 0;
            }
            else
            {
                existingTransaction.RemainingAmount = Math.Max(0, totalAmount - paidAmount);
            }
        }

        private Transaction CreateNewIncomeTransaction(Transaction existingTransaction, Transaction model, GeneralChartOfAccounts debitGeneralAccount, GeneralChartOfAccounts creditGeneralAccount, Company company, TransactionType transactionType, Client client)
        {
            bool clientExists = false;

            if (client != null)
                clientExists = true; 

            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = existingTransaction?.TransactionAmount ?? model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = existingTransaction?.DueDate ?? model.DueDate,
                TransactionType = transactionType,
                Description = model.Description,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Company = company,
                Client = clientExists ? client : null
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            if (transaction.PaymentStatus == PaymentStatus.Paid)
            {
                transaction.RemainingAmount = 0;
            }
            else
            {
                transaction.RemainingAmount = Math.Max(0, model.TransactionAmount - model.PaidAmount);
            }

            return transaction;
        }

        private Transaction CreateNewExpenseTransaction(Transaction existingTransaction, Transaction model, GeneralChartOfAccounts debitGeneralAccount, GeneralChartOfAccounts creditGeneralAccount, Company company, TransactionType transactionType, Supplier supplier)
        {
            bool supplierExists = false;

            if (supplier != null)
                supplierExists = true;

            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = existingTransaction?.TransactionAmount ?? model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = existingTransaction?.DueDate ?? model.DueDate,
                TransactionType = transactionType,
                Description = model.Description,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Company = company,
                Supplier = supplierExists ? supplier : null
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            if (transaction.PaymentStatus == PaymentStatus.Paid)
            {
                transaction.RemainingAmount = 0;
            }
            else
            {
                transaction.RemainingAmount = Math.Max(0, model.TransactionAmount - model.PaidAmount);
            }

            return transaction;
        }

        private async Task UpdateCreditAccountBalance(GeneralChartOfAccounts account, decimal amount, TransactionType transactionType, Company company)
        {
            var currentBalance = transactionType == TransactionType.Income || transactionType == TransactionType.Sale || transactionType == TransactionType.CustomerReceipt ? amount : -amount;

            var existingAccountCompany = await _transactionRepository.GetCompanyChartOfAccountsByAccountCode(account.AccountCode, company.CompanyId);
            var existingAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(account.AccountCode);

            if (existingAccountCompany != null)
            {

                existingAccountCompany.CurrentBalance += currentBalance;
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany, company.CompanyId);
            }
            else
            {
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
                existingAccountCompany.CurrentBalance += currentBalance;
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany, company.CompanyId);
            }
            else
            {
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

        private async Task UpdateProductQuantity(int productId, int newQuantity, Guid companyId, Transaction transaction)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var product = await _inventoryRepository.GetProductByIdForCompany(productId, companyId);

            if (product != null)
            {
                if (transaction.TransactionType == TransactionType.Purchase)
                {
                    product.Quantity += newQuantity;
                }
                else if (transaction.TransactionType == TransactionType.Sale)
                {
                    if(product.Quantity < newQuantity)
                    {
                        throw new Exception("Quantity is not available.");
                    }

                    product.Quantity -= newQuantity;

                    var productSale = new ProductSale
                    {
                        Product = product,
                        SoldQuantity = newQuantity,
                        SaleDate = DateTime.UtcNow,
                        Transaction = transaction,
                        Company = company
                    };

                    productSale.TvaFromSellingPrice = productSale.CalculateTvaFromSellingPrice();
                    productSale.TotalPriceWithoutTva = productSale.CalculateTotalPriceWithoutTva();
                    productSale.TotalPriceWithTva = productSale.CalculateTotalPriceWithTva();

                    await _inventoryRepository.AddProductSale(productSale);
                }

                await _inventoryRepository.UpdateProductForCompany(product, company.CompanyId);
            }
            if (product == null && transaction.TransactionType == TransactionType.Purchase)
            {
                var newProduct = new Product
                {
                    ProductName = product.ProductName,
                    Quantity = newQuantity
                };

                await _inventoryRepository.AddProductForCompany(newProduct, company.CompanyId);
            }
        }

        public async Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId)
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
                TransactionDate = DateTime.UtcNow,
                DueDate = model.DueDate,
                TransactionType = TransactionType.Sale,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Client = client,
                Company = company
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            await UpdateDebitAccountBalance(model.DebitAccount, -model.PaidAmount, transaction.TransactionType, company);
            await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, transaction.TransactionType, company);

            await UpdateProductQuantity(model.Product.ProductId, model.Product.Quantity, companyId, transaction);
        }

        public async Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var supplier = await _clientSupplierRepository.GetSupplierByIdForCompany(model.Supplier.SupplierId, company.CompanyId);
            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = model.DueDate,
                TransactionType = TransactionType.Purchase,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Supplier = supplier,
                Company = company
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, model.Company);
            await UpdateCreditAccountBalance(model.CreditAccount, -model.PaidAmount, transaction.TransactionType, model.Company);

            await UpdateProductQuantity(model.Product.ProductId, model.Product.Quantity, model.Company.CompanyId, transaction);
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
    }

    public class PaymentVerifierService : IPaymentStatusVerifier
    {
        public PaymentStatus VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction)
        {
            decimal remainingAmount = totalAmount - paidAmount;
            transaction.RemainingAmount = remainingAmount;

            if (remainingAmount == 0)
                transaction.PaymentStatus = PaymentStatus.Paid;
                //AddInvoiceDocument(transaction);
                //AddReceiptDocument(transaction);

            if(paidAmount == 0)
                transaction.PaymentStatus = PaymentStatus.Unpaid;
                //AddInvoiceDocument(transaction);


            if (paidAmount < totalAmount)
                transaction.PaymentStatus = PaymentStatus.Partial;
                //AddReceiptDocument(transaction);           

            if (transaction.DueDate < DateTime.UtcNow && transaction.PaymentStatus != PaymentStatus.Paid)
            {
                transaction.PaymentStatus = PaymentStatus.Overdue;
            }

            return transaction.PaymentStatus;
        }
    }
}

