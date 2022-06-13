using Timesheets.Data.Entities;

namespace Timesheets.Services.Abstracts
{
    public interface IRepository
    {
        Task AddAsync<T>(T entity)
            where T : BaseEntity;

        Task<T?> GetAsync<T>(long id)
            where T : BaseEntity;

        Task<IReadOnlyCollection<T>> GetAllAsync<T>()
            where T : BaseEntity;

        Task RemoveAsync<T>(long id)
            where T : BaseEntity;

        Task UpdateAsync<T>(long id, T contractNew)
            where T : BaseEntity;
    }
}
