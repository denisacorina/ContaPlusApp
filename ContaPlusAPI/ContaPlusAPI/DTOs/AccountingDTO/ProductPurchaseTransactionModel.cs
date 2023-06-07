using ContaPlusAPI.Models.InventoryModule;

namespace ContaPlusAPI.DTOs.AccountingDTO
{
    public class ProductPurchaseTransactionModel
    {
        public PurchaseSaleTransaction Transaction { get; set; }
        public List<Product> ProductPurchaseItems { get; set; }
    }
}
