using Microsoft.EntityFrameworkCore;
using Timesheets.Data;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class Repository : IRepository
    {
        private readonly TimesheetsDbContext _dbContext;
        
        public Repository(TimesheetsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task AddAsync<T>(T entity)
            where T : BaseEntity
        {
            await _dbContext.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<T?> GetAsync<T>(long id)
            where T : BaseEntity
        {
            return await _dbContext.FindAsync<T>(id);
        }

        public async Task<IReadOnlyCollection<T>> GetAllAsync<T>()
            where T : BaseEntity
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        public async Task RemoveAsync<T>(long id)
            where T : BaseEntity
        {
            _dbContext.Remove(id);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAsync<T>(long id, T entityNew)
            where T : BaseEntity
        {
            if (entityNew is null)
                return;
            var entity = await GetAsync<T>(id);
            if (entity is null)
                return;
            _dbContext.Entry(entity).CurrentValues.SetValues(entityNew);
            await _dbContext.SaveChangesAsync();
        }
    }
}
