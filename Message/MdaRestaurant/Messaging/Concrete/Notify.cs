﻿using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.Concrete;

public class Notify : INotify
{
    public Notify(Guid orderId, Guid clientId, string message)
    {
        OrderId = orderId;
        ClientId = clientId;
        Message = message;
    }

    public Guid OrderId { get; }

    public Guid ClientId { get; }
    
    public string Message { get; }
}