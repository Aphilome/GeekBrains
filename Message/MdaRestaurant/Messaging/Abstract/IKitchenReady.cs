﻿namespace Restaurant.Messages.Abstract;

public interface IKitchenReady
{
    public Guid OrderId { get; }
}