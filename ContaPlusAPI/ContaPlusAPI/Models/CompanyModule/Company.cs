﻿using ContaPlusAPI.Models.AccountingModule;
using ContaPlusAPI.Models.InventoryModule;
using ContaPlusAPI.Models.UserModule;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContaPlusAPI.Models.CompanyModule
{
    public class Company
    {
        [Key]
        public Guid CompanyId { get; set; }

        [Required(ErrorMessage = "Company Name is required")]
        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }

        [RegularExpression(@"^RO\d+$", ErrorMessage = "Fiscal code must be in the format 'RO123456'.")]
        public string FiscalCode { get; set; }

        [Required(ErrorMessage = "Trade Register is required")]
        [RegularExpression(@"^J\d{2}/\d{3}/\d{4}$", ErrorMessage = "Trade register must be in the format 'J01/123/4567'.")]
        public string TradeRegister { get; set; }

        [Required(ErrorMessage = "Phone Number is required")]
        [RegularExpression(@"^07\d{8}$", ErrorMessage = "Phone number must be in the format '0712345678'.")]
        public string PhoneNumber { get; set; }
        [RegularExpression(@"^RO\d{2}[A-Z]{4}\d{16}$", ErrorMessage = "IBAN must be in the format 'RO49 AAAA 1031 0075 9384 0000'")]
        public string BankAccount { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string Address { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal CashBalance { get; set; }
        public bool TvaPayer { get; set; } = false;

        [Required(ErrorMessage = "Social Capital is required")]
        [Range(200, int.MaxValue, ErrorMessage = "The SocialCapital field must be at least 200.")]
        public int SocialCapital { get; set; }
        public byte[]? Logo { get; set; }
        public byte[]? Signature { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public virtual ICollection<User>? Users { get; set; } = new List<User>();
        public virtual ICollection<UserCompanyRole>? UserCompanyRoles { get; set; } = new List<UserCompanyRole>();
        public virtual ICollection<Transaction>? Transactions { get; set; } = new List<Transaction>();
        public virtual ICollection<CompanyChartOfAccounts> ChartOfAccounts { get; set; } = new List<CompanyChartOfAccounts>();
        public virtual ICollection<Product> Products { get; set; } = new List<Product>();

    }
}
