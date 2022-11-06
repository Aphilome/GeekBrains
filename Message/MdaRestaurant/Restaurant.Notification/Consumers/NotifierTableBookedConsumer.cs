using MassTransit;
using Messaging.Abstract;
using Restaurant.Notification.Enums;

namespace Restaurant.Notification.Consumers;

public class NotifierTableBookedConsumer : IConsumer<ITableBooked>
{
    private readonly Notifier _notifier;

    public NotifierTableBookedConsumer(Notifier notifier)
    {
        _notifier = notifier;
    }

    public Task Consume(ConsumeContext<ITableBooked> context)
    {
        var result = context.Message;

        _notifier.Accept(context.Message.OrderId, result.TableId is not null ? Accepted.Booking : Accepted.Rejected,
            context.Message.ClientId);

        return Task.CompletedTask;
    }
}