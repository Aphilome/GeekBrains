using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Работник
    /// </summary>
    public class Employee
    {
        public long Id { get; set; }

        /// <summary>
        /// Имя работника
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Грейд
        /// </summary>
        public EmployeeGradeEnum Grade { get; set; }

        /// <summary>
        /// Рейт (стоимость / за час)
        /// </summary>
        public decimal Rate { get; set; }

        /// <summary>
        /// Задачи
        /// </summary>
        public ICollection<JobTask> Tasks { get; set; }
    }
}
