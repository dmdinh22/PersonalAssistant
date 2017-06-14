using Jarvis.Web.Models.ViewModels;
using System.Collections.Generic;
using System.Data.SqlClient;
using System;

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

        public int CreatePerson(Person model)
        {

            int idOutput = 0;
            // setting connection string to a variable
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.People_Create", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@FirstName", model.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", model.LastName);
                    cmd.Parameters.AddWithValue("@Phone", model.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", model.Email);

                    SqlParameter param = new SqlParameter();
                    param.ParameterName = "@id";
                    param.SqlDbType = System.Data.SqlDbType.Int;
                    param.Direction = System.Data.ParameterDirection.Output;
                    cmd.Parameters.Add(param);

                    // open SQL connection
                    sqlConn.Open();
                    
                    // for insert or update statements
                    cmd.ExecuteNonQuery();// takes total number of rows that are affected

                    idOutput = (int)cmd.Parameters["@id"].Value;
                }
            }

            return idOutput;
        }
    }
}