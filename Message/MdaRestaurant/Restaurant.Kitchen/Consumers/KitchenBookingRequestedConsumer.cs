using MassTransit;
using Microsoft.Extensions.Logging;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.Concrete;

namespace Restaurant.Kitchen.Consumers;

internal class KitchenBookingRequestedConsumer : IConsumer<IBookingRequest>
{
    private readonly Manager _manager;
    private readonly ILogger _logger;

    public KitchenBookingRequestedConsumer(
        Manager manager, 
        ILogger<KitchenBookingRequestedConsumer> logger)
    {
        _manager = manager;
        _logger = logger;
    }

    // Идемпотентный
    public async Task Consume(ConsumeContext<IBookingRequest> context)
    {
        _logger.LogInformation($"[OrderId: {context.Message.OrderId} CreationDate: {context.Message.CreationDate}]");
        _logger.LogDebug("Trying time: " + DateTime.Now);

        await Task.Delay(5000);

        if (_manager.CheckKitchenReady(context.Message.OrderId, context.Message.PreOrder))
            await context.Publish<IKitchenReady>(new KitchenReady(context.Message.OrderId, true));
    }
}