using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.DTOs.AccountingDTO
{
    public class ProfitLossReportModel
    {
        public List<Transaction> CompanyChartOfAccountsIncome { get; set; }
        public List<Transaction> CompanyChartOfAccountsExpense { get; set; }
        public decimal IncomeTotal { get; set; }
        public decimal ExpenseTotal { get; set; }
        public decimal ProfitLoss { get; set; }
    }
}
