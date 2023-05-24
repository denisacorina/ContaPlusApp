using ContaPlusAPI.Models.CompanyModule;
using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models.InventoryModule
{
    public class Inventory
    {
        [Key]
        public int InventoryId { get; set; }
        public DateTime UpdatedAt { get; set; }
        public virtual Company Company { get; set; }
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
