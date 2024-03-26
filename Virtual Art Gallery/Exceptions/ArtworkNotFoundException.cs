using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Utility;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class ArtworkNotFoundException : Exception
    {
        static SqlConnection connect = null;
        static SqlCommand cmd = null;
        static ArtworkNotFoundException()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public ArtworkNotFoundException(string message):base(message)
        {
            
        }

        private static bool ArtworkIdExists(int artworkId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from ARTWORK where ArtworkID = @art_id";
            cmd.Parameters.AddWithValue("@art_id", artworkId);
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
        public static void ArtworkNotFound(int artworkId)
        {
           if(!ArtworkIdExists(artworkId))
           {
                throw new ArtworkNotFoundException("Artwork Id not found");
           }
        }
    }
}
