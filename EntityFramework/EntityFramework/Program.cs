using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFramework
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=studenten;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

            SqlConnection connection = new SqlConnection(connectionString);

            Console.WriteLine("Wat is je naam?");
            string name = Console.ReadLine();

            SqlCommand command = new SqlCommand("select * from Student3 where Naam='" + name + "'", connection);
            // Met parameters in command kan je de kwetsbaarheden opvangen om het risico op sql injection te verminderen

            //Open de connectie naar de database
            connection.Open();
            //Execute the command
            SqlDataReader reader = command.ExecuteReader();
            // Iterate over all returned rows
            while (reader.Read())
            {
                Console.WriteLine(reader[1]);
            }

            // nooit vergeten: de opkuis te doen, de connecties te sluiten
            reader.Close();
            connection.Close();

            Console.ReadLine();
        }
    }
}
