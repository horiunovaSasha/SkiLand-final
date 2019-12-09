using System.Threading.Tasks;

namespace SkiLand.Domain.Services
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
        Task SendEmailConfirmationAsync(string email, string callbackUrl);
    }
}
