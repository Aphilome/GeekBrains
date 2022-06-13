using FluentValidation;
using Timesheets.Data.DddInvoice;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class InvoiceValidationService : FluentValidationService<Invoice>, IInvoiceValidationService
    {
        public InvoiceValidationService()
        {
            RuleFor(i => i.CreatedDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.PayDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.Status)
                .IsInEnum();

            RuleFor(i => i.Sum)
                .InclusiveBetween(1m, decimal.MaxValue);

            RuleFor(i => i.AccountNumber)
                .InclusiveBetween(1ul, ulong.MaxValue);
        }
    }
}
