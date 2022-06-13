using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Data.DddInvoice;

namespace Timesheets.Data.Entities
{
    /// <summary>
    /// Клиент
    /// </summary>
    public class Client : BaseEntity
    {
        /// <summary>
        /// Имя клиента
        /// </summary>
        public string? Name { get; set; }

        public long? InvoiceId { get; set; }

        /// <summary>
        /// Выставленный счет
        /// </summary>
        [ForeignKey(nameof(InvoiceId))]
        public Invoice? Invoice { get; set; }
    }
}
