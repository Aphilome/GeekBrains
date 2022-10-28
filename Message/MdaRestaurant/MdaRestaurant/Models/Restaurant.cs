using MdaRestaurant.Enums;
using Messaging;

namespace MdaRestaurant.Models;

internal class Restaurant
{
    private readonly List<Table> _tables = new();
    private readonly SemaphoreSlim _lock = new SemaphoreSlim(1, 1);
    private readonly Producer _producer = new(RabbitMqQueues.BookingNotificationName);

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
            table = _tables.FirstOrDefault(i => i.SeatsCount > countOfPersons && i.State == State.Free);
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
        Task.Run(async () =>
        {
            _producer.Send("Hi! I will check the table and approve booking. You will get notification");

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

            _producer.Send(table is null
                ? "NOTIFICATION: Sorry, we havn't free tables"
                : $"NOTIFICATION: Done! You table number is {table.Id}");
        });
    }

    /// <summary>
    /// Via phon calling
    /// </summary>
    /// <param name="countOfPersons"></param>
    public void CancelBookinkg(int tableId)
    {
        Console.WriteLine("Hi! I will check the booking and cancel it, please be in line");

        _lock.Wait();
        string msg;
        try
        { 
            var table = _tables.FirstOrDefault(i => i.Id == tableId);
            if (table is null)
                msg = $"We don't have like table {tableId}";
            else
            {
                if (table.State == State.Booked)
                    msg = $"Succuss freed {tableId}!";
                else
                    msg = $"Table {tableId} already is free!";
            }
            Thread.Sleep(5000); // so slow managers
        }
        finally
        {
            _lock.Release();
        }
        Console.WriteLine(msg);
    }

    public void CancelBookinkgAsync(int tableId)
    {
        Task.Run(async () =>
        {
            _producer.Send("Hi! I will check the booking and cancel it. You will get notification");
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
            _producer.Send(msg);
        });
    }
}
