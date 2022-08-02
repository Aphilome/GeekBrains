namespace Catalog.Services.Abstract
{
    public interface IMailSender
    {
        Task SendMail(string message, CancellationToken cancellationToken);

        Task SendMail(string message, string subject, CancellationToken cancellationToken);
    }
}
