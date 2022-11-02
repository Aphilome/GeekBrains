using MassTransit;
using Microsoft.Extensions.Logging;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.SqlliteDb;

namespace Restaurant.Notification.Consumers;

public class NotifyConsumer : IConsumer<INotify>
{
    private readonly Notifier _notifier;
    private readonly IMessagesRepository _messagesRepository;
    private readonly Guid SubscriberId = new Guid("029C20B4-AEEB-4519-B24E-2000843706A2");
    private readonly ILogger _logger;


    public NotifyConsumer(
        Notifier notifier,
        IMessagesRepository messagesRepository,
        ILogger<NotifyConsumer> logger)
    {
        _notifier = notifier;
        _messagesRepository = messagesRepository;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<INotify> context)
    {
        if (context.MessageId.HasValue == false || !await _messagesRepository.InsertMessageSuccess(SubscriberId, context.MessageId.Value))
            return;
        _logger.LogInformation($"[{context.Message.OrderId}]Send notify to [{context.Message.ClientId}]: '{context.Message.Message}'");
        _notifier.Notify(context.Message.OrderId, context.Message.ClientId, context.Message.Message);
    }
}