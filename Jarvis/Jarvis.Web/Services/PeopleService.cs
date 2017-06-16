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
        } //GetPeople

        public Person GetPersonById(int id)
        {
            Person row = null;

            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            //establish connection
            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                // establlish command object
                using (SqlCommand cmd = new SqlCommand("dbo.People_GetById", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

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

                        if (row == null)
                        {
                            row = p;
                        }
                    }

                }
            }
            return row;
        } //GetPersonById

        public int CreatePerson(Person payload)
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
                    cmd.Parameters.AddWithValue("@FirstName", payload.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", payload.LastName);
                    cmd.Parameters.AddWithValue("@Phone", payload.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", payload.Email);

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
        } //CreatePerson

        public void UpdatePerson(Person payload)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.People_Update", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", payload.Id);
                    cmd.Parameters.AddWithValue("@FirstName", payload.FirstName);
                    cmd.Parameters.AddWithValue("@LastName", payload.LastName);
                    cmd.Parameters.AddWithValue("@Phone", payload.PhoneNumber);
                    cmd.Parameters.AddWithValue("@Email", payload.Email);

                    sqlConn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeletePerson(int id)
        {
            string connString = System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;

            using (SqlConnection sqlConn = new SqlConnection(connString))
            {
                using (SqlCommand cmd = new SqlCommand("dbo.People_Delete", sqlConn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@ID", id);

                    sqlConn.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        } //DeletePerson
    }
}