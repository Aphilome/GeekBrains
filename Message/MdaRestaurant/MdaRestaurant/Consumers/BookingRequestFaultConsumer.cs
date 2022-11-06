using MassTransit;
using Restaurant.Messages.Abstract;

namespace Restaurant.Booking.Consumers;

public class BookingRequestFaultConsumer : IConsumer<Fault<IBookingRequest>>
{
    // Идемпотентный
    public Task Consume(ConsumeContext<Fault<IBookingRequest>> context)
    {
        Console.WriteLine($"[OrderId {context.Message.Message.OrderId}] Cancel in holl");
        return Task.CompletedTask;
    }
}