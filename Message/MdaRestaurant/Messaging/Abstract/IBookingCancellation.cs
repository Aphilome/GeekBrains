namespace Restaurant.Messages.Abstract;

public interface IBookingCancellation
{
    public Guid OrderId { get; }
}