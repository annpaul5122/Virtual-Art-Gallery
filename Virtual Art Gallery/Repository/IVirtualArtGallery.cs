using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;

namespace Virtual_Art_Gallery.Repository
{
    internal interface IVirtualArtGallery
    {
        bool addArtwork(Artwork artwork);
        bool updateArtwork(Artwork artwork);
        bool removeArtwork(int artworkId);

        Artwork getArtworkById(int artworkId);

        List<Artwork> searchArtworks();

        bool addArtworkToFavorite(int userId, int artworkId);
        bool removeArtworkFromFavorite(int userId, int artworkId);

        int? getUserFavoriteArtworks(int userId);

    }
}
