using FluentValidation;
using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public abstract class FluentValidationService<T> : AbstractValidator<T>, IValidationService<T>
        where T : BaseEntity
    {
        public IOperationResult<T> ValidateEntity(T item)
        {
            var validation = Validate(item);
            var res = new OperationResult<T>()
            {
                Result = item,
                Failures = ArraySegment<IOperationFailure>.Empty
            };
            if (validation is null || validation.Errors.Count == 0)
            {
                return res;
            }

            var failures = new List<IOperationFailure>(validation.Errors.Count);
            foreach (var error in validation.Errors)
            {
                failures.Add(new OperationFailure
                {
                    PropertyName = error.PropertyName,
                    Description = error.ErrorMessage,
                    Code = error.ErrorCode
                });
            }
            res.Failures = failures;
            return res;
        }
    }
}
