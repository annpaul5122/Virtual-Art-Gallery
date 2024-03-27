using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    internal class User
    {
        public int UserID { get; set; } 
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string ProfilePicture { get; set; }
        public int? FavoriteArtworks { get; set; }

        public User(int id,string userName,string pwd,string email,string fname,string lname,DateTime dob,string picture,int favArtwork)
        {
            UserID = id;
            Username=userName;
            Password = pwd;
            Email = email;
            FirstName = fname;
            LastName = lname;
            DateOfBirth = dob;
            ProfilePicture = picture;
            FavoriteArtworks = favArtwork;
        }

        public User()
        {
            
        }

        public override string ToString()
        {
            return $"Id::{UserID}   Username::{Username}   Password::{Password}   Email::{Email}   FirstName::{FirstName}   LastName::{LastName}   DOB::{DateOfBirth}   Profile::{ProfilePicture}   FavArtwork::{FavoriteArtworks}";
        }
    }
}
