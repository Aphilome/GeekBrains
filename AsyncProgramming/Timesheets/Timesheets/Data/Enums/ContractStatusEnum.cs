namespace Timesheets.Data.Enums
{
    /// <summary>
    /// Статусы договора
    /// </summary>
    public enum ContractStatusEnum
    {
        /// <summary>
        /// Черновик
        /// </summary>
        Draft = 0,

        /// <summary>
        /// На рассмотрении
        /// </summary>
        OnCheck = 1,

        /// <summary>
        /// На доработке
        /// </summary>
        Rework = 2,

        /// <summary>
        /// Отклонена
        /// </summary>
        Reject = 3,

        /// <summary>
        /// Подписана
        /// </summary>
        Signed = 4,
    }
}
