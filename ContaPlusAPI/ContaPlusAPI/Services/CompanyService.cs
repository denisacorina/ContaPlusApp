using ContaPlusAPI.Interfaces.IRepository;
using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using ContaPlusAPI.Repositories;

namespace ContaPlusAPI.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;
        private readonly IUserService _userService;
        private readonly IUserCompanyRoleRepository _userCompanyRoleRepository;
        private readonly ISaveChangesRepository _saveChangesRepository;

        public CompanyService(ICompanyRepository companyRepository,
            IUserService userService, IUserCompanyRoleRepository userCompanyRoleRepository)
        {
            _companyRepository = companyRepository;
            _userService = userService;
            _userCompanyRoleRepository = userCompanyRoleRepository;
        }

        public async Task<Company> GetCompanyByEmail(string email)
        {
            return await _companyRepository.GetCompanyByEmail(email);
        }

        public async Task<Company> GetCompanyById(Guid companyId)
        {
            return await _companyRepository.GetCompanyById(companyId);
        }

        public async Task<IEnumerable<Company>> GetCompaniesCurrentUser(Guid userId)
        {
            return await _companyRepository.GetCompaniesCurrentUser(userId);
        }

        public async Task<bool> EmailExists(string email)
        {
            return await _companyRepository.EmailExists(email);
        }

        public async Task<bool> FiscalCodeExists(string fiscalCode)
        {
            return await _companyRepository.FiscalCodeExists(fiscalCode);
        }
        public async Task<bool> TradeRegisterExists(string tradeRegister)
        {
            return await _companyRepository.TradeRegisterExists(tradeRegister);
        }
        public async Task AddCompanyToUser(Company company)
        {
            var existingUser = await _userService.GetCurrentUser();
            if (existingUser == null)
                throw new Exception("User not found.");

            var emailExists = await _companyRepository.EmailExists(company.Email);
            if (emailExists) throw new ArgumentException("Email already exists.");

            var fiscalCodeExists = await _companyRepository.FiscalCodeExists(company.FiscalCode);
            if (fiscalCodeExists) throw new ArgumentException("Fiscal Code already exists.");

            var tradeRegisterExists = await _companyRepository.TradeRegisterExists(company.TradeRegister);
            if (tradeRegisterExists) throw new ArgumentException("Trade Register already exists.");

            Role adminRole = await _userCompanyRoleRepository.GetRoleById(1);
            if (adminRole != null)
            {
                UserCompanyRole userCompanyRole = existingUser.UserCompanyRoles.FirstOrDefault(u => u.Company.CompanyId == company.CompanyId);
                if (userCompanyRole == null)
                {
                    userCompanyRole = new UserCompanyRole
                    {
                        User = existingUser,
                        Company = company
                    };
                    existingUser.UserCompanyRoles.Add(userCompanyRole);
                    company.UserCompanyRoles?.Add(userCompanyRole);
                }
                userCompanyRole.Roles?.Add(adminRole);
            }
            
            company.Users = new List<User> { existingUser };
            company.CreatedAt = DateTime.UtcNow;
            existingUser.Companies?.Add(company);

            await _saveChangesRepository.SaveChanges();
        }

        public async Task UpdateCompany(Company updatedCompany, Guid companyId)
        {
            var currentCompanyInfo = await _companyRepository.GetCompanyById(companyId);
            if (currentCompanyInfo != null)
            {
                if (updatedCompany.CompanyName != null)
                    currentCompanyInfo.CompanyName = updatedCompany.CompanyName ?? currentCompanyInfo.CompanyName;

                if (updatedCompany.Email != null)
                    currentCompanyInfo.Email = updatedCompany.Email ?? currentCompanyInfo.Email;

                if (updatedCompany.FiscalCode != null)
                    currentCompanyInfo.FiscalCode = updatedCompany.FiscalCode ?? currentCompanyInfo.FiscalCode;

                if (updatedCompany.TradeRegister != null)
                    currentCompanyInfo.TradeRegister = updatedCompany.TradeRegister ?? currentCompanyInfo.TradeRegister;

                if (updatedCompany.PhoneNumber != null)
                    currentCompanyInfo.PhoneNumber = updatedCompany.PhoneNumber ?? currentCompanyInfo.PhoneNumber;

                if (updatedCompany.Address != null)
                    currentCompanyInfo.Address = updatedCompany.Address ?? currentCompanyInfo.Address;

                if (updatedCompany.SocialCapital >= 200)
                    currentCompanyInfo.SocialCapital = updatedCompany.SocialCapital;
                else updatedCompany.SocialCapital = currentCompanyInfo.SocialCapital;

                if (updatedCompany.Logo != null)
                    currentCompanyInfo.Logo = updatedCompany.Logo ?? currentCompanyInfo.Logo;

                if (updatedCompany.Signature != null)
                    currentCompanyInfo.Signature = updatedCompany.Signature ?? currentCompanyInfo.Signature;

                currentCompanyInfo.TvaPayer = updatedCompany.TvaPayer ? updatedCompany.TvaPayer : currentCompanyInfo.TvaPayer;

                currentCompanyInfo.UpdatedAt = DateTime.UtcNow;
            }

            await _saveChangesRepository.SaveChanges();
        }
    }
}
