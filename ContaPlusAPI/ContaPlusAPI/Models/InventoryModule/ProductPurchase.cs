using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.InventoryModule
{
    public class ProductPurchase
    {
        [Key]
        public int PurchaseId { get; set; }
        public Product Product { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal BoughtPrice { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal SellingPrice { get { return Product.Price; } }
        public int BoughtQuantity { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TvaFromBoughtPrice { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithoutTva { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithTva { get; set; }
        public DateTime PurchaseDate { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual Company Company { get; set; }

        public decimal CalculateTvaFromSellingPrice()
        {
            return CalculateTotalPriceWithoutTva() * 0.19m;
        }

        public decimal CalculateTotalPriceWithoutTva()
        {
            return BoughtPrice * BoughtQuantity;
        }

        public decimal CalculateTotalPriceWithTva()
        {
            return CalculateTotalPriceWithoutTva() + CalculateTvaFromSellingPrice();
        }
    }
}
