using System;
using System.Data.SqlClient;

public class DatabaseConnection
{
    private readonly string _connectionString;

    public DatabaseConnection()
    {
        _connectionString = @"Data Source=DESKTOP-EAONQ68; Initial Catalog=military; Integrated Security=True";
    }

    public SqlConnection GetConnection()
    {
        SqlConnection connection = new SqlConnection(_connectionString);
        connection.Open();
        return connection;
    }
}
