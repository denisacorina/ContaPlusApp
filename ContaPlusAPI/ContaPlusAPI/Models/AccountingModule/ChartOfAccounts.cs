using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class ChartOfAccounts
    {
        [Key]
        public int AccountCode { get; set; }
        public string AccountDescription { get; set; }
        public char AccountType { get; set; }
        public string? Product_Service { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
        public bool IsDebit { get; set; } = false;
        public bool IsCredit { get; set; } = false;

        [Column(TypeName = "decimal(18, 2)")]
        public decimal Amount { get; set; }
    }
}
