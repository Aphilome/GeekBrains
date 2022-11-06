using MassTransit;
using Restaurant.Messages.Abstract;
using Restaurant.Notification.Enums;

namespace Restaurant.Notification.Consumers;

public class KitchenReadyConsumer : IConsumer<IKitchenReady>
{
    private readonly Notifier _notifier;

    public KitchenReadyConsumer(Notifier notifier)
    {
        _notifier = notifier;
    }

    public Task Consume(ConsumeContext<IKitchenReady> context)
    {
        var result = context.Message.Ready;

        _notifier.Accept(context.Message.OrderId, result ? Accepted.Kitchen : Accepted.KitchenProblem);

        return Task.CompletedTask;
    }
}