using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.Concrete;

public class KitchenReady : IKitchenReady
{
    public KitchenReady(Guid orderId, bool ready, int tableId)
    {
        OrderId = orderId;
        Ready = ready;
        TableId = tableId;
    }

    public Guid OrderId { get; }

    public int TableId { get; }

    public bool Ready { get; }
}