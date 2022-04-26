using Timesheets.Data.Dto;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class ContractService : IContractService
    {
        private readonly IRepository _repository;

        public ContractService(IRepository repository)
        {
            _repository = repository;
        }

        public async Task<Contract> Create()
        {
            return await _repository.Create<Contract>();
        }

        public async Task<Contract> Get(long id)
        {
            return await _repository.Get<Contract>(id);
        }

        public async Task<ICollection<Contract>> GetAll()
        {
            return await _repository.GetAll<Contract>();
        }

        public async Task Remove(long id)
        {
            await _repository.Remove<Contract>(id);
        }

        public async Task Update(long id, Contract contractNew)
        {
            await _repository.Update<Contract>(id, contractNew);
        }
    }
}
