using ContaPlusAPI.Context;
using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.EntityFrameworkCore;

namespace ContaPlusAPI.Repositories.AccountingRepository
{
    public class FinancialReportRepository : IFinancialReportRepository
    {   
        private readonly AppDbContext _context;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITransactionRepository _transactionRepository;

        public FinancialReportRepository(AppDbContext context, ICompanyRepository companyRepository, ITransactionRepository transactionRepository)
        {
            _context = context;
            _companyRepository = companyRepository;
            _transactionRepository = transactionRepository;
        }

        public async Task<ProfitLossReportModel> ProfitLossReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            var companyChartOfAccountsIncome = await _context.CompanyChartOfAccounts
                .Include(c => c.GeneralChartOfAccounts)
                .Include(c => c.Company)
                    .ThenInclude(co => co.Transactions.Where(tr => tr.TransactionDate >= startDate && tr.TransactionDate <= endDate))
                .Where(c => c.Company.CompanyId == companyId && c.GeneralChartOfAccounts.AccountNumber == 7)
                .ToListAsync();

            var companyChartOfAccountsExpense = await _context.CompanyChartOfAccounts
                .Include(c => c.GeneralChartOfAccounts)
                .Include(c => c.Company)
                    .ThenInclude(co => co.Transactions.Where(tr => tr.TransactionDate >= startDate && tr.TransactionDate <= endDate))
                .Where(c => c.Company.CompanyId == companyId && c.GeneralChartOfAccounts.AccountNumber == 6)
                .ToListAsync();

            var incomeTransactions = await _context.Transactions
                .Where(tr => tr.TransactionDate >= startDate && tr.TransactionDate <= endDate && (tr.CreditAccount.AccountNumber == 7 || tr.DebitAccount.AccountNumber == 7))
                .ToListAsync();

            var expenseTransactions = await _context.Transactions
              .Where(tr => tr.TransactionDate >= startDate && tr.TransactionDate <= endDate && (tr.CreditAccount.AccountNumber == 6 || tr.DebitAccount.AccountNumber == 6))
              .ToListAsync();

            decimal incomeTotal = 0;
            decimal expenseTotal = 0;

            incomeTotal = incomeTransactions.Sum(tr => tr.TransactionAmount);

            expenseTotal = expenseTransactions.Sum(tr => tr.TransactionAmount);

            decimal profitLoss = incomeTotal - expenseTotal;

            var report = new ProfitLossReportModel
            {
                CompanyChartOfAccountsIncome = incomeTransactions,
                CompanyChartOfAccountsExpense = expenseTransactions,
                IncomeTotal = incomeTotal,
                ExpenseTotal = expenseTotal,
                ProfitLoss = profitLoss
            };

            return report;
        }

        public async Task<ICollection<CompanyChartOfAccounts>> TrialBalanceReport(Guid companyId)
        {
            return await _context.CompanyChartOfAccounts
                .Include(g => g.GeneralChartOfAccounts)
                .Where(c => c.Company.CompanyId == companyId)
                .ToListAsync();
        }

        public async Task<ICollection<Transaction>> JournalEntryReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return await _context.Transactions
                .Include(c => c.Company)
                .Where(t => t.Company.CompanyId == companyId && (t.TransactionDate >= startDate && t.TransactionDate <= endDate))
                .ToListAsync();
        }

    }
}
