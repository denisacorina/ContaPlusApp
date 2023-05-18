using ContaPlusAPI.Models.CompanyModule;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class GeneralChartOfAccounts
    {
        [Key]
        public int AccountCode { get; set; }
        public string AccountDescription { get; set; }
        public char AccountType { get; set; }
        public string? Product_Service { get; set; }
        public int AccountNumber { get; set; }
        public string AccountName { get; set; }
    }
}
