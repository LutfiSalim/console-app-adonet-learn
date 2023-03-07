namespace ConsoleAppLearnADO.Commands;
 public class DeleteRow
{
    public static void Delete(MySqlConnection connection)
    {
        Console.Write("Enter the UserID to delete: ");
        string userIdToDelete = Console.ReadLine();

        string deleteQuery = "DELETE FROM User WHERE UserID = @UserIdToDelete;";
        MySqlCommand deleteCommand = new MySqlCommand(deleteQuery, connection);
        deleteCommand.Parameters.AddWithValue("@UserIdToDelete", userIdToDelete);

        try
        {
            connection.Open();
            int rowsAffected = deleteCommand.ExecuteNonQuery();
            Console.WriteLine($"Rows affected: {rowsAffected}");
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
