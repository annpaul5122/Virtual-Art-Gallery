using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Virtual_Art_Gallery.Models;
using Virtual_Art_Gallery.Service;

namespace Virtual_Art_Gallery.VirtualArtGallery
{
    internal class VirtualGallery
    {
        AuthenticationService service = new AuthenticationService();

        public void HandleMenu()
        {
            int choice = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Virtual Art Gallery");
                Console.WriteLine("---------------------\n");
                Console.WriteLine("Press 1: Login\nPress 2: Register\nPress 3: Exit\n");
                Console.WriteLine("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Login");
                        Console.WriteLine("--------------");
                        Console.WriteLine("Enter username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password: ");
                        string password = Console.ReadLine();
                        service.Login(username, password);
                        break;

                    case 2:
                        Console.WriteLine("Register");
                        Console.WriteLine("-------------");
                        Console.WriteLine("Set username: ");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Set password: ");
                        string pwd = Console.ReadLine();
                        Console.WriteLine("Enter email: ");
                        string email = Console.ReadLine();
                        Console.WriteLine("Enter first name: ");
                        string fname = Console.ReadLine();
                        Console.WriteLine("Enter last name: ");
                        string lname = Console.ReadLine();
                        Console.WriteLine("Enter date of birth (yyyy-mm-dd): ");
                        string dob = Console.ReadLine();
                        Console.WriteLine("Enter profile url: ");
                        string url = Console.ReadLine();
                        User user = new User() { Username = userName, Password = pwd, Email = email, FirstName = fname, LastName = lname, DateOfBirth = DateTime.Parse(dob), ProfilePicture = url };
                        service.Register(user);
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;

                    default:
                        Console.WriteLine("Try again!!!");
                        break;
                }
            } while (choice != 3);
        }
    }
}
