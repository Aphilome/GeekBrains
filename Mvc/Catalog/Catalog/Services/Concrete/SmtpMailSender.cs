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
        private readonly ILogger<SmtpMailSender> _logger;

        private const string    MAIL_SUBJECT    = @"New product in catalog";

        public SmtpMailSender(
            IOptions<SmtpCredentials> smtpCredentials,
            ILogger<SmtpMailSender> logger,
            SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
            _smtpCredentials = smtpCredentials.Value;
            _logger = logger;
        }

        public async Task SendMail(string message, CancellationToken cancellationToken)
        {
            _logger.LogInformation("SMTP Send mail");
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
                _logger.LogError(ex, "SMTP Send error");
            }
        }
    }
}
