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

        public TransactionService(ITransactionRepository transactionRepository, IInventoryRepository inventoryRepository, ICompanyRepository companyRepository, IPaymentStatusVerifier paymentStatusVerifier)
        {
            _transactionRepository = transactionRepository;
            _inventoryRepository = inventoryRepository;
            _companyRepository = companyRepository;
            _paymentStatusVerifier = paymentStatusVerifier;
        }

        public async Task CreateIncomeTransaction(Transaction model, Guid companyId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);

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
                var transaction = CreateNewIncomeExpenseTransaction(existingTransaction, model.TransactionAmount, model.PaidAmount, model.DueDate, debitGeneralAccount, creditGeneralAccount, company, model.DocumentNumber, model.DocumentSeries, TransactionType.Income, model.Description);

                await _transactionRepository.AddTransaction(transaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }

                await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, company);
                await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, transaction.TransactionType, company);
            }
        }

        public async Task CreateExpenseTransaction(Transaction model, Guid companyId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
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
                var transaction = CreateNewIncomeExpenseTransaction(existingTransaction, model.TransactionAmount, model.PaidAmount, model.DueDate, debitGeneralAccount, creditGeneralAccount, company, model.DocumentNumber, model.DocumentSeries, TransactionType.Expense, model.Description);

                await _transactionRepository.AddTransaction(transaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }

                await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, company);
                await UpdateCreditAccountBalance(model.CreditAccount, model.PaidAmount, transaction.TransactionType, company);
            }
        }


        private void UpdateExistingTransaction(Transaction existingTransaction, decimal paidAmount, PaymentStatus paymentStatus, decimal totalAmount)
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

        private Transaction CreateNewIncomeExpenseTransaction(Transaction existingTransaction, decimal totalAmount, decimal paidAmount, DateTime dueDate,
        GeneralChartOfAccounts debitGeneralAccount, GeneralChartOfAccounts creditGeneralAccount, Company company, string documentNumber, string documentSeries, TransactionType transactionType, string description)
        {
            var transaction = new Transaction
            {
                DocumentNumber = documentNumber,
                DocumentSeries = documentSeries,
                TransactionAmount = existingTransaction?.TransactionAmount ?? totalAmount,
                PaidAmount = paidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = existingTransaction?.DueDate ?? dueDate,
                TransactionType = transactionType,
                Description = description,
                DebitAccount = debitGeneralAccount,
                CreditAccount = creditGeneralAccount,
                Company = company
            };

            _paymentStatusVerifier.VerifyPaymentStatus(totalAmount, paidAmount, transaction);

            if (transaction.PaymentStatus == PaymentStatus.Paid)
            {
                transaction.RemainingAmount = 0;
            }
            else
            {
                transaction.RemainingAmount = Math.Max(0, totalAmount - paidAmount);
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
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany);
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
                await _transactionRepository.UpdateCompanyChartOfAccountsBalance(existingAccountCompany);
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

        private async Task UpdateProductQuantity(string productName, int quantity, Guid companyId, TransactionType transactionType)
        {
            var product = await _inventoryRepository.GetProductByNameForCompany(productName, companyId);

            if (product != null)
            {
                if (transactionType == TransactionType.Purchase)
                {
                    product.Quantity += quantity;
                }
                else if (transactionType == TransactionType.Sale)
                {
                    product.Quantity -= quantity;
                }

                await _inventoryRepository.UpdateProductForCompany(product, companyId);
            }
            if (product == null && transactionType == TransactionType.Purchase)
            {
                var newProduct = new Product
                {
                    ProductName = productName,
                    Quantity = quantity
                };

                await _inventoryRepository.AddProductForCompany(newProduct, companyId);
            }
        }

        public async Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId)
        {
            var client = await _clientSupplierRepository.GetClientByIdForCompany(model.Client.ClientId, companyId);
            var transaction = new Transaction
            {
                DocumentNumber = model.DocumentNumber,
                DocumentSeries = model.DocumentSeries,
                TransactionAmount = model.TransactionAmount,
                PaidAmount = model.PaidAmount,
                TransactionDate = DateTime.UtcNow,
                DueDate = model.DueDate,
                TransactionType = TransactionType.Sale,
                DebitAccount = model.DebitAccount,
                CreditAccount = model.CreditAccount,
                Client = client,
                Company = model.Company
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, model.Company);
            await UpdateCreditAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, model.Company);

            await UpdateProductQuantity(model.Product.ProductName, model.Product.Quantity, model.Company.CompanyId, transaction.TransactionType);
        }

        public async Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId)
        {
            var supplier = await _clientSupplierRepository.GetSupplierByIdForCompany(model.Supplier.SupplierId, companyId);
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
                Company = model.Company
            };

            _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, transaction);

            await _transactionRepository.AddTransaction(transaction);

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, model.Company);
            await UpdateCreditAccountBalance(model.DebitAccount, model.PaidAmount, transaction.TransactionType, model.Company);

            await UpdateProductQuantity(model.Product.ProductName, model.Product.Quantity, model.Company.CompanyId, transaction.TransactionType);
        }

        public async Task CreateSupplierPaymentTransaction(Transaction model, Guid companyId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
            var existingTransaction = await _transactionRepository.GetTransactionByDocumentNumberAndSeries(model.DocumentNumber, model.DocumentSeries);

            if (existingTransaction != null)
            {
                UpdateExistingTransaction(existingTransaction, model.PaidAmount,model.PaymentStatus, model.TransactionAmount);
                await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
            }

            var debitGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.DebitAccount.AccountCode);
            var creditGeneralAccount = await _transactionRepository.GetGeneralChartOfAccountsByAccountCode(model.CreditAccount.AccountCode);

            if (existingTransaction == null || (existingTransaction != null && existingTransaction.RemainingAmount != 0))
            {
                existingTransaction = new Transaction
                {
                    DocumentNumber = model.DocumentNumber,
                    DocumentSeries = model.DocumentSeries,
                    TransactionAmount = existingTransaction?.TransactionAmount ?? model.TransactionAmount,
                    PaidAmount = model.PaidAmount,
                    TransactionDate = DateTime.UtcNow,
                    DueDate = existingTransaction?.DueDate ?? model.DueDate,
                    TransactionType = TransactionType.SupplierPayment,
                    DebitAccount = debitGeneralAccount,
                    CreditAccount = creditGeneralAccount,
                    Supplier = model.Supplier,
                    Company = company
                };

                _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, existingTransaction);

                await _transactionRepository.AddTransaction(existingTransaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }
            }

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, existingTransaction.TransactionType, company);
            await UpdateCreditAccountBalance(model.DebitAccount, model.PaidAmount, existingTransaction.TransactionType, company);
        }

        public async Task CreateCustomerReceiptTransaction(Transaction model, Guid companyId)
        {
            var company = await _companyRepository.GetCompanyById(companyId);
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
                existingTransaction = new Transaction
                {
                    DocumentNumber = model.DocumentNumber,
                    DocumentSeries = model.DocumentSeries,
                    TransactionAmount = existingTransaction?.TransactionAmount ?? model.TransactionAmount,
                    PaidAmount = model.PaidAmount,
                    TransactionDate = DateTime.UtcNow,
                    DueDate = existingTransaction?.DueDate ?? model.DueDate,
                    TransactionType = TransactionType.CustomerReceipt,
                    DebitAccount = debitGeneralAccount,
                    CreditAccount = creditGeneralAccount,
                    Client = model.Client,
                    Company = company
                };

                _paymentStatusVerifier.VerifyPaymentStatus(model.TransactionAmount, model.PaidAmount, existingTransaction);

                await _transactionRepository.AddTransaction(existingTransaction);

                if (model.PaymentStatus != PaymentStatus.Paid)
                {
                    await _transactionRepository.UpdateTransactionPaidAmountAndStatus(model.DocumentNumber, model.DocumentSeries, model.PaidAmount);
                }
            }

            await UpdateDebitAccountBalance(model.DebitAccount, model.PaidAmount, existingTransaction.TransactionType, company);
            await UpdateCreditAccountBalance(model.DebitAccount, model.PaidAmount, existingTransaction.TransactionType, company);
        }

        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _transactionRepository.GetIncomeTransactions(companyId);
        }
    }

    public class PaymentVerifierService : IPaymentStatusVerifier
    {
        public PaymentStatus VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction)
        {
            decimal remainingAmount = totalAmount - paidAmount;
            transaction.RemainingAmount = remainingAmount;

            if (remainingAmount == 0)
            {
                transaction.PaymentStatus = PaymentStatus.Paid;
            }

            if (transaction.DueDate < DateTime.UtcNow && transaction.PaymentStatus != PaymentStatus.Paid)
            {
                transaction.PaymentStatus = PaymentStatus.Overdue;
            }

            if (paidAmount != totalAmount)
            {
                transaction.PaymentStatus = PaymentStatus.Partial;

                if (paidAmount == 0)
                {
                    transaction.PaymentStatus = PaymentStatus.Unpaid;
                }
            }

            return transaction.PaymentStatus;
        }
    }
}

