using MassTransit;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Kitchen;
using Restaurant.Kitchen.Consumers;

CreateHostBuilder(args).Build().Run();


IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddMassTransit(x =>
            {
                x.AddConsumer<KitchenBookingRequestedConsumer>()
                    .Endpoint(e => e.Temporary = true);
                x.AddConsumer<KitchenBookingRequestFaultConsumer>()
                    .Endpoint(e => e.Temporary = true);
                
                x.AddDelayedMessageScheduler();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(RabbitMqConnectionSettings.HostName, RabbitMqConnectionSettings.Port, RabbitMqConnectionSettings.UserAndVHost, h =>
                    {
                        h.Username(RabbitMqConnectionSettings.UserAndVHost);
                        h.Password(RabbitMqConnectionSettings.Password);

                    });

                    cfg.ConfigureEndpoints(context);
                });
            });

            services.AddSingleton<Manager>();

            services.AddMassTransitHostedService(true);
        });