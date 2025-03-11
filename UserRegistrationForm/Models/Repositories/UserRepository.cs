using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using UserRegistrationForm.Models;

namespace UserRegistrationForm.Models.Repositories
{
	public class UserRepository
	{
		private readonly SqlConnection sqlConnection;

        public UserRepository()
		{
            string connectionString = ConfigurationManager.ConnectionStrings["UserConnection"].ToString();
            sqlConnection = new SqlConnection(connectionString);
        }

        public bool AddUser(User user)
        {
            using (SqlCommand command = new SqlCommand("sp_InsertUser", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", user.Email);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@State", user.State);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();
                return rowsAffected > 0;

            }
        }

        public List<User> GetAllUsers()
        {
            List<User> userList = new List<User>();
            using (SqlCommand command = new SqlCommand("sp_GetAllUsers", sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                sqlConnection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        User user = new User
                        {
                            Id = Convert.ToInt32(reader["Id"]),
                            FirstName = reader["FirstName"].ToString(),
                            LastName = reader["LastName"].ToString(),
                            DateOfBirth = Convert.ToDateTime(reader["DateOfBirth"]),
                            Gender = reader["Gender"].ToString(),
                            PhoneNumber = reader["PhoneNumber"].ToString(),
                            Email = reader["EmailAddress"].ToString(),
                            Address = reader["Address"].ToString(),
                            State = reader["State"].ToString(),
                            City = reader["City"].ToString(),
                            Username = reader["Username"].ToString(),


                        };
                        userList.Add(user);
                    }

                }
                sqlConnection.Close();

            }
            return userList;
        }

        public bool UpdateUser(User user)
        {
            using (SqlCommand command =new SqlCommand("sp_UpdateUser",sqlConnection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", user.Id);
                command.Parameters.AddWithValue("@FirstName", user.FirstName);
                command.Parameters.AddWithValue("@LastName", user.LastName);
                command.Parameters.AddWithValue("@DateOfBirth", user.DateOfBirth);
                command.Parameters.AddWithValue("@Gender", user.Gender);
                command.Parameters.AddWithValue("@PhoneNumber", user.PhoneNumber);
                command.Parameters.AddWithValue("@EmailAddress", user.Email);
                command.Parameters.AddWithValue("@Address", user.Address);
                command.Parameters.AddWithValue("@State", user.State);
                command.Parameters.AddWithValue("@City", user.City);
                command.Parameters.AddWithValue("@Username", user.Username);
                command.Parameters.AddWithValue("@Password", user.Password);

                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();
                return rowsAffected > 0;
            }
        }

        public bool DeleteUser(int id)
        {
            using(SqlCommand command= new SqlCommand("sp_DeleteUser", sqlConnection))
            {
                command.CommandType=CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@UserId", id);

                sqlConnection.Open();
                int rowsAffected = command.ExecuteNonQuery();
                sqlConnection.Close();
                return rowsAffected > 0;

            }
        }


    }
}