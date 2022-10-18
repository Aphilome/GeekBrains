using CardStorageService.Models.Requests;
using FluentValidation;

namespace CardStorageService.Models.Validators
{
    public class AuthenticationRequestValidator : AbstractValidator<AuthenticationRequest>
    {
        public AuthenticationRequestValidator()
        {
            RuleFor(i => i.Login)
                .NotNull()
                .Length(5, 255)
                .EmailAddress();
            
            RuleFor(i => i.Password)
                .NotNull()
                .Length(5, 50);
        }
    }
}
