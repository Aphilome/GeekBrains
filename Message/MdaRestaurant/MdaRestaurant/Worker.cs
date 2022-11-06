using Messaging.Concrete;
using MassTransit;
using Microsoft.Extensions.Hosting;

namespace Restaurant.Booking;

internal class Worker : BackgroundService
{
    private readonly IBus _bus;
    private readonly MdaRestaurant.Models.Restaurant _restaurant;

    public Worker(IBus bus, MdaRestaurant.Models.Restaurant restaurant)
    {
        _bus = bus;
        _restaurant = restaurant;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            await Task.Delay(10000, stoppingToken);
            Console.WriteLine("Hi! Do you want book table?");
            var result = await _restaurant.BookFreeTableAsync(1);
            //забронируем с ответом по смс
            await _bus.Publish(new TableBooked(NewId.NextGuid(), NewId.NextGuid(), result ?? null),
                context => context.Durable = false, stoppingToken);
        }
    }
}