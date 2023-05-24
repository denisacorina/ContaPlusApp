using ContaPlusAPI.DTOs.AccountingDTO;
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

        [HttpGet("getIncomeTransactions")]
        public async Task<ICollection<Transaction>> GetIncomeTransactions(Guid companyId)
        {
            return await _transactionService.GetIncomeTransactions(companyId);
        }

        [HttpPost("createIncomeTransaction")]
        public async Task CreateIncomeTransaction([FromBody] Transaction model, Guid companyId)
        {
            await _transactionService.CreateIncomeTransaction(model, companyId);
        }

        [HttpPost("createExpenseTransaction")]
        public async Task CreateExpenseTransaction([FromBody] Transaction model, Guid companyId)
        {
            await _transactionService.CreateExpenseTransaction(model, companyId);
        }

        //[HttpPost("createProductPurchaseTransaction")]
        //public async Task CreateProductPurchaseTransaction([FromBody] PurchaseSaleTransaction model, Guid companyId)
        //{
        //    await _transactionService.CreateProductPurchaseTransaction(model, companyId);
        //}

        //[HttpPost("createProductSaleTransaction")]
        //public async Task CreateProductSaleTransaction([FromBody] PurchaseSaleTransaction model, Guid companyId)
        //{
        //    await _transactionService.CreateProductSaleTransaction(model, companyId);
        //}

        //[HttpPost("createSupplierPaymentTransaction")]
        //public async Task CreateSupplierPaymentTransaction([FromBody] Transaction model, Guid companyId)
        //{
        //    await _transactionService.CreateSupplierPaymentTransaction(model, companyId);
        //}

        //[HttpPost("createCustomerReceiptTransaction")]
        //public async Task CreateCustomerReceiptTransaction([FromBody] Transaction model, Guid companyId)
        //{
        //    await _transactionService.CreateCustomerReceiptTransaction(model, companyId);
        //}
    }
}
