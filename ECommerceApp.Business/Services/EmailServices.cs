using ECommerceApp.Bases;
using ECommerceApp.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceApp.Business.Services
{
    public class EmailServices : ResponseHandler, IEmailServices  
    {
        #region Fields
        private readonly MailSetting _mailSetting;
        #endregion

        #region Constrcutor(s)

        public EmailServices(MailSetting mailSetting)
        {
            _mailSetting=mailSetting;
        }
        #endregion

        #region Funcation Handler
        public async Task<string> SendEmailAsync(string maliTo, string subject, string body, IList<IFormFile> formFiles = null)
        {
            // Sender And Object 
            var email = new MimeMessage
            {
                Sender = MailboxAddress.Parse(_mailSetting.Email),
                Subject = subject
            };

            // Send to how ? 
            email.To.Add(MailboxAddress.Parse(maliTo));

            var builder = new BodyBuilder();
            if (formFiles != null)
            {
                byte[] filebytes;
                foreach (var file in formFiles)
                {
                    if (file.Length > 0)
                    {
                        using var ms = new MemoryStream();
                        file.CopyTo(ms);
                        filebytes = ms.ToArray();

                        builder.Attachments.Add(file.Name, filebytes, ContentType.Parse(file.ContentType));
                    }
                }
            }

            builder.HtmlBody = body;
            email.Body = builder.ToMessageBody();
            email.From.Add(new MailboxAddress(_mailSetting.DisplayName, _mailSetting.Email));

            using (var smtp = new SmtpClient())
            {
                try
                {
                    await smtp.ConnectAsync(_mailSetting.Host, _mailSetting.Port, false);
                    await smtp.AuthenticateAsync(_mailSetting.Email, _mailSetting.Password);

                    await smtp.SendAsync(email);
                    return Success(email);
                }
                catch (SmtpCommandException ex)
                {
                    // Handle SMTP command errors (e.g., authentication issues, etc.)
                    Console.WriteLine($"Error sending email: {ex.Message}");
                    throw;
                }
                catch (Exception ex)
                {
                    // Handle general errors
                    Console.WriteLine($"Unexpected error: {ex.Message}");
                    throw;
                }
                finally
                {
                    await smtp.DisconnectAsync(true);  // Ensures proper disconnect even in case of error
                }
            }

        }

        #endregion
    }
}
