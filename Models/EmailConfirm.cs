using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace ITI_Training_Hospital_System.Models
{
    public class EmailConfirm : IEmailSender
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var fmail = "tarekelspagh707@gmail.com";
            var fPassword = "zdcu zqyp ahjr eude";

            var smtpClient = new SmtpClient("smtp.gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential("tarekelspagh707@gmail.com", "zdcu zqyp ahjr eude"),
                EnableSsl = true,
            };

            var themsg = new MailMessage();
            themsg.From = new MailAddress(fmail);
            themsg.Subject = subject;
            themsg.To.Add(email);
            themsg.Body = $"<html><body>{htmlMessage}</body></html>";
            themsg.IsBodyHtml = false;

            smtpClient.Send(themsg);


        }
    }
}
