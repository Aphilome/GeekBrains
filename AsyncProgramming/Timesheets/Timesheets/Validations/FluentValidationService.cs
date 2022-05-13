using FluentValidation;
using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public abstract class FluentValidationService<T> : AbstractValidator<T>, IValidationService<T>
        where T : BaseEntity
    {
        public IReadOnlyList<IOperationFailure> ValidateEntity(T item)
        {
            var result = Validate(item);
            if (result is null || result.Errors.Count == 0)
            {
                return ArraySegment<IOperationFailure>.Empty;
            }

            var failures = new List<IOperationFailure>(result.Errors.Count);
            foreach (var error in result.Errors)
            {
                failures.Add(new OperationFailure
                {
                    PropertyName = error.PropertyName,
                    Description = error.ErrorMessage,
                    Code = error.ErrorCode
                });
            }
            return failures;
        }
    }
}
