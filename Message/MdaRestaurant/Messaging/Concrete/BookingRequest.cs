using Messaging.Enums;
using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.Concrete;

public class BookingRequest : IBookingRequest
{
    public BookingRequest(Guid orderId, Guid clientId, Dish? preOrder, DateTime creationDate)
    {
        OrderId = orderId;
        ClientId = clientId;
        PreOrder = preOrder;
        CreatedDate = creationDate;
    }

    public Guid OrderId { get; }
    public Guid ClientId { get; }
    public Dish? PreOrder { get; }

    public DateTime CreatedDate { get; set; }
}