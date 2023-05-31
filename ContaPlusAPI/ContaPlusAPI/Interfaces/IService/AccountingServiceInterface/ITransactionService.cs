﻿using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Interfaces.IService.AccountingServiceInterface
{
    public interface ITransactionService
    {
        Task CreateIncomeTransaction(Transaction model, Guid companyId, int clientId);
        Task CreateExpenseTransaction(Transaction model, Guid companyId, int supplierId);
        Task CreateProductPurchaseTransaction(PurchaseSaleTransaction model, Guid companyId);
        Task CreateProductSaleTransaction(PurchaseSaleTransaction model, Guid companyId);
   
        Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId);
        Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId);

        Task UpdateTransaction(Transaction transaction);
        Task DeleteTransaction(int transactionId, Guid companyId);
        Task DeletePartialPaymentTransaction(int transactionId, Guid companyId);

        Task PayExistingTransaction(int transactionId, decimal amount);
        Task<PaymentStatus> VerifyPaymentStatus(decimal totalAmount, decimal paidAmount, Transaction transaction);
    }
}