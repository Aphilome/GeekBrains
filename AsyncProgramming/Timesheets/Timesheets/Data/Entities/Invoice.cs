using Timesheets.Data.Enums;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Счет
    /// </summary>
    public class Invoice
    {
        public long Id { get; set; }

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
        public ulong AccauntNumber { get; set; }

        /// <summary>
        /// Клиент
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Договор
        /// </summary>
        public Contract Contract { get; set; }
    }
}
