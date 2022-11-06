using Restaurant.Messages.Abstract;
using System.Collections.Concurrent;

namespace Restaurant.Messages.InMemoryDb;

public class InMemoryRepository<T> : IInMemoryRepository<T> 
    where T : IWithCreatedDate
{
    private static readonly ConcurrentBag<T> _repo = new();
    private static System.Timers.Timer _timer;

    public InMemoryRepository()
    {
        _timer = new System.Timers.Timer(30 * 1000);
        _timer.AutoReset = true;
        _timer.Enabled = true;
        _timer.Elapsed += async (sender, e) => await HandleTimer();
        _timer.Start();
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