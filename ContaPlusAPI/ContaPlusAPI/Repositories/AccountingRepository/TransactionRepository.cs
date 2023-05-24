using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.EntityFrameworkCore;

using EntityState = Microsoft.EntityFrameworkCore.EntityState;

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

        public async Task UpdateTransaction(Transaction transaction)
        {
            _context.Transactions.Update(transaction);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateCompanyChartOfAccountsBalance(CompanyChartOfAccounts account)
        {
            var existingAccount = await _context.CompanyChartOfAccounts.FirstOrDefaultAsync(a => a.AccountCode == account.AccountCode && a.Company.CompanyId == account.Company.CompanyId);

            if (existingAccount != null)
            {
                existingAccount.CurrentBalance = account.CurrentBalance;
                await _context.SaveChangesAsync();
            }
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

                await _context.SaveChangesAsync();
            }
        }

        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _context.Transactions
           .Where(t => t.Company.CompanyId == companyId && t.TransactionType == TransactionType.Income)
           .ToListAsync();
        }
    }
}
