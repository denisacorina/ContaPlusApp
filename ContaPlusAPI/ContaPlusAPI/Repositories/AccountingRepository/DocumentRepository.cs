using ContaPlusAPI.Context;
using ContaPlusAPI.Interfaces.IRepository.AccountingRepositoryInterface;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.AccountingModule;
using Microsoft.EntityFrameworkCore;

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

        public async Task<ICollection<Document>> GetClientUnpaidInvoices(int clientId)
        {
            return await _context.Documents
                .Include(d => d.Transaction)
                .Where(d => d.Transaction.Client.ClientId == clientId
                            && d.DocumentType == DocumentType.Invoice
                            && d.Transaction.RemainingAmount > 0)
                .ToListAsync();
        }

    }
}
