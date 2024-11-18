using MySql.Data.MySqlClient;
using Testing_Api_Service.Settings;

namespace Testing_Api_Service.Repository
{
    public class TestRunsRepository
    {
        public void LogTestExecutionTime(string topic, string response)
        {

            using (var conn = new MySqlConnection(ApiSettings.MysqlConnectionString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connection to MySQL database successful!");

                    using (var cmd = new MySqlCommand(
                        @"CREATE TABLE IF NOT EXISTS prophecy(
                            topic varchar(20) NOT NULL,
                            response varchar(200)
                        );", conn))
                    {
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"CREATE TABLE prophecy result, rows affected: {result}");
                    }

                    using (var cmd = new MySqlCommand(@"INSERT INTO prophecy(topic, response)	VALUES (@topic, @response);", conn))
                    {
                        cmd.Parameters.AddWithValue("@topic", topic);
                        cmd.Parameters.AddWithValue("@response", response);
                        string result = cmd.ExecuteNonQuery().ToString();

                        Console.WriteLine($"INSERT INTO prophecy, rows affected: {result}");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"LogTestExecutionTime Error: {ex.Message}");
                }
            }
        }
    }
}
