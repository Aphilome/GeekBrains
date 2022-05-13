using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public abstract class BaseService<T> : IBaseService<T>
        where T : BaseEntity, new()
    {
        private readonly IRepository _repository;

        public BaseService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<T> CreateAsync()
        {
            var entity = new T();
            await _repository.AddAsync<T>(entity);
            return entity;
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync()
        {
            return await _repository.GetAllAsync<T>();
        }

        public async Task<T?> GetAsync(long id)
        {
            return await _repository.GetAsync<T>(id);
        }

        public async Task RemoveAsync(long id)
        {
            await _repository.RemoveAsync<T>(id);
        }

        public async Task UpdateAsync(long id, T entityNew)
        {
            await _repository.UpdateAsync<T>(id, entityNew);
        }
    }
}
