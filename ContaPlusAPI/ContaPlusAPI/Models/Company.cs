using System.ComponentModel.DataAnnotations;

namespace ContaPlusAPI.Models
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }
        public string? CompanyName { get; set; }
        public string? Email { get; set; }
        public int? FiscalCode { get; set; }
       // [RegularExpression(@"^J\d{2}/\d{3}/\d{4}$", ErrorMessage = "Trade register must be in the format 'J01/123/4567'.")]
        public string? TradeRegister { get; set; }
        public string? PhoneNumber { get; set; }
        public string? Address { get; set; }
        public virtual CityCountyData? CityCountyData { get; set; }
        public bool TvaPayer { get; set; } = false;

        [Range(200, int.MaxValue, ErrorMessage = "The SocialCapital field must be at least 200.")]
        public int? SocialCapital { get; set; }
        public byte[]? Logo { get; set; }
        public byte[]? Signature { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<User>? Users { get; set; } = new List<User>();
       
    }
}
