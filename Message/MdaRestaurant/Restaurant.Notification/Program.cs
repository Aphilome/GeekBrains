﻿using GreenPipes;
using MassTransit;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages.SqlliteDb;
using Restaurant.Notification;
using Restaurant.Notification.Consumers;

CreateHostBuilder(args).Build().Run();



IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddMassTransit(x =>
            {
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
                });



            });
            services.AddSingleton<Notifier>();
            services.AddSingleton<IMessagesRepository, MessagesRepository>();
            services.AddMassTransitHostedService(true);
        });
