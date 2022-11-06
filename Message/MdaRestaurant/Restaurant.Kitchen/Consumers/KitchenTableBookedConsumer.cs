using MassTransit;
using Messaging.Abstract;

namespace Restaurant.Kitchen.Consumers;

internal class KitchenTableBookedConsumer : IConsumer<ITableBooked>
{
    private readonly Manager _manager;

    public KitchenTableBookedConsumer(Manager manager)
    {
        _manager = manager;
    }

    public Task Consume(ConsumeContext<ITableBooked> context)
    {
        var result = context.Message;

        if (result.TableId is not null)
            _manager.CheckKitchenReady(context.Message.OrderId, context.Message.PreOrder, result.TableId.Value);

        return context.ConsumeCompleted;
    }
}