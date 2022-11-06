using MassTransit;
using Messaging.Abstract;
using Messaging.Concrete;
using Restaurant.Booking.Models;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.InMemoryDb;

namespace Restaurant.Booking.Consumers;

internal class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
{
    private readonly MdaRestaurant.Models.Restaurant _restaurant;
    private readonly IInMemoryRepository<BookingRequestModel> _repository;

    public RestaurantBookingRequestConsumer(
        MdaRestaurant.Models.Restaurant restaurant, 
        IInMemoryRepository<BookingRequestModel> repository)
    {
        _restaurant = restaurant;
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<IBookingRequest> context)
    {
        var model = _repository.Get().FirstOrDefault(i => i.OrderId == context.Message.OrderId);

        if (model is not null && model.CheckMessageId(context.MessageId.ToString()))
        {
            Console.WriteLine(context.MessageId.ToString());
            Console.WriteLine("Second time");
            return;
        }
        var requestModel = new BookingRequestModel(context.Message.OrderId, context.Message.ClientId,
            context.Message.PreOrder, context.Message.CreationDate, context.MessageId.ToString());

        Console.WriteLine(context.MessageId.ToString());
        Console.WriteLine("First time");
        var resultModel = model?.Update(requestModel, context.MessageId.ToString()) ?? requestModel;
        _repository.AddOrUpdate(resultModel);

        Console.WriteLine($"[OrderId: {context.Message.OrderId}]");
        var result = await _restaurant.BookFreeTableAsync(1);

        await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
    }
}