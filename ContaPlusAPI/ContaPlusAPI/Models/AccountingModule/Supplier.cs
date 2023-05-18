using ContaPlusAPI.Models.CompanyModule;
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class Supplier
    {
        [Key]
        public int SupplierId { get; set; }
        public string SupplierName { get; set; }
        [RegularExpression(@"^RO\d+$", ErrorMessage = "Fiscal code must be in the format 'RO123456'.")]
        public string FiscalCode { get; set; }
        public virtual Company Company { get; set; }
    }
}
