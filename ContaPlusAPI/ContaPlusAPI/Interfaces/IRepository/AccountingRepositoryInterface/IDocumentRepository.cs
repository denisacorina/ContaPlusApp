using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface
{
    public interface IDocumentRepository
    {
        Task CreateInvoice(Document invoice);
        Task CreateReceipt(Document receipt);
        Task CreateGoodsReceiptNote(Document goodsReceiptNote);
        Task<ICollection<Document>> GetClientUnpaidInvoices(int clientId);
    }
}
