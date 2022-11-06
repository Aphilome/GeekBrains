using MassTransit;
using Microsoft.Extensions.Logging;
using Restaurant.Messages.Abstract;

namespace Restaurant.Kitchen.Consumers;

public class KitchenBookingRequestFaultConsumer : IConsumer<Fault<IBookingRequest>>
{
    private readonly ILogger _logger;

    public KitchenBookingRequestFaultConsumer(
        ILogger<KitchenBookingRequestFaultConsumer> logger)
    {
        _logger = logger;
    }

    // Идемпотентный
    public Task Consume(ConsumeContext<Fault<IBookingRequest>> context)
    {
        _logger.LogError($"[OrderId {context.Message.Message.OrderId}] Cancel in kitchen");
        return Task.CompletedTask;
    }
}