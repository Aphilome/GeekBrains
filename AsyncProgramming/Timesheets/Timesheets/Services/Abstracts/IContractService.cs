using Timesheets.Data.Entities;

namespace Timesheets.Services.Abstracts
{
    public interface IContractService
    {
        Task<Contract> CreateAsync();

        Task<Contract?> GetAsync(long id);

        Task<IReadOnlyCollection<Contract>> GetAllAsync();

        Task UpdateAsync(long id, Contract contractNew);

        Task RemoveAsync(long id);
    }
}
