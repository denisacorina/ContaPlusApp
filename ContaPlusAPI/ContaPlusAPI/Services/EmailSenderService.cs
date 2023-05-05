using ContaPlusAPI.Interfaces.IService;
using ContaPlusAPI.Models.CompanyModule;
using ContaPlusAPI.Models.UserModule;
using MailKit.Net.Smtp;
using MimeKit;

namespace ContaPlusAPI.Services
{
    public class EmailSenderService : IEmailSenderService
    {
        public MimeMessage CreateMimeMessage(User user, string subject, TextPart body)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ContaPlus", "corina.denisa.obreja2@digitalexplorer.ro"));
            message.To.Add(new MailboxAddress(user.FirstName + " " + user.LastName, user.Email));
            message.Subject = subject;
            message.Body = body;
            return message;
        }

        public async Task SendEmail(MimeMessage message)
        {
            var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, false);
            await client.AuthenticateAsync("corina.denisa.obreja2@digitalexplorer.ro", "ContaPlus10App");
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }

        public async Task AfterRegistrationEmail(User user)
        {
            string subject = "Welcome to Our Website!";
            var body = new TextPart("html")
            {
                Text = $@"<p>Welcome, {user.FirstName + " " + user.LastName}!</p>
                 <p>Thanks for registering on our website! Click the link below to login and create your first company!</p>
                 <p>Login here: <a href=""http://localhost:4200/login"">http://localhost:4200/login</a></p>
                 <h1 style=""color: #3838df"">ContaPlus</h1>"
            };

            var message = CreateMimeMessage(user, subject, body);

            await SendEmail(message);
        }

        public async Task SendResetPasswordLink(User user)
        {
            var email = user.Email;
            var resetToken = user.ResetPasswordToken;

            string subject = "Password reset request";
            var body = new TextPart("html")
            {
                Text = $@"Please click on the following link to reset your password: <a href=""http://localhost:4200/reset-password/{email}/{resetToken}"">http://localhost:4200/reset-password/{email}/{resetToken}</a>"
            };

            var message = CreateMimeMessage(user, subject, body);

            await SendEmail(message);
        }

        public async Task SendEmailToNewAddedUserWithAccount(User user, string companyName, Role role)
        {
            string subject = $"You have been added to the company: {companyName}";
            var body = new TextPart("html")
            {
                Text = $@"<p>You have been added to the company: {companyName} with the following role:</p>
                  <ul>{string.Join("", $"{role.RoleName}")}</ul>
                 <p>Login here: <a href=""http://localhost:4200/login"">http://localhost:4200/login</a></p>
                 <h1 style=""color: #3838df"">ContaPlus</h1>"
            };

            var message = CreateMimeMessage(user, subject, body);

            await SendEmail(message);
        }

        public async Task SendEmailToNewAddedUserWithoutAccount(User user, string companyName, Role role, string password)
        {
            string subject = $"You have been added to {companyName}";
            var body = new TextPart("html")
            {
                Text = $@"<p>You have been added to {companyName} with the following role:</p>
                 <ul>{string.Join("", $"{role.RoleName}")}</ul>
                 <p>Your temporary password is: {password}</p>
                 <p>Please click the link below to login and change your password:</p>
                 <p>Login here: <a href=""http://localhost:4200/login"">http://localhost:4200/login</a></p>
                 <h1 style=""color: #3838df"">ContaPlus</h1>"
            };

            var message = CreateMimeMessage(user, subject, body);

            await SendEmail(message);
        }
    }
}
