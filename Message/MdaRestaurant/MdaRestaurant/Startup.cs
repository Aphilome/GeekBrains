using MassTransit;
using MassTransit.Audit;
using Messaging;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Prometheus;
using Restaurant.Booking.Consumers;
using Restaurant.Booking.Models;
using Restaurant.Booking.Saga;
using Restaurant.Messages.InMemoryDb;

namespace Restaurant.Booking;

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

        services.Configure<MassTransitHostOptions>(options =>
        {
            options.WaitUntilStarted = true;
            options.StartTimeout = TimeSpan.FromSeconds(30);
            options.StopTimeout = TimeSpan.FromMinutes(1);
        });

        services.AddTransient<RestaurantBooking>();
        services.AddTransient<RestaurantBookingSaga>();
        services.AddTransient<MdaRestaurant.Models.Restaurant>();
        services.AddSingleton<IInMemoryRepository<BookingRequestModel>, InMemoryRepository<BookingRequestModel>>();

        services.AddHostedService<Worker>();
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

