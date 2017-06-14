using Jarvis.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace Jarvis.Web.Services
{
    public class PeopleService
    {
        public List<Person> GetPeople()
        {
            List<Person> peopleList = new List<Person>();

            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            
            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.People_GetAll", sqlConn))
                {
                    sqlConn.Open();
                    SqlDataReader reader = cmd.ExecuteReader(System.Data.CommandBehavior.CloseConnection);
                    while (reader.Read())
                    {
                        Person p = new Person();
                        int startingIndex = 0;

                        //reading data from db
                        p.Id = reader.GetInt32(startingIndex++);
                        p.FirstName = reader.GetString(startingIndex++);
                        p.LastName = reader.GetString(startingIndex++);
                        p.PhoneNumber = reader.GetString(startingIndex++);
                        p.Email = reader.GetString(startingIndex++);

                        peopleList.Add(p);
                    }

                }
            }
            return peopleList;
        }
    }
}