﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Exceptions;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Service
{
    internal class VirtualGalleryService
    {
        private readonly GalleryRepository _virtualgallery;

        public VirtualGalleryService()
        {
            _virtualgallery = new GalleryRepository();
        }

        public void addRecordsToArtwork(Artwork artwork)
        {
            if (_virtualgallery.addArtwork(artwork))
                Console.WriteLine("Insertion Successful");
            else
                Console.WriteLine("Insertion not successful. Try again!!!");
        }

        public void updateArtwork(Artwork artwork)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artwork.ArtworkID);
                if (_virtualgallery.updateArtwork(artwork))
                    Console.WriteLine("Updation successful");
                else
                    Console.WriteLine("Updation unsuccessful. Try again!!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeArtwork(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);
                if (_virtualgallery.removeArtwork(artworkId))
                    Console.WriteLine("Record has been deleted successfully");
                else
                    Console.WriteLine("Deletion unsuccessful.Try again!!!");
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getArtwork(int artworkId)
        {
            try
            {
                ArtworkNotFoundException.ArtworkNotFound(artworkId);
                Console.WriteLine(_virtualgallery.getArtworkById(artworkId));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void searchArtwork()
        {
            foreach(Artwork item in _virtualgallery.searchArtworks())
                Console.WriteLine(item);
        }

        public void addFavorite(int u_id,int a_id)
        {
            try
            {
                UserNotFoundException.UserNotFound(u_id);
                ArtworkNotFoundException.ArtworkNotFound(a_id);
                if (_virtualgallery.addArtworkToFavorite(u_id, a_id))
                    Console.WriteLine("Favorite artwork added successfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void removeFavorite(int u_id,int a_id) 
        {
            try
            {
                UserNotFoundException.UserNotFound(u_id);
                ArtworkNotFoundException.ArtworkNotFound(a_id);
                if (_virtualgallery.removeArtworkFromFavorite(u_id, a_id))
                    Console.WriteLine("Favorite artwork removed unsuccessfully");
                else
                    Console.WriteLine("Operation unsuccessful");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void getUserFavorite(int userId)
        {
            try
            {
                UserNotFoundException.UserNotFound(userId);
                Console.WriteLine(_virtualgallery.getUserFavoriteArtworks(userId));
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Handlemenu()
        {
            Console.WriteLine("Welcome to Virtual Art Gallery!!!\n\n");
            int choice = 0, choice2 = 0, choice3 = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Main Menu");
                Console.WriteLine("---------------");
                Console.WriteLine("Press 1: Artwork Management\nPress 2: User Favorite\nPress 3: Gallery Management\nPress 4: Exit\n\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        do
                        {
                            Console.WriteLine("Artwork Management");
                            Console.WriteLine("---------------------");
                            Console.WriteLine("1. Add Artwork\n2. Update Artwork\n3. Remove Artwork\n4. Get Artwork\n5. Search Artwork\n6. Exit\n");
                            Console.WriteLine("Enter your choice: ");
                            choice2 = int.Parse(Console.ReadLine());
                            Artwork artwork;
                            switch (choice2)
                            {
                                case 1:
                                    Console.WriteLine("Enter title: ");
                                    string title = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string desc = Console.ReadLine();
                                    Console.WriteLine("Enter creation date: ");
                                    string date = Console.ReadLine();
                                    Console.WriteLine("Enter medium: ");
                                    string medium = Console.ReadLine();
                                    Console.WriteLine("Enter image url: ");
                                    string url = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int artistId = int.Parse(Console.ReadLine());
                                    artwork = new Artwork() { Title = title, Description = desc, CreationDate = DateTime.Parse(date), Medium = medium, ImageURL = url, ArtistId = artistId };
                                    addRecordsToArtwork(artwork);
                                    break;

                                case 2:
                                    Console.WriteLine("Enter artwork id: ");
                                    int artId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter title: ");
                                    string u_title = Console.ReadLine();
                                    Console.WriteLine("Enter description: ");
                                    string u_desc = Console.ReadLine();
                                    Console.WriteLine("Enter creation date: ");
                                    string u_date = Console.ReadLine();
                                    Console.WriteLine("Enter medium: ");
                                    string u_medium = Console.ReadLine();
                                    Console.WriteLine("Enter image url: ");
                                    string u_url = Console.ReadLine();
                                    Console.WriteLine("Enter artist id: ");
                                    int u_artistId = int.Parse(Console.ReadLine());
                                    artwork = new Artwork(artId, u_title, u_desc, DateTime.Parse(u_date), u_medium, u_url, u_artistId);
                                    updateArtwork(artwork);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter artwork id: ");
                                    int a_id = int.Parse(Console.ReadLine());
                                    removeArtwork(a_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Enter artwork id: ");
                                    int art_id = int.Parse(Console.ReadLine());
                                    getArtwork(art_id);
                                    break;

                                case 5:
                                    searchArtwork();
                                    break;

                                case 6:
                                    Console.WriteLine("Exiting....");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice2 != 6);
                        break;

                    case 2:
                        do
                        {
                            Console.WriteLine("User Favorite");
                            Console.WriteLine("----------------");
                            Console.WriteLine("1. Add Favorite\n2. Remove Favorite\n3. Get Favorite\n4. Exit\n\n");
                            Console.WriteLine("Enter your choice: ");
                            choice3 = int.Parse(Console.ReadLine());
                            switch (choice3)
                            {
                                case 1:
                                    Console.WriteLine("Enter user id: ");
                                    int userId = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Artwork id: ");
                                    int artworkId = int.Parse(Console.ReadLine());
                                    addFavorite(userId, artworkId);
                                    break;

                                case 2:
                                    Console.WriteLine("Enter user id: ");
                                    int user_id = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Enter Artwork id: ");
                                    int artwork_id = int.Parse(Console.ReadLine());
                                    removeFavorite(user_id, artwork_id);
                                    break;

                                case 3:
                                    Console.WriteLine("Enter user id: ");
                                    int u_id = int.Parse(Console.ReadLine());
                                    getUserFavorite(u_id);
                                    break;

                                case 4:
                                    Console.WriteLine("Exiting....");
                                    break;

                                default:
                                    Console.WriteLine("Try again!!!");
                                    break;
                            }
                        } while (choice3 != 4);
                        break;

                    case 3:
                        GalleryManagementService service = new GalleryManagementService();
                        service.HandleMenu();
                        break;

                    case 4:
                        Console.WriteLine("Exiting....");
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;

                }
            } while (choice != 4);
        }
    }
}