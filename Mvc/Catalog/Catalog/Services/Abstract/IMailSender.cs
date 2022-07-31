namespace Catalog.Services.Abstract
{
    public interface IMailSender
    {
        Task SendMail(string message, CancellationToken cancellationToken);
    }
}
