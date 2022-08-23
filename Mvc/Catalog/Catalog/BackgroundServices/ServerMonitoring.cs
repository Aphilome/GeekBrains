using Catalog.Services.Abstract;
using System.Diagnostics;

namespace Catalog.BackgroundServices
{
    public class ServerMonitoring : BackgroundService
    {
        private readonly ILogger<ServerMonitoring> _logger;
        private readonly IServiceProvider _serviceProvider;

        public ServerMonitoring(
            ILogger<ServerMonitoring> logger,
            IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            var serviceScope = _serviceProvider.CreateScope();
            var provider = serviceScope.ServiceProvider;
            var mailSender = provider.GetRequiredService<IMailSender>();

            _logger.LogInformation("Мониторинг запущен");
            using var timer = new PeriodicTimer(TimeSpan.FromMinutes(1));
            var sw = Stopwatch.StartNew();
            while (await timer.WaitForNextTickAsync(stoppingToken))
            {
                var msg = $"Сервер работает уже {sw.Elapsed}";
                _logger.LogInformation(msg);
                await mailSender.SendMail(msg, "Server status", stoppingToken);
            }
            _logger.LogInformation("Мониторинг завершен");
        }
    }
}
