namespace ConsoleAppLearnADO.SqlDatabase;
public class MySqlDatabase
{
    private MySqlConnection connection;

    public MySqlDatabase(string server, string user, string password, string database)
    {
        string connectionString = $"server={server};user={user};password={password};database={database};";
        connection = new MySqlConnection(connectionString);
    }

    public void ProcessCommand(string command)
    {
        switch (command.ToLower())
        {
            case "create":
                CreateData.Create(connection);
                break;
            case "delete":
                DeleteRow.Delete(connection);
                break;
            case "get":
                GetRow.Get(connection);
                break;
            case "list":
                ListData.List(connection);
                break;
            case "exit":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid command.");
                break;
        }
    }
}
