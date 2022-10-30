using Messaging.Enums;

namespace Restaurant.Messages.Abstract;

public interface IBookingRequest
{
    public Guid OrderId { get; }

    public Guid ClientId { get; }

    public Dish? PreOrder { get; }

    public DateTime CreationDate { get; }
}