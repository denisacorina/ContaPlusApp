namespace ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface
{
    public interface IFinancialReportRepository
    {
        Task<string> GenerateTrialBalanceReport(DateTime startDate, DateTime endDate); // balanta de verificare
        Task<string> GenerateGeneralLedgerReport(DateTime startDate, DateTime endDate); // cartea mare
        Task<string> GenerateJournalEntryReport(DateTime startDate, DateTime endDate); // registru jurnal
        Task<string> GenerateCashFlowStatement(DateTime startDate, DateTime endDate); 
        Task<string> GenerateBalanceSheet(DateTime startDate, DateTime endDate); // bilant contabil
        Task<string> GenerateClosingEntriesReport(DateTime endDate); // inchidere conturi
        Task<string> GenerateMonthEndClosingReport(DateTime endDate);
        Task<string> GenerateProfitAndLossReport(DateTime startDate, DateTime endDate); 
    }
}
