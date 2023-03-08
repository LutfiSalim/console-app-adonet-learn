namespace ConsoleAppLearnADO;
public class CreateData
{
    public static void Create(MySqlConnection connection)
    {
        Console.Write("Enter the FullName: ");
        string fullName = Console.ReadLine();
        Console.Write("Enter the Username: ");
        string username = Console.ReadLine();
        Console.Write("Enter the Password: ");
        string password = Console.ReadLine();

        string insertQuery = "INSERT INTO User (FullName, Username, Password) VALUES (@FullName, @Username, @Password);";
        MySqlCommand insertCommand = new MySqlCommand(insertQuery, connection);
        insertCommand.Parameters.AddWithValue("@FullName", fullName);
        insertCommand.Parameters.AddWithValue("@Username", username);
        insertCommand.Parameters.AddWithValue("@Password", password);

        try
        {
            connection.Open();
            int rowsAffected = insertCommand.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");

            // Retrieve the generated ID from the database
            MySqlCommand selectCommand = new MySqlCommand(" SELECT UserID FROM User ;", connection);
            object generatedId = selectCommand.ExecuteScalar();
            if (generatedId != null && generatedId != DBNull.Value)
            {
                string userId = generatedId.ToString();
                Console.WriteLine($"Generated ID: {userId}");
            }
            else
            {
                Console.WriteLine("Failed to retrieve generated ID.");
            }
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
