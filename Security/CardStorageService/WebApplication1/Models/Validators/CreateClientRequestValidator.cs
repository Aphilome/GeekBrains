using CardStorageService.Models.Requests;
using FluentValidation;

namespace CardStorageService.Models.Validators
{
    public class CreateClientRequestValidator: AbstractValidator<CreateClientRequest>
    {
        public CreateClientRequestValidator()
        {
            RuleFor(i => i.Surname)
                .NotEmpty();

            RuleFor(i => i.FirstName)
                .NotEmpty();
        }
    }
}
