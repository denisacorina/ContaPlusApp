namespace ContaPlusAPI.Models.AccountingModule
{
    public enum DocumentType
    {
        Invoice, 
        CustomerReceipt,
        ConsumptionVoucher, // bon de consum
        GoodsReceivedNote, // nota de intrare receptie (NIR)
        GoodsDispatchNote // nota de iesire receptie (NIR)
    }
}
