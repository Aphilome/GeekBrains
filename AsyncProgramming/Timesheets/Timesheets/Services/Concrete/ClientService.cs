using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class ClientService : BaseService<Client>, IClientService
    {
        public ClientService(IRepository repository)
            : base(repository)
        {
        }
    }
}
