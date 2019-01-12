using Services.Abstract;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class EmailService : IEmailService
    {
        private const string EMAIL_FROM = "forw717@gmail.com";
        private const string PASSWORD_FROM = "pas112pas112qaz";

        public Task SendSimpleEmailMessage(string to, string title, string text)
        {
            return Task.Run(() =>
            {
                try
                {
                    MailMessage mail = new MailMessage();
                    mail.From = new MailAddress(EMAIL_FROM);
                    mail.To.Add(new MailAddress(to));
                    mail.Subject = title;
                    mail.Body = text;

                    SmtpClient client = new SmtpClient
                    {
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        Credentials = new NetworkCredential(EMAIL_FROM.Split('@')[0], PASSWORD_FROM),
                        DeliveryMethod = SmtpDeliveryMethod.Network
                    };
                    client.Send(mail);
                    mail.Dispose();
                }
                catch (Exception e)
                {
                    throw new Exception("Mail.Send: " + e.Message);
                }
            });
        }
    }
}
