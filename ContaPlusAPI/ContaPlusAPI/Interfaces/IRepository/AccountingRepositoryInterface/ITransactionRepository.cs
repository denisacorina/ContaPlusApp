using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface
{
    public interface ITransactionRepository
    {
        Task AddTransaction(Transaction transaction);
        Task<GeneralChartOfAccounts> GetGeneralChartOfAccountsByAccountCode(int accountCode);
        Task<CompanyChartOfAccounts> GetCompanyChartOfAccountsByAccountCode(int accountCode, Guid companyId);
        Task <ICollection<Transaction>> GetIncomeTransactions(Guid companyId);
        Task AddCompanyChartOfAccounts(CompanyChartOfAccounts companyChartOfAccounts, Guid companyId);
        Task UpdateTransaction(Transaction transaction);
        Task UpdateCompanyChartOfAccountsBalance(CompanyChartOfAccounts account);
        Task<Transaction> GetTransactionByDocumentNumberAndSeries(string documentNumber, string documentSeries);
        Task UpdateTransactionPaidAmountAndStatus(string documentNumber, string documentSeries, decimal paidAmount);
    }
}
