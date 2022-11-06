﻿namespace Restaurant.Messages.Abstract;

public interface INotify
{
    public Guid OrderId { get; }

    public Guid ClientId { get; }

    public string Message { get; }
}