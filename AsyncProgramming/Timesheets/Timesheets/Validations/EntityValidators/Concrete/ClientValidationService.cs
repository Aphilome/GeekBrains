using FluentValidation;
using Timesheets.Data.Entities;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class ClientValidationService : FluentValidationService<Client>, IClientValidationService
    {
        public ClientValidationService()
        {
            RuleFor(i => i.Name)
                .NotEmpty()
                .Length(3, 50)
                .Must(i => i.All(char.IsLetter)).WithMessage("Only letters");
        }
    }
}
