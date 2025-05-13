using DevLife.Infrastructure.Identity.Interfaces.Services;
using DevLife.Shared.Mailer;
using Microsoft.Extensions.Configuration;

namespace DevLife.Infrastructure.Identity.Services
{
    class RegisterMailerService(IConfiguration configuration) : EmailService(configuration), IRegisterMailerService
    {
        public async Task SendConfirmationEmailAsync(string userName, string email, string token)
        {
            var confirmationLink = $"{configuration["AppSettings:BaseUrl"]!}/auth/confirm-email?email={email}&token={token}";

            var body = await GetEmailBodyAsync("RegisterEmailTemplate.html", new Dictionary<string, string>
            {
                { "UserName", userName },
                { "ConfirmationLink", confirmationLink },
            });

            await SendEmailAsync(email, "Test Email", body);
        }
    }
}
