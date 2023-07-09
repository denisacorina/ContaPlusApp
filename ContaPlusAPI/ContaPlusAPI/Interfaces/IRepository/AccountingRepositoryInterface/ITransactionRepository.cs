using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface
{
    public interface ITransactionRepository
    {
        Task AddTransaction(Transaction transaction);
        Task<ICollection<Transaction>> GetAllTransactions();
        Task<ICollection<Transaction>> GetAllCompanyTransactions(Guid companyId);
        Task<Transaction> GetTransactionById(int transactionId);
        Task<GeneralChartOfAccounts> GetGeneralChartOfAccountsByAccountCode(int accountCode);
        Task<CompanyChartOfAccounts> GetCompanyChartOfAccountsByAccountCode(int accountCode, Guid companyId);
        Task <ICollection<Transaction>> GetIncomeTransactions(Guid companyId);
        Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId);
        Task AddCompanyChartOfAccounts(CompanyChartOfAccounts companyChartOfAccounts, Guid companyId);
        Task UpdateTransaction(Transaction updatedTransaction);
        Task UpdateTransactionById(int transactionId, Transaction updatedTransaction);
        Task DeleteTransaction(int transactionId, Guid companyId);
        Task UpdateCompanyChartOfAccountsBalance(CompanyChartOfAccounts account, Guid companyId);
        Task<Transaction> GetTransactionByDocumentNumberAndSeries(string documentNumber, string documentSeries);
        Task<ICollection<Transaction>> GetClientUnpaidTransactions(int clientId);
        Task<ICollection<Transaction>> GetSupplierUnpaidTransactions(int supplierId);
    }
}
