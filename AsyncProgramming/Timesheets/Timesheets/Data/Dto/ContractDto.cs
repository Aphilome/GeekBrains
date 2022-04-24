using System;
namespace Timesheets.Data.Dto
{
    public class ContractDto
    {
        public long Id { get; set; }

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
    }
}
