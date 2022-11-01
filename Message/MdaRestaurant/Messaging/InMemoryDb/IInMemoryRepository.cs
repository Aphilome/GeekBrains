using Restaurant.Messages.Abstract;

namespace Restaurant.Messages.InMemoryDb;

public interface IInMemoryRepository<T>
    where T : IWithCreatedDate
{
    public void AddOrUpdate(T entity);

    public IEnumerable<T> Get();
}