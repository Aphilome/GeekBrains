using Messaging.Enums;

namespace Restaurant.Messages.Abstract;

public interface IBookingRequest : IWithCreatedDate
{
    public Guid OrderId { get; }

    public Guid ClientId { get; }

    public Dish? PreOrder { get; }

    public DateTime CreatedDate { get; }
}