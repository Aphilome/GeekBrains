using MassTransit;
using Restaurant.Messages.Abstract;

namespace Restaurant.Kitchen.Consumers;

public class KitchenBookingRequestFaultConsumer : IConsumer<Fault<IBookingRequest>>
{
    public Task Consume(ConsumeContext<Fault<IBookingRequest>> context)
    {
        Console.WriteLine($"[OrderId {context.Message.Message.OrderId}] Cancel in kitchen");
        return Task.CompletedTask;
    }
}