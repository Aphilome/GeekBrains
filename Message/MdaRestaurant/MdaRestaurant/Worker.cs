using MassTransit;
using Microsoft.Extensions.Hosting;
using Restaurant.Messages.Concrete;
using Restaurant.Messages.Abstract;

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
            var dateTime = DateTime.Now;
            await _bus.Publish(
                (IBookingRequest)new BookingRequest(NewId.NextGuid(), NewId.NextGuid(), null, dateTime),
                stoppingToken);
        }
    }
}