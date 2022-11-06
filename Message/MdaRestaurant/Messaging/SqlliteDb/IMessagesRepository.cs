namespace Restaurant.Messages.SqlliteDb;

public interface IMessagesRepository
{
    Task<bool> InsertMessageSuccess(Guid subsciberId, Guid msgId);
}
