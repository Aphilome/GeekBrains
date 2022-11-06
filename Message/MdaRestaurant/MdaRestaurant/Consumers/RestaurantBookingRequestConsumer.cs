using MassTransit;
using Messaging.Abstract;
using Messaging.Concrete;
using Restaurant.Messages.Abstract;

namespace Restaurant.Booking.Consumers;

internal class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
{
    private readonly MdaRestaurant.Models.Restaurant _restaurant;

    public RestaurantBookingRequestConsumer(MdaRestaurant.Models.Restaurant restaurant)
    {
        _restaurant = restaurant;
    }

    public async Task Consume(ConsumeContext<IBookingRequest> context)
    {
        Console.WriteLine($"[OrderId: {context.Message.OrderId}]");
        var result = await _restaurant.BookFreeTableAsync(1);

        await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
    }
}