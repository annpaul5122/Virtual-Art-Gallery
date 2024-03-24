using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Repository;

namespace VirtualGalleryTest
{
    public class Tests
    {
        //Artwork Management

        [Test]
        public void AddArtwork()
        {
            GalleryRepository repository = new GalleryRepository();
            Artwork artwork = new Artwork()
            {
                Title = "Starry Night",
                Description = "Starry Night is a famous oil painting by Vincent van Gogh, created in June 1889. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an idealized village.",
                CreationDate = DateTime.Parse("1889-06-25"),
                Medium = "Oil on canvas",
                ImageURL = "https://example.com/Starry_night.jpg",
                ArtistId = 1
            };
            bool result = repository.addArtwork(artwork);
            Assert.That(result, Is.True);
        }

        [Test]
        public void UpdateArtwork()
        {
            GalleryRepository repository = new GalleryRepository();
            Artwork artwork = new Artwork()
            {
                ArtworkID = 9,
                Title = "Starry Night",
                Description = "Starry Night is a famous oil painting by Vincent van Gogh, created in June 1889. It depicts the view from the east-facing window of his asylum room at Saint-Rémy-de-Provence, just before sunrise, with the addition of an idealized village.",
                CreationDate = DateTime.Parse("1889-06-25"),
                Medium = "Oil on canvas",
                ImageURL = "https://example.com/Starry_night.jpg",
                ArtistId = 1
            };
            bool result = repository.updateArtwork(artwork);
            Assert.That(result, Is.True);
        }

        [TestCase(9)]

        public void RemoveArtwork(int artworkId)
        {
            GalleryRepository repository = new GalleryRepository();
            bool result = repository.removeArtwork(artworkId);
            Assert.That(result, Is.True);
        }

        [Test]

        public void SearchArtwork()
        {
            GalleryRepository repository = new GalleryRepository();
            List<Artwork> artworks = repository.searchArtworks();
            bool result = artworks == null || artworks.Count == 0;
            Assert.That(!result, Is.True);
        }

        //Gallery Management

        [Test]
        public void AddGallery()
        {
            GalleryManagementRepository repository = new GalleryManagementRepository();
            Gallery gallery = new Gallery()
            {
                Name = "Louvre Museum",
                Description = "The Louvre Museum, or simply the Louvre, is the world's largest art museum and a historic monument in Paris, France.",
                Location = "Paris",
                Curator = 2,
                OpeningHours = TimeSpan.Parse("10:30:00")
            };
            bool result = repository.AddGallery(gallery);
            Assert.That(result, Is.True);
        }

        [Test]
        public void UpdateGallery()
        {
            GalleryManagementRepository repository = new GalleryManagementRepository();
            Gallery gallery = new Gallery()
            {
                GalleryID = 6,
                Name = "Louvre Museum",
                Description = "The Louvre Museum, or simply the Louvre, is the world's largest art museum and a historic monument in Paris, France.",
                Location = "Paris",
                Curator = 3,
                OpeningHours = TimeSpan.Parse("10:30:00")
            };
            bool result = repository.UpdateGallery(gallery);
            Assert.That(result, Is.True);
        }

        [TestCase(6)]

        public void RemoveGallery(int galleryId)
        {
            GalleryManagementRepository repository = new GalleryManagementRepository();
            bool result = repository.RemoveGallery(galleryId);
            Assert.That(result, Is.True);
        }

        [Test]

        public void SearchGallery()
        {
            GalleryManagementRepository repository = new GalleryManagementRepository();
            List<Gallery> gallery = repository.searchGallery();
            bool result = gallery == null || gallery.Count == 0;
            Assert.That(!result, Is.True);
        }

    }
}