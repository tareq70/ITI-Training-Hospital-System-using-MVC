using Microsoft.AspNetCore.Identity.UI.Services;
using System.Net;
using System.Net.Mail;

namespace ITI_Training_Hospital_System.Models
{
    public class EmailConfirm /*: IEmailSender*/
    {
        //public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        //{
        //    var fmail = "*************@gmail.com";
        //    var fPassword = "******************";

        //    var themsg = new MailMessage();
        //    themsg.From =new MailAddress(fmail);
        //    themsg.Subject = subject;
        //    themsg.To.Add(fmail);
        //    themsg.Body = $"<html><body>{htmlMessage}</body></html>";
        //    themsg.IsBodyHtml = false;

        //    var smtpClient = new SmtpClient("smtp-mail.outlook.com")
        //    {
        //        EnableSsl = true,
        //        Credentials = new NetworkCredential(fmail,fPassword),
        //        Port=587
        //    };
        //    smtpClient.Send(themsg);
        //}
    }
}
