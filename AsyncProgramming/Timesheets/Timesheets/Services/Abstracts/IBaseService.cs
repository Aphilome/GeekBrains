using Timesheets.Data.Entities;

namespace Timesheets.Services.Abstracts
{
    public interface IBaseService<T>
        where T : BaseEntity, new()
    {
        Task<T> CreateAsync();

        Task<T?> GetAsync(long id);

        Task<IReadOnlyCollection<T>> GetAllAsync();

        Task UpdateAsync(long id, T entityNew);

        Task RemoveAsync(long id);
    }
}
