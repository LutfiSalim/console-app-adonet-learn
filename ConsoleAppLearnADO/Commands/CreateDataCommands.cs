namespace ConsoleAppLearnADO;
public class CreateData
{
    public static void Create(MySqlConnection connection)
    {
        string userId = Guid.NewGuid().ToString("ID"); // generate a new UUID for the UserID field
        Console.Write("Enter the FullName: ");
        string fullName = Console.ReadLine();
        Console.Write("Enter the Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter the Password: ");
        string password = Console.ReadLine();

        string insertQuery = "INSERT INTO User (UserID, FullName, Username, Password) VALUES (@UserID, @FullName, @Username, @Password);";
        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
        insertCommand.Parameters.AddWithValue("@UserID", userId);
        insertCommand.Parameters.AddWithValue("@FullName", fullName);
        insertCommand.Parameters.AddWithValue("@Username", username);
        insertCommand.Parameters.AddWithValue("@Password", password);

        try
        {
            connection.Open();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");

            // Retrieve the generated UUID from the database
            string selectQuery = "SELECT UserID FROM User WHERE UserID = @UserID;";
            MySqlCommand selectCommand = new MySqlCommand(selectQuery, connection);
            selectCommand.Parameters.AddWithValue("@UserID", userId);

            string selectedUserId = (string)selectCommand.ExecuteScalar();
            Console.WriteLine($"Generated User ID: {selectedUserId}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }
        finally
        {
            connection.Close();
        }
    }
}
