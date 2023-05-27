using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.AccountingModule
{
    public class Document
    {
        [Key]
        public int DocumentId { get; set; }
        public DateTime DocumentDate { get; set; } = DateTime.UtcNow;
        public DocumentType DocumentType { get; set; }
        public byte[] PdfFile { get; set; }
        public virtual Transaction Transaction { get; set; }
    }
}
