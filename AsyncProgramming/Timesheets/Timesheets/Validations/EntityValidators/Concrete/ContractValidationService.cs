using FluentValidation;
using Timesheets.Data.Entities;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class ContractValidationService : FluentValidationService<Contract>, IContractValidationService
    {
        public ContractValidationService()
        {
            RuleFor(i => i.Number)
                .InclusiveBetween(1ul, ulong.MaxValue);

            RuleFor(i => i.CreatedDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.SignDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.Status)
                .IsInEnum();
        }
    }
}
