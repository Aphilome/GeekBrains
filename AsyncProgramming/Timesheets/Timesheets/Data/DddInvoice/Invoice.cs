using System.ComponentModel.DataAnnotations.Schema;
using Timesheets.Data.Entities;
using Timesheets.Data.Enums;

namespace Timesheets.Data.DddInvoice
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

        public void Create(long contractId, decimal sum)
        {
            ContractId = contractId;
            Sum = sum;
            Status = InvoiceStatusEnum.Open;
        }

        public void SetAccaunt(ulong accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public void SendToClient(long clientId)
        {
            ClientId = clientId;
            Status = InvoiceStatusEnum.InProgress;
        }

        public void Pay()
        {
            PayDate = DateTime.Now;
            Status = InvoiceStatusEnum.Closed;
        }
    }
}
