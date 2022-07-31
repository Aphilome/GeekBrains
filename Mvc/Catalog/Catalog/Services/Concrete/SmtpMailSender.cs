using Catalog.Configs;
using Catalog.Services.Abstract;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Catalog.Services.Concrete
{
    public class SmtpMailSender : IMailSender
    {
        private readonly SmtpClient _smtpClient;
        private readonly SmtpCredentials _smtpCredentials;

        private const string    MAIL_SUBJECT    = @"New product in catalog";

        public SmtpMailSender(
            IOptions<SmtpCredentials> smtpCredentials,
            SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
            _smtpCredentials = smtpCredentials.Value;
        }

        public async Task SendMail(string message, CancellationToken cancellationToken)
        {
            var mime = new MimeMessage();
            mime.From.Add(new MailboxAddress(_smtpCredentials.FromNick, _smtpCredentials.FromMail));
            mime.To.Add(new MailboxAddress(_smtpCredentials.ToNick, _smtpCredentials.ToMail));
            mime.Subject = MAIL_SUBJECT;
            mime.Body = new TextPart("plain")
            {
                Text = message
            };

            try
            {
                _smtpClient.Connect(_smtpCredentials.Host, _smtpCredentials.Port, false, cancellationToken);            // TODO: NOT ASYNC :(
                _smtpClient.Authenticate(_smtpCredentials.FromMail, _smtpCredentials.HostPassword, cancellationToken);  // TODO: NOT ASYNC :(
                _smtpClient.Send(mime, cancellationToken);                                                              // TODO: NOT ASYNC :(
                _smtpClient.Disconnect(true, cancellationToken);                                                        // TODO: NOT ASYNC :(
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
