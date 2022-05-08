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
        public string Name { get; set; }

        /// <summary>
        /// Выставленный счет
        /// </summary>
        public Invoice Invoice { get; set; }
    }
}
