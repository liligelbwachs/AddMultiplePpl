using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace AddPerson.Models
{
    public class People
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
    }
    public class PeopleManager
    {
        private string _connectionString;

        public PeopleManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddPerson(People p)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            
                cmd.CommandText = "INSERT INTO People VALUES (@firstName, @lastName, @age)";
                cmd.Parameters.AddWithValue("@firstName", p.FirstName);
                cmd.Parameters.AddWithValue("@lastName", p.LastName);
                cmd.Parameters.AddWithValue("@age", p.Age);
            
            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public IEnumerable<People> GetAllPeople()
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People";

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            List<People> people = new List<People>();

            while (reader.Read())
            {
                people.Add(new People
                {
                    FirstName = (string)reader["FirstName"],
                    LastName = (string)reader["LastName"],
                    Age = (int)reader["Age"],
                    Id = (int)reader["Id"]
                });

            }

            return people;
        }

        public void DeletePerson(int Id)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "DELETE From People WHERE people.Id = @Id";

            cmd.Parameters.AddWithValue("@Id", Id);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public void EditPerson(People p)
        {
            SqlConnection conn = new SqlConnection(_connectionString);
            SqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = "UPDATE People SET FirstName = @firstName, " +
                              "LastName = @lastName, Age = @age WHERE Id = @id";

            cmd.Parameters.AddWithValue("@id", p.Id);
            cmd.Parameters.AddWithValue("@firstName", p.FirstName);
            cmd.Parameters.AddWithValue("@lastName", p.LastName);
            cmd.Parameters.AddWithValue("@age", p.Age);

            conn.Open();
            cmd.ExecuteNonQuery();
            conn.Close();
            conn.Dispose();
        }

        public People SelectPerson(int? id)
        {
            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand cmd = connection.CreateCommand();
            cmd.CommandText = "SELECT * FROM People where Id = @id";

            cmd.Parameters.AddWithValue("@id", id);
            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            People person = new People();
            while (reader.Read())
            {
                person.FirstName = (string)reader["FirstName"];
                person.LastName = (string)reader["LastName"];
                person.Age = (int)reader["Age"];
                person.Id = (int)reader["Id"];

            }
            return person;
        }
    }
}

