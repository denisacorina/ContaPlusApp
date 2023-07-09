using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;
using ContaPlusAPI.Models;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using ContaPlusAPI.Models.UserModule;

namespace ContaPlusAPI.DTOs.AccountingDTO
{
    public class PurchaseSaleTransaction
    {
        public string DocumentNumber { get; set; }
        public string DocumentSeries { get; set; }  
        public decimal TransactionAmount { get; set; }
        public decimal PaidAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Description { get; set; }
        public virtual GeneralChartOfAccounts DebitAccount { get; set; }
        public virtual GeneralChartOfAccounts CreditAccount { get; set; }
        public virtual Company Company { get; set; }
        public virtual Product? Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual Client? Client { get; set; }
        public virtual User User { get; set; }
    }
}
