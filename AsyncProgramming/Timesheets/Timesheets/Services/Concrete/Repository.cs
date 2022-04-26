using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class Repository : IRepository
    {
        private readonly ICollection<BaseEntity> _db = new List<BaseEntity>()
        {
            new Contract()
            {
                Id = 1,
                Number = 1213,
            },
            new Contract()
            {
                Id = 2,
                Number = 456343,
            },
            new Contract()
            {
                Id = 3,
                Number = 2234235,
            },
            new Contract()
            {
                Id = 4,
                Number = 435632412,
            },
        };

        public async Task<T> Create<T>()
            where T : BaseEntity, new()
        {
            var entity = new T();
            _db.Add(entity);

            return entity;
        }

        public async Task<T> Get<T>(long id)
            where T : BaseEntity
        {
            return (T)_db.First(i => i.Id == id);
        }

        public async Task<ICollection<T>> GetAll<T>()
            where T : BaseEntity
        {
            return _db.OfType<T>().ToArray();
        }

        public async Task Remove<T>(long id)
            where T : BaseEntity
        {
            _db.Remove(await Get<T>(id));
        }

        public async Task Update<T>(long id, T contractNew)
            where T : BaseEntity
        {
            var entity = await Get<T>(id);
            await Remove<T>(id);
            contractNew.Id = id;
            _db.Add(entity);
        }
    }
}
