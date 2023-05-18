using ContaPlusAPI.Models.CompanyModule;
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        [RegularExpression(@"^RO\d+$", ErrorMessage = "Fiscal code must be in the format 'RO123456'.")]
        public string FiscalCode { get; set; }
        public virtual Company Company { get; set; }
    }
}
