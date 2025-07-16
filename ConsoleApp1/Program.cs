using Microsoft.Data.SqlClient;
using System;

using DemoAsync;

class Program
{
    static void Main(string[] args)
    {
        //DisPlay("");

        string connectionString = "server=localhost; database=test; uid=sa; pwd=admin@12345;Encrypt=True;TrustServerCertificate=True;";

        // 建立连接
        using (SqlConnection connection = new SqlConnection(connectionString))
        {
            try
            {
                // 打开连接
                connection.Open();

                // 添加数据
                Console.WriteLine("1. 插入数据：");
                InsertData(connection, "user", "John", "123456");

                // 查询数据
                Console.WriteLine("\n2. 查询数据：");
                RetrieveData(connection, "user");

                // 更新数据
                Console.WriteLine("\n3. 更新数据：");
                UpdateData(connection, "user", "John", "456789");

                // 查询更新后的数据
                Console.WriteLine("\n4. 查询更新后的数据：");
                RetrieveData(connection, "user");

                // 删除数据
                Console.WriteLine("\n5. 删除数据：");
                DeleteData(connection, "user", "John");

                // 查询删除后的数据
                Console.WriteLine("\n6. 查询删除后的数据：");
                RetrieveData(connection, "user");
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"SQL Error: {ex.Message}");
            }
            finally
            {
                connection.Close();
            }
        }
    }

    // 插入数据
    static void InsertData(SqlConnection connection, string tableName, string username, string password)
    {
        string insertQuery = $"INSERT INTO [{tableName}] (username, password) VALUES (@Username, @Password)";
        using (SqlCommand command = new SqlCommand(insertQuery, connection))
        {
            command.Parameters.AddWithValue("@Username", username);
            command.Parameters.AddWithValue("@Password", password);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} 行受影响。");
        }
    }

    // 查询数据
    static void RetrieveData(SqlConnection connection, string tableName)
    {
        string selectQuery = $"SELECT * FROM [{tableName}]";
        using (SqlCommand command = new SqlCommand(selectQuery, connection))
        using (SqlDataReader reader = command.ExecuteReader())
        {
            while (reader.Read())
            {
                Console.WriteLine($"username: {reader["username"]},  password: {reader["password"]}");
            }
        }
    }

    // 更新数据
    static void UpdateData(SqlConnection connection, string tableName, string username, string newPassword)
    {
        string updateQuery = $"UPDATE [{tableName}] SET password = @NewPassword WHERE username = @Username";
        using (SqlCommand command = new SqlCommand(updateQuery, connection))
        {
            command.Parameters.AddWithValue("@NewPassword", newPassword);
            command.Parameters.AddWithValue("@Username", username);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} 行受影响。");
        }
    }

    // 删除数据
    static void DeleteData(SqlConnection connection, string tableName, string username)
    {
        string deleteQuery = $"DELETE FROM [{tableName}] WHERE username = @Username";
        using (SqlCommand command = new SqlCommand(deleteQuery, connection))
        {
            command.Parameters.AddWithValue("@Username", username);
            int rowsAffected = command.ExecuteNonQuery();
            Console.WriteLine($"{rowsAffected} 行受影响。");
        }
    }
}
