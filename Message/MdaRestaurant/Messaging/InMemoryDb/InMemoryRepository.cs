using Restaurant.Messages.Abstract;
using System.Collections.Concurrent;

namespace Restaurant.Messages.InMemoryDb;

public class InMemoryRepository<T> : IInMemoryRepository<T> 
    where T : IWithCreatedDate
{
    private static readonly ConcurrentBag<T> _repo = new();
    private static System.Timers.Timer aTimer;

    public InMemoryRepository()
    {
        aTimer = new System.Timers.Timer(30 * 1000);
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        aTimer.Elapsed += async (sender, e) => await HandleTimer();
        aTimer.Start();
    }

    public void AddOrUpdate(T entity)
    {
        _repo.Add(entity);
    }

    public IEnumerable<T> Get()
    {
        return _repo;
    }

    private static async Task HandleTimer()
    {
        Console.WriteLine("Timer cleaning memory...");

        _repo.Clear();
    }
}