using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Repository;
using Virtual_Art_Gallery.Utility;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        static SqlConnection connect = null;
        static SqlCommand cmd = null;
        static UserNotFoundException()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public UserNotFoundException(string message) : base(message)
        {
            
        }

        private static bool UserIdExists(int userId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from [USER] where UserID = @user_id";
            cmd.Parameters.AddWithValue("@user_id", userId);
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            cmd.Parameters.Clear();
            while (reader.Read())
            {
                count = (int)reader["total"];
            }
            connect.Close();
            if (count > 0)
                return true;
            return false;
        }
        public static void UserNotFound(int userId)
        {
            if(!UserIdExists(userId))
            {
                throw new UserNotFoundException("User Id not found");
            }
        }
    }
}
