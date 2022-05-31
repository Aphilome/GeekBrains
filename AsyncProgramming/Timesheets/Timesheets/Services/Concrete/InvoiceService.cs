using Timesheets.Data.DddInvoice;
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
