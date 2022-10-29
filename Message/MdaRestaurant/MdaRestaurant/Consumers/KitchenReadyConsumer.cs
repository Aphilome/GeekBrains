using MassTransit;
using Restaurant.Messages.Abstract;

namespace Restaurant.Booking.Consumers;

public class KitchenReadyConsumer : IConsumer<IKitchenReady>
{
    private readonly MdaRestaurant.Models.Restaurant _restaurant = new();

    public KitchenReadyConsumer()
    {
    }

    public async Task Consume(ConsumeContext<IKitchenReady> context)
    {
        var result = context.Message;

        if (!result.Ready)
            await _restaurant.CancelBookinkgAsync(result.TableId);
    }
}