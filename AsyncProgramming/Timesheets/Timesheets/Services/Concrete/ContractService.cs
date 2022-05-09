using System.Collections.Generic;
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

        public async Task<Contract> CreateAsync()
        {
            var contract = new Contract();
            await _repository.AddAsync<Contract>(contract);
            return contract;
        }

        public async Task<Contract?> GetAsync(long id)
        {
            return await _repository.GetAsync<Contract>(id);
        }

        public async Task<IReadOnlyCollection<Contract>> GetAllAsync()
        {
            return await _repository.GetAllAsync<Contract>();
        }

        public async Task RemoveAsync(long id)
        {
            await _repository.RemoveAsync<Contract>(id);
        }

        public async Task UpdateAsync(long id, Contract contractNew)
        {
            await _repository.UpdateAsync<Contract>(id, contractNew);
        }
    }
}
