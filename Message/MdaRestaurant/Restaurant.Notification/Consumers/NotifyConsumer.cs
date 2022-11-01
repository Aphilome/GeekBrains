using MassTransit;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.SqlliteDb;

namespace Restaurant.Notification.Consumers;

public class NotifyConsumer : IConsumer<INotify>
{
    private readonly Notifier _notifier;
    private readonly IMessagesRepository _messagesRepository;
    private readonly Guid SubscriberId = new Guid("029C20B4-AEEB-4519-B24E-2000843706A2");

    public NotifyConsumer(
        Notifier notifier,
        IMessagesRepository messagesRepository)
    {
        _notifier = notifier;
        _messagesRepository = messagesRepository;
    }

    public async Task Consume(ConsumeContext<INotify> context)
    {
        if (context.MessageId.HasValue == false || !await _messagesRepository.InsertMessageSuccess(SubscriberId, context.MessageId.Value))
            return;
        _notifier.Notify(context.Message.OrderId, context.Message.ClientId, context.Message.Message);
    }
}