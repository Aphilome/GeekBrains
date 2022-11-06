namespace MdaRestaurant.Bl;

internal class Notificator
{
    public async Task SendNotificationAsync(string message)
    {
        await Task.Delay(1000); // creating message simulation

        Console.WriteLine($"PUSH: {message}");
    }
}
