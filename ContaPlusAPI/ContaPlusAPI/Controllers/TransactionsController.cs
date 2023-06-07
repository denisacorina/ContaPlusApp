﻿using ContaPlusAPI.DTOs.AccountingDTO;
using ContaPlusAPI.Interfaces.IService.AccountingServiceInterface;
using ContaPlusAPI.Models;
using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.Design;

namespace ContaPlusAPI.Controllers
{
    public class TransactionsController : BaseApiController
    {
        private readonly ITransactionService _transactionService;

        public TransactionsController(ITransactionService transactionService)
        {
            _transactionService = transactionService;
        }

        [HttpPut("payExistingTransaction")]
        public async Task PayExistingTransaction(int transactionId, decimal amount)
        {
            await _transactionService.PayExistingTransaction(transactionId, amount);
        }

        [HttpGet("getIncomeTransactions")]
        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _transactionService.GetIncomeTransactions(companyId);
        }

        [HttpPost("createIncomeTransaction")]
        public async Task CreateIncomeTransaction([FromBody] Transaction model, [FromQuery] Guid companyId, [FromQuery] int clientId)
        {
            await _transactionService.CreateIncomeTransaction(model, companyId, clientId);
        }

        [HttpGet("getExpenseTransactions")]
        public async Task<ICollection<Transaction>> GetExpenseTransactions(Guid companyId)
        {
            return await _transactionService.GetExpenseTransactions(companyId);
        }

        [HttpPost("createExpenseTransaction")]
        public async Task CreateExpenseTransaction([FromBody] Transaction model, [FromQuery] Guid companyId, [FromQuery] int supplierId)
        {
            await _transactionService.CreateExpenseTransaction(model, companyId, supplierId);
        }

        [HttpPost("createProductSaleTransaction")]
        public async Task CreateProductSaleTransaction([FromBody] ProductSaleTransactionModel model, Guid companyId)
        {
            await _transactionService.CreateProductSaleTransaction(model.Transaction, companyId, model.ProductSaleItems);
        }

        [HttpPost("createProductPurchaseTransaction")]
        public async Task CreateProductPurchaseTransaction([FromBody] ProductPurchaseTransactionModel model, Guid companyId)
        {
            await _transactionService.CreateProductPurchaseTransaction(model.Transaction, companyId, model.ProductPurchaseItems);
        }

        [HttpPut("updateTransaction")]
        public async Task UpdateTransaction(Transaction transaction)
        {
            await _transactionService.UpdateTransaction(transaction);
        }

        [HttpDelete("deleteTransaction")]
        public async Task DeleteTransaction(int transactionId, Guid companyId)
        {
            await _transactionService.DeleteTransaction(transactionId, companyId);
        }

        [HttpGet("getClientUnpaidTransactions")]
        public async Task<ICollection<Transaction>> GetClientUnpaidTransactions(int clientId)
        {
            return await _transactionService.GetClientUnpaidTransactions(clientId);
        }

        [HttpGet("getSupplierUnpaidTransactions")]
        public async Task<ICollection<Transaction>> GetSupplierUnpaidTransactions(int supplierId)
        {
            return await _transactionService.GetSupplierUnpaidTransactions(supplierId);
        }
    }
}
