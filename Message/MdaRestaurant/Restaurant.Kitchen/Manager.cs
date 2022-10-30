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

    public bool CheckKitchenReady(Guid orderId, Dish? dish)
    {
        return true;
    }
}