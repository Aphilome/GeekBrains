using Timesheets.Data.Dto;
using Timesheets.Data.Entities;

namespace Timesheets.Services.Abstracts
{
    public interface IContractService
    {
        Task<Contract> Create();

        Task<Contract> Get(long id);

        Task<ICollection<Contract>> GetAll();

        Task Update(long id, ContractDto contractDto);

        Task Remove(long id);
    }
}
