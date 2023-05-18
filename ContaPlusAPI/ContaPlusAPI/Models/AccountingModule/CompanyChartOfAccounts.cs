using ContaPlusAPI.Models.CompanyModule;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class CompanyChartOfAccounts
    {
        [Key]
        public int CompanyChartOfAccountsId { get; set; }
        public Guid CompanyId { get; set; }
        public int AccountCode { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal InitialBalance { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal CurrentBalance { get; set; }
        public DateTime LastUpdatedDate { get; set; }
        public virtual Company Company { get; set; }
    }
}
