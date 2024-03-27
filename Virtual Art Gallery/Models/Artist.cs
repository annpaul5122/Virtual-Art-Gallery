using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Virtual_Art_Gallery.Models
{
    internal class Artist
    {
        public int ArtistID { get; set; }
        public string Name { get; set; }
        public string Biography { get; set; }
        public DateTime BirthDate { get; set; }
        public string Nationality { get; set; }
        public string Website { get; set; }
        public string ContactInformation { get; set; }

        public Artist()
        {
            
        }

        public Artist(int id,string name,string bio,DateTime dob,string nationality,string website,string contactinfo)
        {
            ArtistID = id;
            Name = name;
            Biography = bio;
            BirthDate = dob;
            Nationality = nationality;
            Website = website;
            ContactInformation = contactinfo;
        }

        public override string ToString()
        {
            return $"Id::{ArtistID}   Name::{Name}   Biography::{Biography}   DOB::{BirthDate}   Nationality::{Nationality}   Website::{Website}   Contact::{ContactInformation}";
        }
    }
}
