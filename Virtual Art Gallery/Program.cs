using System.Xml.Serialization;
using Virtual_Art_Gallery.VirtualArtGallery;

namespace Virtual_Art_Gallery
{
    internal class Program
    {
        static void Main(string[] args)
        {
            VirtualGallery virtualGallery = new VirtualGallery();
            virtualGallery.HandleMenu();
        }
    }
}
