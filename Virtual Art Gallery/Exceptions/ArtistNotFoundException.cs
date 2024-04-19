using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Utility;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class ArtistNotFoundException : Exception
    {
        static SqlConnection connect = null;
        static SqlCommand cmd = null;
        static ArtistNotFoundException()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public ArtistNotFoundException(string message) : base(message)
        {

        }

        private static bool ArtistIdExists(int? artistId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from ARTIST where ArtistID = @artistId";
            cmd.Parameters.AddWithValue("@artistId", artistId);
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
        public static void ArtistNotFound(int? artistId)
        {
            if (!ArtistIdExists(artistId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                throw new UserNotFoundException("Artist Id not found");
            }
        }
    }
}
