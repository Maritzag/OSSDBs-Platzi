using System;
using Npgsql;

namespace POSGRESQL
{
    class Program
    {
        static void Main(string[] args)
        {
            string connString = "Server=serverpostgresqltest.postgres.database.azure.com;Database=RRHHDB;Port=5432;User Id=myadmin@serverpostgresqltest;Password=P4ssw.rd123;SSLMode=Prefer;";
            using (var conn = new NpgsqlConnection(connString))

            {
                Console.Out.WriteLine("Opening connection");
                conn.Open();

                using (var command = conn.CreateCommand())
                {
                                       

                    command.CommandText = @"INSERT INTO empleados (id, nombre, salario, fecha_nacimiento) 
                    VALUES (@id1, @nombre1, @salario1, @fecha_nacimiento1);";
                    command.Parameters.AddWithValue("@id1", 32);
                    command.Parameters.AddWithValue("@nombre1", "Jairo  Rodriguez");
                    command.Parameters.AddWithValue("@salario1", 2300);
                    command.Parameters.AddWithValue("@fecha_nacimiento1", new DateTime(1994,11,02));

                    int rowCount =  command.ExecuteNonQuery();
                    Console.WriteLine(String.Format("Number of rows inserted={0}", rowCount));
                }
            }

            Console.WriteLine("Press RETURN to exit");
            Console.ReadLine();
        }
    }
}
