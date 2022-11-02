using MassTransit;
using Messaging.Abstract;
using Messaging.Concrete;
using Microsoft.Extensions.Logging;
using Restaurant.Booking.Models;
using Restaurant.Messages.Abstract;
using Restaurant.Messages.InMemoryDb;

namespace Restaurant.Booking.Consumers;

public class RestaurantBookingRequestConsumer : IConsumer<IBookingRequest>
{
    private readonly ILogger _logger;
    private readonly MdaRestaurant.Models.Restaurant _restaurant;
    private readonly IInMemoryRepository<BookingRequestModel> _repository;

    public RestaurantBookingRequestConsumer(
        MdaRestaurant.Models.Restaurant restaurant, 
        IInMemoryRepository<BookingRequestModel> repository,
        ILogger<RestaurantBookingRequestConsumer> logger)
    {
        _restaurant = restaurant;
        _repository = repository;
        _logger = logger;
    }

    public async Task Consume(ConsumeContext<IBookingRequest> context)
    {
        _logger.LogInformation($"[OrderId: {context.Message.OrderId}]");

        var model = _repository.Get().FirstOrDefault(i => i.OrderId == context.Message.OrderId);

        if (model is not null && model.CheckMessageId(context.MessageId.ToString()))
        {
            _logger.LogDebug("Second time message");
            return;
        }
        var requestModel = new BookingRequestModel(context.Message.OrderId, context.Message.ClientId,
            context.Message.PreOrder, context.Message.CreationDate, context.MessageId.ToString());

        _logger.LogDebug("First time message");
        var resultModel = model?.Update(requestModel, context.MessageId.ToString()) ?? requestModel;
        _repository.AddOrUpdate(resultModel);
        var result = await _restaurant.BookFreeTableAsync(1);

        await context.Publish<ITableBooked>(new TableBooked(context.Message.OrderId, result ?? false));
    }
}