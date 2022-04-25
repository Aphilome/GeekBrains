using Timesheets.Data.Dto;
using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class ContractService : IContractService
    {
        public async Task<Contract> Create()
        {
            return new Contract();
        }

        public async Task<Contract> Get(long id)
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<Contract>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task Remove(long id)
        {
            throw new NotImplementedException();
        }

        public async Task Update(long id, ContractDto contractDto)
        {
            throw new NotImplementedException();
        }
    }
}
