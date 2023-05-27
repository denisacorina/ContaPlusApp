using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.CompanyModule;
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
        public decimal TvaFromSellingPrice { get; set; }
    
        [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithoutTva { get; set; }
         [Column(TypeName = "decimal(18, 2)")]
        public decimal TotalPriceWithTva { get; set; }
        public DateTime SaleDate { get; set; }
        public virtual Transaction Transaction { get; set; }
        public virtual Company Company { get; set; }

        public decimal CalculateTvaFromSellingPrice()
        {
            return Product.Company.TvaPayer ? (SellingPrice * 0.19m) : 0;
        }

        public decimal CalculateTotalPriceWithoutTva()
        {
            return SellingPrice * SoldQuantity;
        }

        public decimal CalculateTotalPriceWithTva()
        {
            return CalculateTotalPriceWithoutTva() + CalculateTvaFromSellingPrice();
        }
    }
}
