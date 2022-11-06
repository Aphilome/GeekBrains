using MdaRestaurant.Enums;

namespace MdaRestaurant.Models;

internal class Restaurant
{
    private readonly static List<Table> _tables = new();
    private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

    public Restaurant()
	{
		for (ushort i = 1; i <= 10; i++)
			_tables.Add(new Table(i));
    }

    public async Task<bool?> BookFreeTableAsync(int countOfPersons)
    {
        Console.WriteLine("Hi! I will check the table and approve booking. You will get notification");

        Table? table;
        await _lock.WaitAsync();
        try
        {
            table = _tables.FirstOrDefault(i => i.SeatsCount > countOfPersons && i.State == Enums.State.Free);
            await Task.Delay(5000); // so slow managers
            return table?.SetState(State.Booked);
        }
        finally
        {
            _lock.Release();
        }
    }

    public async Task CancelBookinkgAsync(int tableId)
    {
        Console.WriteLine("Hi! I will check the booking and cancel it. You will get notification");
        await _lock.WaitAsync();
        string msg;
        try
        {
            var table = _tables.FirstOrDefault(i => i.Id == tableId);
            if (table is null)
                msg = $"NOTIFICATION: We don't have like table {tableId}";
            else
            {
                if (table.State == State.Booked)
                    msg = $"NOTIFICATION: Succuss freed {tableId}!";
                else
                    msg = $"NOTIFICATION: Table {tableId} already is free!";
            }
            await Task.Delay(5000); // so slow managers
        }
        finally
        {
            _lock.Release();
        }
        Console.WriteLine(msg);
    }
}
