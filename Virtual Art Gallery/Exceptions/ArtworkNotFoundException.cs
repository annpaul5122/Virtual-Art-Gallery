using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class ArtworkNotFoundException : Exception
    {
        public ArtworkNotFoundException(string message):base(message)
        {
            
        }

        public static void ArtworkNotFound(int artworkId)
        {
           GalleryRepository repository = new GalleryRepository();
           if(!repository.ArtworkIdExists(artworkId))
           {
                throw new ArtworkNotFoundException("Artwork Id not found");
           }
        }
    }
}
