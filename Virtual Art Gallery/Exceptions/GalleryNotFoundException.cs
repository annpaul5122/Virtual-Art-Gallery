using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Utility;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class GalleryNotFoundException : Exception
    {
        static SqlConnection connect = null;
        static SqlCommand cmd = null;
        static GalleryNotFoundException()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }

        public GalleryNotFoundException(string message) : base (message)
        {

        }

        private static bool GalleryIdExists(int GalleryId)
        {
            int count = 0;
            cmd.CommandText = "Select count(*) as total from GALLERY where GalleryID = @gallery_id";
            cmd.Parameters.AddWithValue("@gallery_id", GalleryId);
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
        public static void GalleryNotFound(int galleryId)
        {
            if (!GalleryIdExists(galleryId))
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                throw new UserNotFoundException("Gallery Id not found");
            }
        }
    }
}
