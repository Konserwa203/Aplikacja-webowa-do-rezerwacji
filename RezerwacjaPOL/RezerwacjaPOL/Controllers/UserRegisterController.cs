using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RezerwacjaPOLLibrary.Context;
using RezerwacjaPOLLibrary.Models;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class UserRegisterController : Controller
    {
        private static IHostingEnvironment _enviroment;
        private static IConfiguration _configuration;
        private static AuctionContext _context;

        public UserRegisterController(IHostingEnvironment environment, IConfiguration configuration, AuctionContext context)
        {
            _enviroment = environment;
            _configuration = configuration;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel user)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();
                user.AvatarPath = SaveImage(user);
                InsertUser(_context, user);
                _context.SaveChanges();
            }
            return RedirectToAction("Index","Home");
        }

        static string SaveImage(UserViewModel user)
        {
            if (user.Avatar.Length > 0)
            {
                string wwwRothPath = _enviroment.WebRootPath;
                string fileExtension = Path.GetExtension(user.Avatar.FileName);
                var userCount = _context.Users.Count() + 1;
                string filePathLocal = userCount.ToString() + fileExtension;
                var filePathRoot = Path.Combine(wwwRothPath + "/Files/" + filePathLocal);

                using (var stream = System.IO.File.Create(filePathRoot))
                {
                    user.Avatar.CopyTo(stream);
                    return filePathLocal;
                }
            }
            else return "default.png";
        }

        static void InsertUser(AuctionContext context, UserViewModel user)
        {
            context.Users.Add(new User
            {
                FirstName = user.FirstName,
                Email = user.Email,
                LastName = user.LastName,
                Password = user.Password,
                AvatarPath = user.AvatarPath
            });
            context.SaveChanges();
        }


    }
}
