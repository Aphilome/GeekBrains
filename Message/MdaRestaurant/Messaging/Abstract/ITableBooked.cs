using Messaging.Enums;

namespace Messaging.Abstract;

public interface ITableBooked
{
    public Guid OrderId { get; }

    public Guid ClientId { get; }

    public Dish? PreOrder { get; }

    public int? TableId { get; }
}
