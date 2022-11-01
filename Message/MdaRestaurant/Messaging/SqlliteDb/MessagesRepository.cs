using Microsoft.Data.Sqlite;
using System.Timers;

namespace Restaurant.Messages.SqlliteDb;

public class MessagesRepository : IMessagesRepository
{
    private static string _connectionString = "Data Source=msg_db.db;";
    private static System.Timers.Timer aTimer;

    public MessagesRepository()
    {
        using var con = new SqliteConnection(_connectionString);
        {
            con.Open();

            using var cmd = new SqliteCommand(@"CREATE TABLE IF NOT EXISTS PROCESSED_MESSAGE(SUBSCIBER_ID UUID,
            MSG_ID UUID, CREATED_DATE DATETIME, PRIMARY KEY (SUBSCIBER_ID, MSG_ID))", con);

            cmd.ExecuteNonQuery();
        }
        aTimer = new System.Timers.Timer(30 * 1000);
        aTimer.AutoReset = true;
        aTimer.Enabled = true;
        aTimer.Elapsed += async (sender, e) => await HandleTimer();
        aTimer.Start();
    }

    public async Task<bool> InsertMessageSuccess(Guid subsciberId, Guid msgId)
    {
        try
        {
            using var con = new SqliteConnection(_connectionString);
            {
                con.Open();

                using var cmd = new SqliteCommand($"INSERT INTO PROCESSED_MESSAGE(SUBSCIBER_ID, MSG_ID, CREATED_DATE) VALUES('{subsciberId}','{msgId}', '{DateTime.UtcNow}')", con);
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

