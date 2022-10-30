using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.Concrete;

public class BookingCancellation : IBookingCancellation
{
    public BookingCancellation(Guid orderId)
    {
        OrderId = orderId;
    }

    public Guid OrderId { get; }
}