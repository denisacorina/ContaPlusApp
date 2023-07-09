using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Services.AccountingService;
using Microsoft.AspNetCore.Mvc;

namespace ContaPlusAPI.Controllers
{
    public class FinancialReportsController : BaseApiController
    {
        private readonly IFinancialReportService _financialReportService;

        public FinancialReportsController (IFinancialReportService financialReportService)
        {
            _financialReportService = financialReportService;
        }

        [HttpGet("getProfitLossReport")]
        public async Task<ProfitLossReportModel> ProfitLossReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return await _financialReportService.ProfitLossReport(companyId, startDate, endDate);
        }

        [HttpGet("getTrialBalanceReport")]
        public async Task<ICollection<CompanyChartOfAccounts>> TrialBalanceReport(Guid companyId)
        {
            return await _financialReportService.TrialBalanceReport(companyId);
        }

        [HttpGet("getJournalEntryReport")]
        public async Task<ICollection<Transaction>> JournalEntryReport(Guid companyId, DateTime startDate, DateTime endDate)
        {
            return await _financialReportService.JournalEntryReport(companyId, startDate, endDate);
        }
    }
}
