using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Data.DddInvoice;
using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Договор
    /// </summary>
    public class Contract : BaseEntity
    {
        /// <summary>
        /// Номер договора
        /// </summary>
        public ulong Number { get; set; }

        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }
        
        /// <summary>
        /// Дата подписания
        /// </summary>
        public DateTime SignDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public ContractStatusEnum Status { get; set; }

        public long? InvoiceId { get; set; }

        /// <summary>
        /// Высавляемый счет
        /// </summary>
        [ForeignKey(nameof(InvoiceId))]
        public Invoice? Invoice { get; set; }

        /// <summary>
        /// Задачи в рамках договора
        /// </summary>
        public ICollection<JobTask>? Tasks { get; set;}
    }
}
