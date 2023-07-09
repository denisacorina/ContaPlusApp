using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Services.AccountingService
{
    public class FinancialReportService : IFinancialReportService
    {
        private readonly IFinancialReportRepository _financialReportRepository;

        public FinancialReportService(IFinancialReportRepository financialReportRepository)
        {
            _financialReportRepository = financialReportRepository;
        }

        public async Task<ProfitLossReportModel> ProfitLossReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return await _financialReportRepository.ProfitLossReport(companyId, startDate, endDate);
        }

        public async Task<ICollection<CompanyChartOfAccounts>> TrialBalanceReport(Guid companyId)
        {
            return await _financialReportRepository.TrialBalanceReport(companyId);
        }

        public async Task<ICollection<Transaction>> JournalEntryReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return await _financialReportRepository.JournalEntryReport(companyId, startDate, endDate);
        }
    }
}
