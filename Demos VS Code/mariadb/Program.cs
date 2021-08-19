using System;
using MySqlConnector;
using System.Threading.Tasks;

namespace mariadb
{
    class Program
    {
        static async Task Main(string[] args)
        {

            var builder = new MySqlConnectionStringBuilder
            {
                Server = "mariadbtestqa.mariadb.database.azure.com",
                Database = "RRHHDB",
                UserID = "myadmin@mariadbtestqa",
                Password = "P4ssw.rd123",
                SslMode = MySqlSslMode.None,
            };
            using (var conn = new MySqlConnection(builder.ConnectionString))
            {
                Console.WriteLine("Opening connection");
                await conn.OpenAsync();

                using (var command = conn.CreateCommand())
                {                    
                    command.CommandText = @"INSERT INTO empleados (id, nombre, salario, fecha_nacimiento) 
                    VALUES (@id1, @nombre1, @salario1, @fecha_nacimiento1);";
                    command.Parameters.AddWithValue("@id1", "32");
                    command.Parameters.AddWithValue("@nombre1", "Jairo  Rodriguez");
                    command.Parameters.AddWithValue("@salario1", "2300");
                    command.Parameters.AddWithValue("@fecha_nacimiento1", "1994-11-02");

                    int rowCount = await command.ExecuteNonQueryAsync();
                    Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                }

                // connection will be closed by the 'using' block
                Console.WriteLine("Closing connection");
            }

        }
    }
}
