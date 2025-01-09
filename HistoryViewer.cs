using System;
using System.Data.SqlClient;

class ToDoList
{
    static void Main()
    {
        string connectionString = 
"Server=YOUR_SERVER;Database=TasksDB;User Id=USER;Password=PASSWORD;";
        string query = "SELECT TaskID, Description, DueDate, IsCompleted 
FROM Tasks";

        using (SqlConnection connection = new 
SqlConnection(connectionString))
        {
            try
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(query, 
connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    Console.WriteLine("To-Do List:");
                    while (reader.Read())
                    {
                        string status = (bool)reader["IsCompleted"] ? 
"Completed" : "Pending";
                        Console.WriteLine($"ID: {reader["TaskID"]}, Task: 
{reader["Description"]}, Due: {reader["DueDate"]}, Status: {status}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}

