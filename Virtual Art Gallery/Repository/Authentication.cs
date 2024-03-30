using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Virtual_Art_Gallery.Utility;
using Virtual_Art_Gallery.Models;

namespace Virtual_Art_Gallery.Repository
{
    internal class Authentication
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;
        public Authentication()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public bool Login(string username,string password)
        {
            int count = 0;
            try
            {
                cmd.CommandText = "Select count(*) as match from [USER] where Username = @userName and Password = @pwd";
                cmd.Parameters.AddWithValue("@userName", username);
                cmd.Parameters.AddWithValue("@pwd", password);
                connect.Open();
                cmd.Connection = connect;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                while (reader.Read())
                {
                    count = (int)reader["match"];
                }
                connect.Close();
                
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (count > 0)
                return true;
            return false;
        }

        public bool Register(User user)
        {
            int status = 0;
            try
            {
                cmd.CommandText = "Insert into [USER] values (@username,@password,@email,@fname,@lname,@dob,@profile)";
                cmd.Parameters.AddWithValue("@username", user.Username);
                cmd.Parameters.AddWithValue("@password", user.Username);
                cmd.Parameters.AddWithValue("@email", user.Username);
                cmd.Parameters.AddWithValue("@fname", user.Username);
                cmd.Parameters.AddWithValue("@lname", user.Username);
                cmd.Parameters.AddWithValue("@dob", user.Username);
                cmd.Parameters.AddWithValue("@profile", user.ProfilePicture);
                connect.Open();
                cmd.Connection = connect;
                status = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (status>0)
                return true;
            return false;
        }
    }
}
