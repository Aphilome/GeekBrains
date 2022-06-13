using FluentValidation;
using Timesheets.Data.Entities;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class JobTaskValidationService : FluentValidationService<JobTask>, IJobTaskValidationService
    {
        public JobTaskValidationService()
        {
            RuleFor(i => i.CreatedDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.StartDate)
                .InclusiveBetween(DateTime.MinValue, DateTime.UtcNow);

            RuleFor(i => i.Status)
                .IsInEnum();

            RuleFor(i => i.Name)
                .NotEmpty()
                .Length(3, 50)
                .Must(i => i.All(char.IsLetter)).WithMessage("Only letters");
            
            RuleFor(i => i.Description)
                .Length(0, 200);

            RuleFor(i => i.SpendTime)
                .InclusiveBetween(1m, decimal.MaxValue);

            RuleFor(i => i.Pay)
                .InclusiveBetween(1m, decimal.MaxValue);
        }
    }
}
