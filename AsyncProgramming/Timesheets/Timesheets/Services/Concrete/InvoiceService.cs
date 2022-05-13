using Timesheets.Data.Entities;
using Timesheets.Services.Abstracts;

namespace Timesheets.Services.Concrete
{
    public class InvoiceService : BaseService<Invoice>, IInvoiceService
    {
        public InvoiceService(IRepository repository)
            : base(repository)
        {
        }
    }
}
