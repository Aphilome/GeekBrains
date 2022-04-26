using Timesheets.Data.Entities;

namespace Timesheets.Services.Abstracts
{
    public interface IRepository
    {
        Task<T> Create<T>() 
            where T : BaseEntity, new();

        Task<T> Get<T>(long id)
            where T : BaseEntity;

        Task<ICollection<T>> GetAll<T>()
            where T : BaseEntity;

        Task Remove<T>(long id)
            where T : BaseEntity;

        Task Update<T>(long id, T contractNew)
            where T : BaseEntity;
    }
}
