namespace Restaurant.Notification.Enums;

[Flags]
public enum Accepted
{
    Rejected = 0,
    Kitchen = 1,
    Booking = 2,
    KitchenProblem = 4,
    All = Kitchen | Booking
}
