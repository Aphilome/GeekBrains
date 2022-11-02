using GreenPipes;
using MassTransit;
using MassTransit.Audit;
using Messaging;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Restaurant.Booking;
using Restaurant.Booking.Consumers;
using Restaurant.Booking.Models;
using Restaurant.Booking.Saga;
using Restaurant.Messages.InMemoryDb;

CreateHostBuilder(args).Build().Run();

IHostBuilder CreateHostBuilder(string[] args) =>
    Host.CreateDefaultBuilder(args)
        .ConfigureServices((hostContext, services) =>
        {
            services.AddMassTransit(x =>
            {
                services.AddSingleton<IMessageAuditStore, AuditStore>();

                var serviceProvider = services.BuildServiceProvider();
                var auditStore = serviceProvider.GetService<IMessageAuditStore>();

                x.AddConsumer<RestaurantBookingRequestConsumer>(configurator =>
                    {
                        configurator.UseScheduledRedelivery(r => 
                            r.Intervals(TimeSpan.FromSeconds(10), TimeSpan.FromSeconds(20), TimeSpan.FromSeconds(30))
                        );
                        configurator.UseMessageRetry(r =>
                            r.Incremental(3, TimeSpan.FromSeconds(1), TimeSpan.FromSeconds(2))
                        );
                    })
                    .Endpoint(e => e.Temporary = true);

                x.AddConsumer<BookingRequestFaultConsumer>()
                    .Endpoint(e => e.Temporary = true);

                x.AddSagaStateMachine<RestaurantBookingSaga, RestaurantBooking>()
                    .Endpoint(e => e.Temporary = true)
                    .InMemoryRepository();

                x.AddDelayedMessageScheduler();

                x.UsingRabbitMq((context, cfg) =>
                {
                    cfg.Host(RabbitMqConnectionSettings.HostName, RabbitMqConnectionSettings.Port, RabbitMqConnectionSettings.UserAndVHost, h =>
                    {
                        h.Username(RabbitMqConnectionSettings.UserAndVHost);
                        h.Password(RabbitMqConnectionSettings.Password);
                    });
                    cfg.UseDelayedMessageScheduler();
                    cfg.UseInMemoryOutbox();
                    cfg.ConfigureEndpoints(context);

                    cfg.ConnectSendAuditObservers(auditStore);
                    cfg.ConnectConsumeAuditObserver(auditStore);
                });
            });
            services.AddMassTransitHostedService(true);

            services.AddTransient<RestaurantBooking>();
            services.AddTransient<RestaurantBookingSaga>();
            services.AddTransient<MdaRestaurant.Models.Restaurant>();
            services.AddSingleton<IInMemoryRepository<BookingRequestModel>, InMemoryRepository<BookingRequestModel>>();

            services.AddHostedService<Worker>();
        });