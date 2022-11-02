using MassTransit;
using MassTransit.Audit;
using Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using Restaurant.Messages.SqlliteDb;
using Restaurant.Notification.Consumers;

namespace Restaurant.Notification;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        services.AddMassTransit(x =>
        {
            services.AddSingleton<IMessageAuditStore, AuditStore>();

            var serviceProvider = services.BuildServiceProvider();
            var auditStore = serviceProvider.GetService<IMessageAuditStore>();

            x.AddConsumer<NotifyConsumer>()
                .Endpoint(e => e.Temporary = true);

            x.UsingRabbitMq((context, cfg) =>
            {
                cfg.UseMessageRetry(r =>
                {
                    r.Exponential(5,
                        TimeSpan.FromSeconds(1),
                        TimeSpan.FromSeconds(100),
                        TimeSpan.FromSeconds(5));
                    r.Ignore<StackOverflowException>();
                    r.Ignore<ArgumentNullException>(x => x.Message.Contains("Consumer"));
                });

                cfg.Host(RabbitMqConnectionSettings.HostName, RabbitMqConnectionSettings.Port, RabbitMqConnectionSettings.UserAndVHost, h =>
                {
                    h.Username(RabbitMqConnectionSettings.UserAndVHost);
                    h.Password(RabbitMqConnectionSettings.Password);
                });
                cfg.ConfigureEndpoints(context);
                cfg.ConnectSendAuditObservers(auditStore);
                cfg.ConnectConsumeAuditObserver(auditStore);
            });
        });

        services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            options.StopTimeout = TimeSpan.FromMinutes(1);
        });

        services.AddSingleton<Notifier>();
        services.AddSingleton<IMessagesRepository, MessagesRepository>();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseRouting();

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapMetrics();
            endpoints.MapControllers();
        });
    }
}

