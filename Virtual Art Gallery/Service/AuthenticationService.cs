using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Service
{
    internal class AuthenticationService
    {
        private readonly Authentication _authentication;
        private readonly VirtualGalleryService _virtualGallery;

        public AuthenticationService()
        {
            _authentication = new Authentication();
            _virtualGallery = new VirtualGalleryService();
        }

        public void Login(string username, string password)
        {
            if (_authentication.Login(username, password))
            {
                _virtualGallery.Handlemenu();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Login unsuccessful!!"); 
            }
        }

        public void Register(User user)
        {
            if (_authentication.Register(user))
                _virtualGallery.Handlemenu();
            else 
            { 
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Registration unsuccessful try again!!!"); 
            }
        }


        }
    }
