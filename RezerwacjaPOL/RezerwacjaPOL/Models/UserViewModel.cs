using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.ViewModels
{
    public class UserViewModel
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        
        public string Email { get; set; }
       
        public string Password { get; set; }
        public string AvatarPath { get; set; }

        public IFormFile Avatar { get; set; }
    }
}
