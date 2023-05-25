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
        public string Address { get; set; }
        [RegularExpression(@"^RO\d{2}[A-Z]{4}\d{16}$", ErrorMessage = "IBAN must be in the format 'RO49 AAAA 1031 0075 9384 0000'")]
        public string BankAccount { get; set; }
        public virtual Company Company { get; set; }
    }
}
