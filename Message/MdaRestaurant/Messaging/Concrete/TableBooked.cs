using Messaging.Abstract;
using Messaging.Enums;

namespace Messaging.Concrete;

public class TableBooked : ITableBooked
{
    public TableBooked(Guid orderId, Guid clientId, int? tableId, Dish? preOrder = null)
    {
        OrderId = orderId;
        ClientId = clientId;
        TableId = tableId;
        PreOrder = preOrder;
    }

    public Guid OrderId { get; }

    public Guid ClientId { get; }

    public Dish? PreOrder { get; }

    public int? TableId { get; }
}