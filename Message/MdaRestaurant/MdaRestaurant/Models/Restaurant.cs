using MdaRestaurant.Enums;

namespace MdaRestaurant.Models;

internal class Restaurant
{
    private readonly List<Table> _tables = new();
    private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

    public Restaurant()
	{
		for (ushort i = 1; i <= 10; i++)
			_tables.Add(new Table(i));
	}

    /// <summary>
    /// Via phon calling
    /// </summary>
    /// <param name="countOfPersons"></param>
    public void BookFreeTable(int countOfPersons)
    {
        Console.WriteLine("Hi! I will check the table and approve booking, please be in line");

        Table? table;
        _lock.Wait();
        try
        { 
            table = _tables.FirstOrDefault(i => i.SeatsCount > countOfPersons && i.State == Enums.State.Free);
            table?.SetState(State.Booked);
            Thread.Sleep(5000); // so slow managers
        }
        finally
        {
            _lock.Release();
        }

        Console.WriteLine(table is null
            ? "Sorry, we havn't free tables"
            : $"Done! You table number is {table.Id}");
    }

    /// <summary>
    /// Via messenger
    /// </summary>
    /// <param name="countOfPersons"></param>
    public void BookFreeTableAsync(int countOfPersons)
    {
        Console.WriteLine("Hi! I will check the table and approve booking.  You will get notification");

        Task.Run(async () =>
        {
            Table? table;
            await _lock.WaitAsync();
            try
            {
                table = _tables.FirstOrDefault(i => i.SeatsCount > countOfPersons && i.State == Enums.State.Free);
                table?.SetState(State.Booked);
                await Task.Delay(5000); // so slow managers
            }
            finally
            {
                _lock.Release();
            }

            Console.WriteLine(table is null
                ? "NOTIFICATION: Sorry, we havn't free tables"
                : $"NOTIFICATION: Done! You table number is {table.Id}");
        });
    }
}
