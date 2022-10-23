using MdaRestaurant.Models;
using System.Diagnostics;

var rest = new Restaurant();

while (true)
{
    Console.WriteLine("Hi! Would you book table?\n1 - you will get notification (async)\n2 - be on line, we will say you (sync)");
    if (!int.TryParse(Console.ReadLine(), out var choice) || choice is not (1 or 2))
    {
        Console.WriteLine("Please, write 1 or 2");
        continue;
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
    Console.WriteLine($"{ts.Seconds:00}:{ts.Milliseconds:00}");
}