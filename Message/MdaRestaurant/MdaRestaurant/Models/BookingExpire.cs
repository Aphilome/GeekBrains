﻿using Restaurant.Booking.Saga;

namespace MdaRestaurant.Models;

public class BookingExpire : IBookingExpire
{
    private readonly RestaurantBooking _instance;

    public BookingExpire(RestaurantBooking instance)
    {
        _instance = instance;
    }

    public Guid OrderId => _instance.OrderId;
}