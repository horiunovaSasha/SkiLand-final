using System;
using System.Net;
using System.Net.Mail;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace SkiLand.Domain.Services
{
    // This class is used by the application to send email for account confirmation and password reset.
    // For more details see https://go.microsoft.com/fwlink/?LinkID=532713
    public class EmailSender : IEmailSender
    {
        public Task SendEmailAsync(string email, string subject, string body)
        {
            return Task.Run(() => SendEmail(email, subject, body));
        }

        public Task SendEmailConfirmationAsync(string email, string callbackUrl)
        {
            return SendEmailAsync(email, 
                "Confirm your email",
                $"Please confirm your account by clicking this link: <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>link</a>");
        }

        private void SendEmail(string email, string subject, string body)
        {
            try
            {
                var message = new MailMessage();
                SmtpClient smtp = new SmtpClient();
                message.From = new MailAddress("support@skiland.com");
                message.To.Add(new MailAddress(email));
                message.Subject = subject;
                message.IsBodyHtml = true; //to make message body as html  
                message.Body = body;
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com"; //for gmail host  
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential("skiland.student@gmail.com", "P$ssw0rd.1");
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
                smtp.Send(message);

            } catch(Exception ex)
            {
                //Log.Error(ex);
                throw ex;
            }
        }
    }
}
