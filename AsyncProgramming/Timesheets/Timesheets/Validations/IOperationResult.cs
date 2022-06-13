using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public interface IOperationResult<T>
        where T : BaseEntity
    {
        T Result { get; }

        IReadOnlyList<IOperationFailure> Failures { get; }

        bool Succeed { get; }
    }
}
