using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Задача
    /// </summary>
    public class JobTask : BaseEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public JobTaskStatusEnum Status { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string? Name { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// Затраченное время
        /// </summary>
        public decimal SpendTime { get; set; }

        /// <summary>
        /// Стоимость
        /// </summary>
        public decimal Pay { get; set; }

        public long? EmployeeId { get; set; }

        /// <summary>
        /// Работник
        /// </summary>
        [ForeignKey(nameof(EmployeeId))]
        public Employee? Employee { get; set; }

        public long? ContractId { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }
    }
}
