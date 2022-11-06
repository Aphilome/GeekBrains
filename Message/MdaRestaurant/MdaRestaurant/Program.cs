using MdaRestaurant.Models;
using System.Diagnostics;

var rest = new Restaurant();

while (true)
{
    Console.WriteLine("Hi! What do you want?\n" +
        "1 - New booking\n" +
        "2 - Cancel old booking");
    if (!int.TryParse(Console.ReadLine(), out var choice) || choice is not (1 or 2))
    {
        Console.WriteLine("Please, write 1 or 2");
        continue;
    }
    if (choice == 1)
        TryBook();
    else
        TryCancel();
}


void TryBook()
{
    Console.WriteLine("Would you book table?\n" +
        "1 - you will get notification (async)\n" +
        "2 - be on line, we will say you (sync)");
    if (!int.TryParse(Console.ReadLine(), out var choice) || choice is not (1 or 2))
    {
        Console.WriteLine("Please, write 1 or 2");
        return;
    }

    var sw = new Stopwatch();
    sw.Start();
    if (choice == 1)
        rest.BookFreeTableAsync(1);
    else
        rest.BookFreeTable(1);

    Console.WriteLine("Thank you!");
    sw.Stop();

    var ts = sw.Elapsed;
    Console.WriteLine($"Booking: {ts.Seconds:00}:{ts.Milliseconds:00}");
}

void TryCancel()
{
    Console.WriteLine("Would you cancel booking?\n" +
        "1 - you will get notification (async)\n" +
        "2 - be on line, we will say you (sync)");
    if (!int.TryParse(Console.ReadLine(), out var choice) || choice is not (1 or 2))
    {
        Console.WriteLine("Please, write 1 or 2");
        return;
    }
    Console.WriteLine("What the table id you want cancel?");
    if (!int.TryParse(Console.ReadLine(), out var tableId) || tableId <= 0)
    {
        Console.WriteLine("Please, write correct table id");
        return;
    }
    var sw = new Stopwatch();
    sw.Start();
    if (choice == 1)
        rest.CancelBookinkgAsync(tableId);
    else
        rest.CancelBookinkg(tableId);

    Console.WriteLine("Thank you!");
    sw.Stop();

    var ts = sw.Elapsed;
    Console.WriteLine($"Canceling: {ts.Seconds:00}:{ts.Milliseconds:00}");
}
