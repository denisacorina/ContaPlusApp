using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.DTOs.AccountingDTO
{
    public class ProductSaleTransactionModel
    {
        public PurchaseSaleTransaction Transaction { get; set; }
        public List<Product> ProductSaleItems { get; set; }
    }
}
