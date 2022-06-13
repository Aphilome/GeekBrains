using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class JobTaskService : BaseService<JobTask>, IJobTaskService
    {
        public JobTaskService(IRepository repository)
            : base(repository)
        {
        }
    }
}
