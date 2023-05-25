using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.InventoryModule
{
    public class ProductSale
    {
        [Key]
        public int SaleId { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellingPrice { get { return Product.Price; } }
        public int SoldQuantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TvaFromSellingPrice { get { return Product.Company.TvaPayer ? (SellingPrice * 0.19m) : 0; }
        }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithoutTva { get { return SellingPrice * SoldQuantity; } }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithTva { get { return TotalPriceWithoutTva + TvaFromSellingPrice; } }
        public DateTime SaleDate { get; set; }
    }
}
