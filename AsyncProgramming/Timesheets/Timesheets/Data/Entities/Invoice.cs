using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Invoice : BaseEntity
    {
        /// <summary>
        /// Дата создания
        /// </summary>
        public DateTime CreatedDate { get; set; }

        /// <summary>
        /// Дата оплаты
        /// </summary>
        public DateTime PayDate { get; set; }

        /// <summary>
        /// Статус
        /// </summary>
        public InvoiceStatusEnum Status { get; set; }

        /// <summary>
        /// Сумма
        /// </summary>
        public decimal Sum { get; set; }

        /// <summary>
        /// Расчетный счет
        /// </summary>
        public ulong AccountNumber { get; set; }

        public long? ClientId { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        [ForeignKey(nameof(ClientId))]
        public Client? Client { get; set; }

        public long? ContractId { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        [ForeignKey(nameof(ContractId))]
        public Contract? Contract { get; set; }
    }
}
