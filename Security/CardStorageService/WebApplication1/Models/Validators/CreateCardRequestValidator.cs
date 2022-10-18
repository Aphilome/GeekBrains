using CardStorageService.Models.Requests;
using FluentValidation;
using System;

namespace CardStorageService.Models.Validators
{
    public class CreateCardRequestValidator : AbstractValidator<CreateCardRequest>
    {
        public CreateCardRequestValidator()
        {
            RuleFor(i => i.ClientId)
                .GreaterThan(0);

            RuleFor(i => i.CardNo)
                .NotEmpty();

            RuleFor(i => i.Name)
                .NotEmpty();
            
            RuleFor(i => i.CVV2)
                .NotEmpty();

            RuleFor(i => i.ExpDate)
                .GreaterThan(DateTime.UtcNow);
        }
    }
}
