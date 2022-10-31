﻿using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.Concrete;

public class KitchenReady : IKitchenReady
{
    public KitchenReady(Guid orderId, bool ready)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; }
}