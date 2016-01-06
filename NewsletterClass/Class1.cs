using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Configuration;

namespace NewsletterClass
{
    public class Class1
    {
        public String Returner()
        {
            string myString = "Hello World";
            return myString;
        }

        public List<string> getDatafromDB()
        {
            List<string> playerName = new List<string>();
            var con = ConfigurationManager.ConnectionStrings["Player"].ConnectionString;

            using (SqlConnection connection = new SqlConnection(con)) { 
                
                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = "SELECT * FROM dbo.Player";
                command.CommandType = System.Data.CommandType.Text;

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    playerName.Add(reader["Name"].ToString());
                }
                foreach (string s in playerName)
                {
                    Console.WriteLine(s);   
                }
            }
            return playerName;
        }

        
    }
}
