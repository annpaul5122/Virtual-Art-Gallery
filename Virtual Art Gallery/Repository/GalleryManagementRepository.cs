﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Utility;

namespace Virtual_Art_Gallery.Repository
{
    public class GalleryManagementRepository
    {
        SqlConnection connect = null;
        SqlCommand cmd = null;

        public GalleryManagementRepository()
        {
            connect = new SqlConnection(DataConnectionUtility.GetConnectionString());
            cmd = new SqlCommand();
        }
        public bool AddGallery(Gallery gallery)
        {
            cmd.CommandText = "Insert into GALLERY values (@name,@description,@location,@curator,@time)";
            cmd.Parameters.AddWithValue("@name", gallery.Name);
            cmd.Parameters.AddWithValue("@description", gallery.Description);
            cmd.Parameters.AddWithValue("@location", gallery.Location);
            cmd.Parameters.AddWithValue("@curator", gallery.Curator);
            cmd.Parameters.AddWithValue("@time", gallery.OpeningHours);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
            {
                return true;
            }
            return false;
        }

        public bool UpdateGallery(Gallery gallery)
        {
            cmd.CommandText = "Update GALLERY set [Name]=@name,[Description]=@description,Location=@location,Curator=@curator,OpeningHours=@time where GalleryID=@id";
            cmd.Parameters.AddWithValue("@id",gallery.GalleryID);   
            cmd.Parameters.AddWithValue("@name", gallery.Name);
            cmd.Parameters.AddWithValue("@description", gallery.Description);
            cmd.Parameters.AddWithValue("@location", gallery.Location);
            cmd.Parameters.AddWithValue("@curator", gallery.Curator);
            cmd.Parameters.AddWithValue("@time", gallery.OpeningHours);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
            {
                return true;
            }
            return false;
        }

        public bool RemoveGallery(int galleryId)
        {
            cmd.CommandText = "Delete from GALLERY where GalleryID=@Id";
            cmd.Parameters.AddWithValue("@Id", galleryId);
            connect.Open();
            cmd.Connection = connect;
            int status = cmd.ExecuteNonQuery();
            cmd.Parameters.Clear();
            connect.Close();
            if (status > 0)
            {
                return true;
            }
            return false;
        }

        public List<Gallery> searchGallery()
        {
            List<Gallery> gallery = new List<Gallery>();
            cmd.CommandText = "Select * from GALLERY";
            connect.Open();
            cmd.Connection = connect;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Gallery gallery1 = new Gallery();
                gallery1.GalleryID = (int)reader["GalleryID"];
                gallery1.Name = (string)reader["Name"];
                gallery1.Description = (string)reader["Description"];
                gallery1.Location = (string)reader["Location"];
                gallery1.Curator = (int)reader["Curator"];
                gallery1.OpeningHours = (TimeSpan)reader["OpeningHours"];
                gallery.Add(gallery1);
            }
            connect.Close();
            return gallery;
        }
    }
}