using Messaging.Enums;

namespace Restaurant.Messages.Abstract;

public interface IKitchenAccident
{
    public Guid OrderId { get; }

    public Dish Dish { get; }
}