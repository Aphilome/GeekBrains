using MassTransit;
using Microsoft.Extensions.Logging;
using Restaurant.Messages.Abstract;

namespace Restaurant.Booking.Consumers;

public class BookingRequestFaultConsumer : IConsumer<Fault<IBookingRequest>>
{
    private readonly ILogger _logger;

    public BookingRequestFaultConsumer(
        ILogger<BookingRequestFaultConsumer> logger)
    {
        _logger = logger;
    }

    // Идемпотентный
    public Task Consume(ConsumeContext<Fault<IBookingRequest>> context)
    {
        _logger.LogError($"[OrderId {context.Message.Message.OrderId}] Cancel in holl");
        return Task.CompletedTask;
    }
}