    class Program
    {
        static void Main(string[] args)
        {
            string server = "localhost";
            string user = "myusername";
            string password = "mypassword";
            string database = "mydatabase";
            MySqlDatabase db = new MySqlDatabase(server, user, password, database);

            while (true)
            {
                Console.Write("Enter a command (create, delete, get, list, exit): ");
                string command = Console.ReadLine();
                db.ProcessCommand(command);
            Environment.Exit(0);
        }
        }
    }

    


