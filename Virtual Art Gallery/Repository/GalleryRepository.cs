using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Utility;

namespace Virtual_Art_Gallery.Repository
{
    public class GalleryRepository : IVirtualArtGallery
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public GalleryRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool addArtwork(Artwork artwork)
        {
            int status = 0;
            try
            {
                cmd.CommandText = "Insert into GALLERY values (@title,@description,@date,@medium,@image,@id)";
                cmd.Parameters.AddWithValue("@title", artwork.Title);
                cmd.Parameters.AddWithValue("@description", artwork.Description);
                cmd.Parameters.AddWithValue("@date", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@medium", artwork.Medium);
                cmd.Parameters.AddWithValue("@image", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@id", artwork.ArtistId);
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
            if (status > 0)
            {
                return true;
            }
            return false;
        }

        public bool updateArtwork(Artwork artwork)
        {
            int status = 0;
            try
            {
                cmd.CommandText = "Update ARTWORK set Title=@Title,Description=@Desc,CreationDate=@Date,Medium=@med,ImageURL=@url,ArtistID=@a_id where ArtworkID=@art_id";
                cmd.Parameters.AddWithValue("@art_id", artwork.ArtworkID);
                cmd.Parameters.AddWithValue("@Title", artwork.Title);
                cmd.Parameters.AddWithValue("@Desc", artwork.Description);
                cmd.Parameters.AddWithValue("@Date", artwork.CreationDate);
                cmd.Parameters.AddWithValue("@med", artwork.Medium);
                cmd.Parameters.AddWithValue("@url", artwork.ImageURL);
                cmd.Parameters.AddWithValue("@a_id", artwork.ArtistId);
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
            if (status > 0)
            {
                return true;
            }
            return false;
        }

        public bool removeArtwork(int artworkId)
        {
            int status = 0;
            try
            {
                cmd.CommandText = "Delete from ARTWORK where ArtworkID=@artworkId";
                cmd.Parameters.AddWithValue("@artworkId", artworkId);
                connect.Open();
                cmd.Connection = connect;
                status = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
                if (status > 0)
                {
                    return true;
                }
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
            return false;
        }

        public Artwork getArtworkById(int artworkId)
        {
            Artwork artwork = new Artwork();
            try
            {
                cmd.CommandText = "Select * from ARTWORK where ArtworkID=@artwork_id";
                cmd.Parameters.AddWithValue("@artwork_id", artworkId);
                connect.Open();
                cmd.Connection = connect;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                while (reader.Read())
                {
                    artwork.ArtworkID = (int)reader["ArtworkID"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageURL = (string)reader["ImageURL"];
                    artwork.ArtistId = Convert.IsDBNull(reader["ArtistID"]) ? null : (int)reader["ArtistID"];
                }
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message );
            }
            return artwork;
        }

        public List<Artwork> searchArtworks()
        {
            List<Artwork> artworks = new List<Artwork>();
            try
            {
                cmd.CommandText = "Select * from ARTWORK";
                connect.Open();
                cmd.Connection = connect;
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    Artwork artwork = new Artwork();
                    artwork.ArtworkID = (int)reader["ArtworkID"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageURL = (string)reader["ImageURL"];
                    artwork.ArtistId = Convert.IsDBNull(reader["ArtistID"]) ? null : (int)reader["ArtistID"];
                    artworks.Add(artwork);
                }
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message );
            }
            return artworks;
        }

        public bool addArtworkToFavorite(int userId, int artworkId)
        {
            int updateStatus =0,insertStatus =0;
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "Update [USER] set FavoriteArtworks=@art_id where UserID=@userId";
                cmd.Parameters.AddWithValue("@userId", userId);
                cmd.Parameters.AddWithValue("@art_id", artworkId);
                updateStatus = cmd.ExecuteNonQuery();
                cmd.CommandText = "Insert into USER_FAVORITE_ARTWORK values (@user_Id,@artw_ID)";
                cmd.Parameters.AddWithValue("@user_Id", userId);
                cmd.Parameters.AddWithValue("@artw_ID", artworkId);
                insertStatus = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message );
            }
            if (updateStatus > 0 && insertStatus > 0)
            {
                return true;
            }
            return false;
        }

        public bool removeArtworkFromFavorite(int userId, int artworkId)
        {
            int status1=0, status2 = 0;
            try
            {
                connect.Open();
                cmd.Connection = connect;
                cmd.CommandText = "Update [USER] set FavoriteArtworks = NULL where UserID=@user_ID";
                cmd.Parameters.AddWithValue("@user_ID", userId);
                status1 = cmd.ExecuteNonQuery();
                cmd.CommandText = "Delete from USER_FAVORITE_ARTWORK where ArtworkID=@a_Id and UserID=@u_id";
                cmd.Parameters.AddWithValue("@a_Id", artworkId);
                cmd.Parameters.AddWithValue("@u_id", userId);
                status2 = cmd.ExecuteNonQuery();
                cmd.Parameters.Clear();
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message );
            }
            if (status1 > 0 && status2 > 0)
            {
                return true;
            }
            return false;
        }

        public List<Artwork> getUserFavoriteArtworks(int userId)
        {
            List<Artwork> favArtworks = new List<Artwork>();
            try
            {
                cmd.CommandText = "Select * from ARTWORK a join USER_FAVORITE_ARTWORK u on a.ArtworkID=u.ArtworkID where u.UserID=@user";
                cmd.Parameters.AddWithValue("@user", userId);
                connect.Open();
                cmd.Connection = connect;
                SqlDataReader reader = cmd.ExecuteReader();
                cmd.Parameters.Clear();
                while (reader.Read())
                {
                    Artwork artwork = new Artwork();
                    artwork.ArtworkID = (int)reader["ArtworkID"];
                    artwork.Title = (string)reader["Title"];
                    artwork.Description = (string)reader["Description"];
                    artwork.CreationDate = (DateTime)reader["CreationDate"];
                    artwork.Medium = (string)reader["Medium"];
                    artwork.ImageURL = (string)reader["ImageURL"];
                    artwork.ArtistId = Convert.IsDBNull(reader["ArtistID"]) ? null : (int)reader["ArtistID"];
                    favArtworks.Add(artwork);
                }
                connect.Close();
            }
            catch(SqlException ex)
            {
                Console.WriteLine(ex.Message );
            }
            return favArtworks;
        }

    }
}
