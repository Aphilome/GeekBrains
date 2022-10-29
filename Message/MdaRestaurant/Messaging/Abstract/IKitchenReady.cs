namespace Restaurant.Messages.Abstract;

public interface IKitchenReady
{
    public Guid OrderId { get; }

    public bool Ready { get; }

    public int TableId { get; }
}