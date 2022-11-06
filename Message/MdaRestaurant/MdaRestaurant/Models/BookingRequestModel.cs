using Messaging.Enums;
using Restaurant.Messages.Abstract;

namespace Restaurant.Booking.Models;

public class BookingRequestModel: IWithCreatedDate
{
    public BookingRequestModel(Guid orderId, Guid clientId, Dish? preOrder, DateTime creationDate, string messageId)
    {
        _messageIds.Add(messageId);

        OrderId = orderId;
        ClientId = clientId;
        PreOrder = preOrder;
        CreatedDate = creationDate;
    }

    public BookingRequestModel Update(BookingRequestModel model, string messageId)
    {
        _messageIds.Add(messageId);

        OrderId = model.OrderId;
        ClientId = model.ClientId;
        PreOrder = model.PreOrder;
        CreatedDate = model.CreatedDate;

        return this;
    }

    public bool CheckMessageId(string messageId)
    {
        return _messageIds.Contains(messageId);
    }

    private readonly List<string> _messageIds = new List<string>();
    public Guid OrderId { get; private set; }
    public Guid ClientId { get; private set; }
    public Dish? PreOrder { get; private set; }
    public DateTime CreatedDate { get; set; }
}