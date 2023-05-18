﻿using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.InventoryModule;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class Transaction
    {
        [Key]
        public int TransactionId { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TransactionAmount { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal PaidAmount { get; set; }
        public DateTime TransactionDate { get; set; }
        public DateTime? DueDate { get; set; }
        public TransactionType TransactionType { get; set; }
        public PaymentStatus PaymentStatus { get; set; }
        public string Description { get; set; }

        [ForeignKey("DebitAccount")]
        public int DebitAccountCode { get; set; }

        [ForeignKey("CreditAccount")]
        public int CreditAccountCode { get; set; }
        public virtual GeneralChartOfAccounts DebitAccount { get; set; }
        public virtual GeneralChartOfAccounts CreditAccount { get; set; }
        public virtual Company Company { get; set; }
        public virtual Inventory Inventory { get; set; }
        public virtual Product Product { get; set; }
        public virtual Supplier? Supplier { get; set; }
        public virtual Client? Client { get; set; }
    }
}