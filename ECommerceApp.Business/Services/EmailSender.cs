using ECommerceApp.Business.Interfaces;
using System.Net;
using System.Net.Mail;

namespace ECommerceApp.Business.Services
{
    public class EmailSender : IEmailService
    {
        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            string fromMail = "mubark738@gmail.com";

            string fromPassword = "";

            var message = new MailMessage();
            message.From = new MailAddress(fromMail);
            message.Subject = subject;
            message.To.Add(email);
            message.Body = $"<html><body>{htmlMessage}</body></html>";
            message.IsBodyHtml = true;

            using var smtpClient = new SmtpClient(host: "stmp-gmail.com")
            {
                Port = 587,
                Credentials = new NetworkCredential(fromMail, fromPassword),
                EnableSsl = true
            };

            try
            {
                await smtpClient.SendMailAsync(message);
            }
            catch (Exception)
            {
                throw;
            }

        }

        //public Task<string> SendEmailAsync(string email, string Message)
        //{
        //    return email;
        //}
    }
}
