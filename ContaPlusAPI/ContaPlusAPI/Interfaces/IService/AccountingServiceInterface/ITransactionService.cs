using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.Interfaces.IService.AccountingServiceInterface
{
    public interface ITransactionService
    {
        Task CreateIncomeTransaction(Transaction model, Guid companyId, int clientId, Guid userId);
        Task CreateExpenseTransaction(Transaction model, Guid companyId, int supplierId, Guid userId);
        Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId, List<Product> productPurchaseItems, Guid userId);
        Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId, List<Product> productSaleItems, Guid userId);

        Task<ICollection<Transaction>> GetAllTransactions();
        Task<ICollection<Transaction>> GetAllCompanyTransactions(Guid companyId);
        Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId);
        Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId);

        Task UpdateTransaction(Transaction transaction);
        Task UpdateTransactionById(int transactionId, Transaction updatedTransaction);
        Task DeleteTransaction(int transactionId, Guid companyId);

        Task PayExistingTransaction(int transactionId, decimal amount);
        Task<PaymentStatus> VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction);

        Task<ICollection<Transaction>> GetClientUnpaidTransactions(int clientId);
        Task<ICollection<Transaction>> GetSupplierUnpaidTransactions(int supplierId);
    }
}
