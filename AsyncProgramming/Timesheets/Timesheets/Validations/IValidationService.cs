using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public interface IValidationService<T>
        where T : BaseEntity
    {
        IOperationResult<T> ValidateEntity(T item);
    }

}
