using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.Interfaces.IService.AccountingServiceInterface
{
    public interface ITransactionService
    {
        Task CreateIncomeTransaction(Transaction model, Guid companyId);
        Task CreateExpenseTransaction(Transaction model, Guid companyId);
        Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId);
        Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId);
        Task CreateSupplierPaymentTransaction(Transaction model, Guid companyId);
        Task CreateCustomerReceiptTransaction(Transaction model, Guid companyId);

        Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId);
    }

    public interface IPaymentStatusVerifier
    {
        PaymentStatus VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction);
    }
}
