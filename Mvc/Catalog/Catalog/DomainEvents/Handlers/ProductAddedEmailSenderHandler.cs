using Catalog.DomainEvents.Bl;
using Catalog.Services.Abstract;

namespace Catalog.DomainEvents.Handlers
{
    public class ProductAddedEmailSenderHandler : BackgroundService
    {
        private readonly IMailSender _mailSender;
        private readonly ILogger<ProductAddedEmailSenderHandler> _logger;

        public ProductAddedEmailSenderHandler(
            IServiceProvider serviceProvider,
            ILogger<ProductAddedEmailSenderHandler> logger)
        {
            _logger = logger;
            DomainEventsManager.Register<ProductAdded>(async e => await SendEmailNotifications(e));

            var serviceScope = serviceProvider.CreateScope();
            var provider = serviceScope.ServiceProvider;
            _mailSender = provider.GetRequiredService<IMailSender>();
        }

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            return Task.CompletedTask;
        }

        private async Task SendEmailNotifications(ProductAdded e)
        {
            _logger.LogInformation("Вызов хендлера добавления нового события и отправки почты");
            var message = $"New product {e.NewProduct.Name} [{e.NewProduct.Id}] in [{e.NewProduct.CategoryId}]";
            await _mailSender.SendMail(message, CancellationToken.None); // тут
        }
    }
}
