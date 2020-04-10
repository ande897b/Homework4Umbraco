using ClassLibrary;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.WebSockets.Internal;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace Homework4Umbraco.Data
{
    public class DBInitializer
    {
        public static void Initialize(Homework4UmbracoContext context)
        {
          
            

            context.Database.EnsureCreated();
            string[] lines = File.ReadAllLines(@"SerialNumbers.txt"); //Loads Serialnumbers from .txt

            foreach (string line in lines)
            {
                context.SerialNumber.Add(new SerialNumber { SerialNumberID = line.ToString() });
                SerialNumberController.AddSerialNumber(new SerialNumber { SerialNumberID = line.ToString() });
            }
          
            
           
            

            if (context.SerialNumber.Any() && context.Participant.Any())
            {
                LoadFromDB();
                return;   // DB has been seeded
            }
            context.SaveChanges();

        }
        public static void LoadFromDB()
        {
            List<String> columnData = new List<String>();
            var conn_string = "Server=(localdb)\\mssqllocaldb;Database=Homework4UmbracoContext-795d9d9d-4a24-4747-9160-e1378d933fa1;Trusted_Connection=True;MultipleActiveResultSets=true";
            using (SqlConnection connection = new SqlConnection(conn_string))
            {
                connection.Open();
                string query = "SELECT * FROM dbo.Participant";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int ID = (int)reader["ID"];
                            string FirstName = reader["FirstName"].ToString();
                            string LastName = reader["LastName"].ToString();
                            string Email = reader["Email"].ToString();
                            string SerialNumberID = reader["SerialNumberID"].ToString();
                            Participant participant = new Participant {ID=ID, FirstName=FirstName,LastName= LastName,Email= Email,SerialNumberID= SerialNumberID };
                            ParticipantController.AddParticipant(participant);
                        }
                    }
                }
            }
           

        }               
            
        
    }  
   
}