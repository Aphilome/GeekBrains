using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Задача
    /// </summary>
    public class JobTask
    {
        public long Id { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public JobTaskStatusEnum Status { get; set; }

        /// <summary>
        /// Название задачи
        /// </summary>
        public string Name { get; set; }
        
        /// <summary>
        /// Описание
        /// </summary>
        public string Description { get; set; }

        /// <summary>
        /// Затраченное время
        /// </summary>
        public decimal SpendTime { get; set; }

        /// <summary>
        /// Работник
        /// </summary>
        public Employee Employee { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        public Contract Contract { get; set; }
    }
}
