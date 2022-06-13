using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class ContractService : BaseService<Contract>, IContractService
    {
        public ContractService(IRepository repository)
            : base(repository)
        {
        }
    }
}
