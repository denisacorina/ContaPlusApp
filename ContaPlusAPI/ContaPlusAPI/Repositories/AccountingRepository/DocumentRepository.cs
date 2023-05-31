using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.AccountingModule;

namespace ContaPlusAPI.Repositories.AccountingRepository
{
    public class DocumentRepository : IDocumentRepository
    {
        private readonly AppDbContext _context;

        public DocumentRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateInvoice(Document invoice)
        {
            _context.Documents.Add(invoice);
            await _context.SaveChangesAsync();
        }

        public async Task CreateReceipt(Document receipt)
        {
            _context.Documents.Add(receipt);
            await _context.SaveChangesAsync();
        }
        
        public async Task CreateGoodsReceiptNote(Document goodsReceiptNote)
        {
            _context.Documents.Add(goodsReceiptNote);
            await _context.SaveChangesAsync();
        }
    }
}
