using Timesheets.Data.Entities;

namespace Timesheets.Validations
{
    public class OperationResult<T> : IOperationResult<T>
        where T : BaseEntity
    {
        public T Result { get; set; }

        public IReadOnlyList<IOperationFailure> Failures { get; set; }

        public bool Succeed => Failures.Count == 0;
    }
}
