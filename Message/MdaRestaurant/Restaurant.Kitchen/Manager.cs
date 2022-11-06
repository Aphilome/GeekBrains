using MassTransit;
using Messaging.Enums;

namespace Restaurant.Kitchen;

public class Manager
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