using Catalog.Services.Abstract;
using MailKit.Net.Smtp;
using MimeKit;

namespace Catalog.Services.Concrete
{
    public class MailSender : IMailSender
    {
        private readonly SmtpClient _smtpClient;

        private const string    FROM_NICK       = @"mr. Catalog service";
        private const string    FROM_MAIL       = @"asp2022gb@rodion-m.ru";
        private const string    FROM_PSW        = @"3drtLSa1";
        private const string    TO_NICK         = @"mr. Master";
        private const string    TO_MAIL         = @"1.katrin.1@mail.ru";
        private const string    SERVER_HOST     = @"smtp.beget.com";
        private const int       SERVER_PORT     = 25;
        private const string    MAIL_SUBJECT    = @"New product in catalog";

        public MailSender(
            SmtpClient smtpClient)
        {
            _smtpClient = smtpClient;
        }

        public async Task SendMail(string message, CancellationToken cancellationToken)
        {
            var mime = new MimeMessage();
            mime.From.Add(new MailboxAddress(FROM_NICK, FROM_MAIL));
            mime.To.Add(new MailboxAddress(TO_NICK, TO_MAIL));
            mime.Subject = MAIL_SUBJECT;
            mime.Body = new TextPart("plain")
            {
                Text = message
            };

            try
            {
                _smtpClient.Connect(SERVER_HOST, SERVER_PORT, false, cancellationToken);   // TODO: NOT ASYNC :(
                _smtpClient.Authenticate(FROM_MAIL, FROM_PSW, cancellationToken);          // TODO: NOT ASYNC :(
                _smtpClient.Send(mime, cancellationToken);                                 // TODO: NOT ASYNC :(
                _smtpClient.Disconnect(true, cancellationToken);                           // TODO: NOT ASYNC :(
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
