using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface
{
    public interface IFinancialReportRepository
    {
        Task<ICollection<Transaction>> JournalEntryReport(Guid companyId, DateTime startDate, DateTime endDate); // registru jurnal
        Task<ProfitLossReportModel> ProfitLossReport(Guid companyId, DateTime startDate, DateTime endDate);
        Task<ICollection<CompanyChartOfAccounts>> TrialBalanceReport(Guid companyId); //  solduri conturi curente
    }
}
