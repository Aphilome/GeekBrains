using Restaurant.Notification.Enums;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant.Notification;

public class Notifier
{
    //импровизированный кэш для хранения статусов, номера заказа и клиента
    // orderId => (clientId, Accepted)
    private readonly ConcurrentDictionary<Guid, Tuple<Guid?, Accepted>> _state = new();

    public void Accept(Guid orderId, Accepted accepted, Guid? clientId = null)
    {
        _state.AddOrUpdate(orderId, 
            new Tuple<Guid?, Accepted>(clientId, accepted),
            (guid, oldValue) => new Tuple<Guid?, Accepted>(
                oldValue.Item1 ?? clientId, oldValue.Item2 | accepted));

        Notify(orderId);
    }

    private void Notify(Guid orderId)
    {
        var booking = _state[orderId];

        switch (booking.Item2)
        {
            case Accepted.All:
                Console.WriteLine($"Success booking for client {booking.Item1}");
                _state.Remove(orderId, out _);
                break;
            case Accepted.Rejected:
                Console.WriteLine($"Client {booking.Item1}, sorry, no free tables");
                _state.Remove(orderId, out _);
                break;
            case Accepted.Kitchen:
                Console.WriteLine($"Kitchen ready {booking.Item1}");
                break;
            case Accepted.KitchenProblem:
                Console.WriteLine($"Kitchen problem {booking.Item1}. We are so sorry");
                break;
            case Accepted.Booking:
                Console.WriteLine($"Start booking {booking.Item1}");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }
}