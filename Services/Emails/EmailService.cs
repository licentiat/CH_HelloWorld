
using Nh.Util;
using System;
using System.Linq;
using System.Net;
using System.Net.Mail;

namespace Nh.Services.Emails
{
    public class EmailService : IEmailService, IDisposable
    {
        bool disposed;
        SmtpClient _client { get; }
        public EmailService(string host, int port, string username, string password)
        {
            _client = new SmtpClient(host, port)
            {
                EnableSsl = true,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(username, password)
            };
        }
        public void SendEmailAsync(EmailRequest emailRequest)
        {
            using (_client)
            {
                var mm = new MailMessage
                {
                    From = new MailAddress(emailRequest.From)
                };
                mm.To.CopyAddressesFrom(emailRequest.To);
                if (emailRequest.Cc?.Any() == true)
                {
                    mm.CC.CopyAddressesFrom(emailRequest.Cc);
                }
                if (emailRequest.Bcc?.Any() == true)
                {
                    mm.Bcc.CopyAddressesFrom(emailRequest.Bcc);
                }
                mm.Subject = emailRequest.Subject;
                mm.Body = emailRequest.Body;
                _client.SendAsync(mm, Guid.NewGuid());
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                _client.Dispose();
            }
            disposed = true;
        }


    }
}