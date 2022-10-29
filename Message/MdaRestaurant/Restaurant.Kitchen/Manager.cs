using MassTransit;
using Messaging.Enums;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.Concrete;

namespace Restaurant.Kitchen;

internal class Manager
{
    private readonly IBus _bus;
    private readonly Random _random = new();

    public Manager(IBus bus)
    {
        _bus = bus;
    }

    public void CheckKitchenReady(Guid orderId, Dish? dish, int tableId)
    {
        var success = _random.Next(0, 101) < 20 ? false : true;
        _bus.Publish<IKitchenReady>(new KitchenReady(orderId, success, tableId));
    }
}