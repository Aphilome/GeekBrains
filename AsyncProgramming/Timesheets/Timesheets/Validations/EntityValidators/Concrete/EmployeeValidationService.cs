using FluentValidation;
using Timesheets.Data.Entities;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class EmployeeValidationService : FluentValidationService<Employee>, IEmployeeValidationService
    {
        public EmployeeValidationService()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .Length(3, 50)
                .Must(i => i.All(char.IsLetter)).WithMessage("Only letters");

            RuleFor(i => i.Grade)
                .IsInEnum();

            RuleFor(i => i.Rate)
                .InclusiveBetween(1m, decimal.MaxValue);
        }
    }
}
