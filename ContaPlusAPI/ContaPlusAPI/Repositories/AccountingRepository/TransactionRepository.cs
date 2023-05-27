using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories.AccountingRepository
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly AppDbContext _context;
        private readonly IPaymentStatusVerifier _paymentStatusVerifier;
        public TransactionRepository(AppDbContext context, IPaymentStatusVerifier paymentStatusVerifier)
        {
            _context = context;
            _paymentStatusVerifier = paymentStatusVerifier;
        }

        public async Task AddTransaction(Transaction transaction)
        {
            _context.Transactions.Add(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task<GeneralChartOfAccounts> GetGeneralChartOfAccountsByAccountCode(int accountCode)
        {
            return await _context.GeneralChartOfAccounts.FindAsync(accountCode);
        }

        public async Task<CompanyChartOfAccounts> GetCompanyChartOfAccountsByAccountCode(int accountCode, Guid companyId)
        {
            return await _context.CompanyChartOfAccounts
                .FirstOrDefaultAsync(c => c.AccountCode == accountCode && c.Company.CompanyId == companyId);
        }

        public async Task AddCompanyChartOfAccounts(CompanyChartOfAccounts companyChartOfAccounts, Guid companyId)
        {
            companyChartOfAccounts.Company.CompanyId = companyId;

            await _context.CompanyChartOfAccounts.AddAsync(companyChartOfAccounts);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateTransaction(Transaction updatedTransaction)
        {
            var existingTransaction = await _context.Transactions.FindAsync(updatedTransaction.TransactionId);

            if (existingTransaction != null)
            {
                if (existingTransaction.DocumentNumber != existingTransaction.DocumentNumber)
                    existingTransaction.DocumentNumber = updatedTransaction.DocumentNumber;

                if (existingTransaction.DocumentSeries != updatedTransaction.DocumentSeries)
                    existingTransaction.DocumentSeries = updatedTransaction.DocumentSeries;

                if (existingTransaction.TransactionAmount != updatedTransaction.TransactionAmount)
                    existingTransaction.TransactionAmount = updatedTransaction.TransactionAmount;

                if (existingTransaction.PaidAmount != updatedTransaction.PaidAmount)
                    existingTransaction.PaidAmount = updatedTransaction.PaidAmount;

                if (existingTransaction.RemainingAmount != updatedTransaction.RemainingAmount)
                    existingTransaction.RemainingAmount = updatedTransaction.RemainingAmount;

                if (existingTransaction.TransactionDate != updatedTransaction.TransactionDate)
                    existingTransaction.TransactionDate = updatedTransaction.TransactionDate;

                if (existingTransaction.DueDate != updatedTransaction.DueDate)
                    existingTransaction.DueDate = updatedTransaction.DueDate;

                if (existingTransaction.TransactionType != updatedTransaction.TransactionType)
                    existingTransaction.TransactionType = updatedTransaction.TransactionType;

                if (existingTransaction.PaymentStatus != updatedTransaction.PaymentStatus)
                    existingTransaction.PaymentStatus = updatedTransaction.PaymentStatus;

                if (existingTransaction.Description != updatedTransaction.Description)
                    existingTransaction.Description = updatedTransaction.Description;

                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateCompanyChartOfAccountsBalance(CompanyChartOfAccounts account, Guid companyId)
        {
            var existingAccount = await _context.CompanyChartOfAccounts.FirstOrDefaultAsync(a => a.AccountCode == account.AccountCode && a.Company.CompanyId == companyId);

            existingAccount.CurrentBalance = account.CurrentBalance;
            await _context.SaveChangesAsync();
        }

        public async Task<Transaction> GetTransactionByDocumentNumberAndSeries(string documentNumber, string documentSeries)
        {
            var transaction = await _context.Transactions
               .FirstOrDefaultAsync(t => t.DocumentNumber == documentNumber && t.DocumentSeries == documentSeries);
            return transaction;
        }

        public async Task UpdateTransactionPaidAmountAndStatus(string documentNumber, string documentSeries, decimal paidAmount)
        {
            var transaction = await GetTransactionByDocumentNumberAndSeries(documentNumber, documentSeries);

            if (transaction != null)
            {
                transaction.PaidAmount = paidAmount;
                transaction.PaymentStatus = _paymentStatusVerifier.VerifyPaymentStatus(transaction.TransactionAmount, paidAmount, transaction);

                if (transaction.RemainingAmount == 0)
                {
                    transaction.PaymentStatus = PaymentStatus.Paid;
                }

                if (transaction.DueDate < DateTime.UtcNow && transaction.PaymentStatus != PaymentStatus.Paid)
                {
                    transaction.PaymentStatus = PaymentStatus.Overdue;
                }

                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _context.Transactions
           .Where(t => t.Company.CompanyId == companyId && t.TransactionType == TransactionType.Income)
           .ToListAsync();
        }

        public async Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId)
        {
            return await _context.Transactions
           .Where(t => t.Company.CompanyId == companyId && t.TransactionType == TransactionType.Expense)
           .ToListAsync();
        }

        public async Task DeleteTransaction(int transactionId, Guid companyId)
        {
            var mainTransaction = await _context.Transactions.FindAsync(transactionId);

            if (mainTransaction != null)
            {
                if (mainTransaction.PaymentStatus == PaymentStatus.Partial)
                {
                    var partialPaymentTransactions = _context.Transactions
                        .Where(t => t.PaymentStatus == PaymentStatus.Partial &&
                                    t.DocumentNumber == mainTransaction.DocumentNumber &&
                                    t.DocumentSeries == mainTransaction.DocumentSeries);

                    _context.Transactions.RemoveRange(partialPaymentTransactions);
                }

                var debitAccount = mainTransaction.DebitAccountCode;
                var creditAccount = mainTransaction.CreditAccountCode;
                var transactionAmount = mainTransaction.TransactionAmount;


                _context.Transactions.Remove(mainTransaction);

                await _context.SaveChangesAsync();

                var existingCreditAccountCompany = await GetCompanyChartOfAccountsByAccountCode(creditAccount, companyId);
                var existingDebitAccountCompany = await GetCompanyChartOfAccountsByAccountCode(debitAccount, companyId);

                if (existingCreditAccountCompany != null && existingDebitAccountCompany != null)
                {

                    if (mainTransaction.TransactionType == TransactionType.Income || mainTransaction.TransactionType == TransactionType.Sale || mainTransaction.TransactionType == TransactionType.CustomerReceipt)
                    {
                        existingCreditAccountCompany.CurrentBalance -= transactionAmount;
                        existingDebitAccountCompany.CurrentBalance += transactionAmount;
                        await UpdateCompanyChartOfAccountsBalance(existingCreditAccountCompany, companyId);
                        await UpdateCompanyChartOfAccountsBalance(existingDebitAccountCompany, companyId);
                    }
                    else
                    {
                        existingCreditAccountCompany.CurrentBalance += transactionAmount;
                        existingDebitAccountCompany.CurrentBalance -= transactionAmount;
                        await UpdateCompanyChartOfAccountsBalance(existingCreditAccountCompany, companyId);
                        await UpdateCompanyChartOfAccountsBalance(existingDebitAccountCompany, companyId);
                    }
                }
            }
        }

        public async Task DeletePartialPaymentTransaction(int transactionId, Guid companyId)
        {
            var partialPaymentTransaction = await _context.Transactions.FindAsync(transactionId);

            if (partialPaymentTransaction != null && partialPaymentTransaction.PaymentStatus == PaymentStatus.Partial)
            {
                var debitAccount = partialPaymentTransaction.DebitAccountCode;
                var creditAccount = partialPaymentTransaction.CreditAccountCode;
                var transactionAmount = partialPaymentTransaction.TransactionAmount;
                _context.Transactions.Remove(partialPaymentTransaction);
                await _context.SaveChangesAsync();

                var existingCreditAccountCompany = await GetCompanyChartOfAccountsByAccountCode(creditAccount, companyId);
                var existingDebitAccountCompany = await GetCompanyChartOfAccountsByAccountCode(debitAccount, companyId);

                if (partialPaymentTransaction.TransactionType == TransactionType.Income || partialPaymentTransaction.TransactionType == TransactionType.Sale || partialPaymentTransaction.TransactionType == TransactionType.CustomerReceipt)
                {
                    existingCreditAccountCompany.CurrentBalance -= transactionAmount;
                    existingDebitAccountCompany.CurrentBalance += transactionAmount;
                    await UpdateCompanyChartOfAccountsBalance(existingCreditAccountCompany, companyId);
                    await UpdateCompanyChartOfAccountsBalance(existingDebitAccountCompany, companyId);
                }
                else
                {
                    existingCreditAccountCompany.CurrentBalance += transactionAmount;
                    existingDebitAccountCompany.CurrentBalance -= transactionAmount;
                    await UpdateCompanyChartOfAccountsBalance(existingCreditAccountCompany, companyId);
                    await UpdateCompanyChartOfAccountsBalance(existingDebitAccountCompany, companyId);
                }
            }
        }
    }
}
