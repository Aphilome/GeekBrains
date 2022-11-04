using Microsoft.Data.Sqlite;

namespace Restaurant.Messages.SqlliteDb;

public class MessagesRepository : IMessagesRepository
{
    private static string _connectionString = "Data Source=msg_db.db;";
    private static System.Timers.Timer _timer;

    private static readonly string _createTableCommand = @"CREATE TABLE IF NOT EXISTS PROCESSED_MESSAGE(SUBSCIBER_ID UUID,
            MSG_ID UUID, CREATED_DATE DATETIME, PRIMARY KEY (SUBSCIBER_ID, MSG_ID))";

    public MessagesRepository()
    {
        using var con = new SqliteConnection(_connectionString);
        {
            con.Open();

            using var cmd = new SqliteCommand(_createTableCommand, con);

            cmd.ExecuteNonQuery();
        }
        _timer = new System.Timers.Timer(30 * 1000);
        _timer.AutoReset = true;
        _timer.Enabled = true;
        _timer.Elapsed += async (sender, e) => await HandleTimer();
        _timer.Start();
    }

    public async Task<bool> InsertMessageSuccess(Guid subsciberId, Guid msgId)
    {
        try
        {
            using var con = new SqliteConnection(_connectionString);
            {
                con.Open();

                using var cmd = new SqliteCommand(InsertMessageCommand(subsciberId, msgId), con);
                await cmd.ExecuteNonQueryAsync();
            }
            return true;
        }
        catch(Exception)
        {
            Console.WriteLine($"Dublicate! '{subsciberId}','{msgId}'");
            return false;
        }
    }

    private string InsertMessageCommand(Guid subsciberId, Guid msgId)
        => $"INSERT INTO PROCESSED_MESSAGE(SUBSCIBER_ID, MSG_ID, CREATED_DATE) VALUES('{subsciberId}','{msgId}', '{DateTime.UtcNow}')";

    private static async Task HandleTimer()
    {
        Console.WriteLine("Timer cleaning...");
        using var con = new SqliteConnection(_connectionString);
        {
            con.Open();

            using var cmd = new SqliteCommand($"DELETE FROM PROCESSED_MESSAGE WHERE CREATED_DATE < '{DateTime.UtcNow.AddSeconds(-30)}'", con);
            await cmd.ExecuteNonQueryAsync();
        }
    }
}

