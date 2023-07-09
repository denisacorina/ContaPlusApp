using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;
using ContaPlusAPI.Models.UserModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentSeries { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaidAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal RemainingAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime DueDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public virtual PaymentStatus PaymentStatus { get; set; }
        public string Description { get; set; }

        [ForeignKey("DebitAccount")]
        public int DebitAccountCode { get; set; }

        [ForeignKey("CreditAccount")]
        public int CreditAccountCode { get; set; }
        public virtual GeneralChartOfAccounts DebitAccount { get; set; }
        public virtual GeneralChartOfAccounts CreditAccount { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<ProductSale>? ProductSales { get; set; } = new List<ProductSale>();
        public virtual ICollection<ProductPurchase>? ProductPurchases { get; set; } = new List<ProductPurchase>();
        public virtual Supplier? Supplier { get; set; }
        public virtual Client? Client { get; set; }
        public virtual ICollection<Document>? Documents { get; set; } = new List<Document>();
        public virtual User User { get; set; }  
    }
}
