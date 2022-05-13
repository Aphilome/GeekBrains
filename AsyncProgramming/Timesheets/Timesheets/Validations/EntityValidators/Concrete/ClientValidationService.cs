using Timesheets.Data.Entities;
using Timesheets.Validations.EntityValidators.Abstract;

namespace Timesheets.Validations.EntityValidators.Concrete
{
    internal sealed class ClientValidationService : FluentValidationService<Client>, IClientValidationService
    {
        //private readonly IUserService _userService;

        public ClientValidationService(/*IUserService userService*/)
        {
            //_userService = userService;

            //RuleFor(x => x.FirstName)
            //.NotEmpty()
            //.WithMessage("Имя не должно быть пустым")
            //.WithErrorCode("BRL-100.1");
            //RuleFor(x => x.LastName)
            //.NotEmpty()
            //.WithMessage("Фамилия не должна быть пустым")
            //.WithErrorCode("BRL-100.2");
            //RuleFor(x => x.MiddleName)
            //.NotEmpty()
            //.WithMessage("Отчество не должно быть пустым")
            //.WithErrorCode("BRL-100.3");
            //RuleFor(x => x.FirstName).Custom((s, context) =>
            //{
            //    if (_userService.IsUserNameAlreadyExist(s))
            //    {
            //        context.AddFailure(new ValidationFailure(
            //        nameof(User.FirstName), "Пользователь уже существует")
            //        {
            //            ErrorCode = "BRL-100.4"
            //        });
            //    }
            //});
        }
    }
}
