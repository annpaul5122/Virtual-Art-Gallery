using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Virtual_Art_Gallery.Repository;

namespace Virtual_Art_Gallery.Exceptions
{
    internal class UserNotFoundException : Exception
    {
        public UserNotFoundException(string message) : base(message)
        {
            
        }

        public static void UserNotFound(int userId)
        {
            GalleryRepository repository = new GalleryRepository();
            if(!repository.UserIdExists(userId))
            {
                throw new UserNotFoundException("User Id not found");
            }
        }
    }
}
