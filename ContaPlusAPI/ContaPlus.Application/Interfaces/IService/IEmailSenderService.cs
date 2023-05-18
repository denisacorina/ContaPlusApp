using ContaPlusAPI.Models.UserModule;
using MimeKit;

namespace ContaPlusAPI.Interfaces.IService
{
    public interface IEmailSenderService
    {
        public MimeMessage CreateMimeMessage(User user, string subject, TextPart body);
        public Task SendEmail(MimeMessage message);
        public Task AfterRegistrationEmail(User user);
        public Task SendResetPasswordLink(User user);
        public Task SendEmailToNewAddedUserWithAccount(User user, string companyName, Role role);
        public Task SendEmailToNewAddedUserWithoutAccount(User user, string companyName, Role role, string password);
    }
}
