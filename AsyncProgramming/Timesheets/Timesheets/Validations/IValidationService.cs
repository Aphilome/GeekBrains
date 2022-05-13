using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public interface IValidationService<T>
        where T : BaseEntity
    {
        IReadOnlyList<IOperationFailure> ValidateEntity(T item);
    }

}
