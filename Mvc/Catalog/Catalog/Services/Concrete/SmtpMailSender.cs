using Catalog.Configs;
using Catalog.Services.Abstract;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;

namespace Catalog.Services.Concrete
{
    public class SmtpMailSender : IMailSender, IDisposable, IAsyncDisposable
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
            if (!(_smtpClient.IsAuthenticated && _smtpClient.IsSigned))
                await Register();
            if (!(_smtpClient.IsAuthenticated && _smtpClient.IsSigned))
                return;

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
                await _smtpClient.SendAsync(mime, cancellationToken);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SMTP Send error");
            }
        }

        public void Dispose()
        {
            try
            {
                _smtpClient.Disconnect(true);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, "SMTP Disconnect error");
            }
        }

        public async ValueTask DisposeAsync()
        {
            try
            {
                await _smtpClient.DisconnectAsync(true);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SMTP Disconnect error");
            }
        }

        private async Task Register()
        {
            _logger.LogInformation("SMTP Registration try");
            try
            {
                await _smtpClient.ConnectAsync(_smtpCredentials.Host, _smtpCredentials.Port, false);
                await _smtpClient.AuthenticateAsync(_smtpCredentials.FromMail, _smtpCredentials.HostPassword);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "SMTP Registration error");
            }
        }
    }
}
