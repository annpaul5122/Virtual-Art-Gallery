using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    public class Artwork
    {
        public int ArtworkID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public string Medium { get; set; }
        public string ImageURL { get; set; }
        public int? ArtistId { get; set; }
        public Artwork()
        {
            
        }

        public Artwork(int artworkId,string title,string description,DateTime date,string medium,string image,int artistId)
        {
            ArtworkID= artworkId;
            Title= title;
            Description= description;
            CreationDate= date;
            Medium=medium;
            ImageURL= image;
            ArtistId= artistId;
        }

        public override string ToString()
        {
            return $"Id::{ArtworkID}   Title::{Title}   Description::{Description}   Creation::{CreationDate}   Medium::{Medium}   Image::{ImageURL}   Artist Id::{ArtistId}";
        }
    }
}
