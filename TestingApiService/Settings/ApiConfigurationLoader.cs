namespace Testing_Api_Service.Settings;
public class ApiConfigurationLoader
{
    public static void LoadConfiguration()
    {
        ApiSettings.PauseBetweenFailures = 3;
        ApiSettings.ClientTimeoutSeconds = 15;
        ApiSettings.BaseUrl = "http://localhost:3000/";
        ApiSettings.MaxRetryAttempts = 3;
        ApiSettings.EnableBDDLogging = true;
        ApiSettings.EnableToastMessages = true;
        ApiSettings.MysqlConnectionString = "Server=db; database=testingapi; UID=root; password=root";
    }

}
