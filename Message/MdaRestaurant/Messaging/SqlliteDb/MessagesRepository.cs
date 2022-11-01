using Microsoft.Data.Sqlite;

namespace Restaurant.Messages.SqlliteDb;

public class MessagesRepository : IMessagesRepository
{
    private string _connectionString = "Data Source=msgdb.db;";

    public MessagesRepository()
    {
        using var con = new SqliteConnection(_connectionString);
        con.Open();

        using var cmd = new SqliteCommand(@"CREATE TABLE IF NOT EXISTS PROCESSED_MESSAGE(SUBSCIBER_ID UUID,
            MSG_ID UUID, PRIMARY KEY (SUBSCIBER_ID, MSG_ID))");

        cmd.ExecuteNonQuery();
    }

    public async Task<bool> InsertMessageSuccess(Guid subsciberId, Guid msgId)
    {
        try
        {
            using var cmd = new SqliteCommand($"INSERT INTO PROCESSED_MESSAGE(SUBSCIBER_ID, MSG_ID) VALUES('{subsciberId}','{msgId}')");
            await cmd.ExecuteNonQueryAsync();
            return true;
        }
        catch(Exception)
        {
            Console.WriteLine($"Dublicate! '{subsciberId}','{msgId}'");
            return false;
        }
    }

}

