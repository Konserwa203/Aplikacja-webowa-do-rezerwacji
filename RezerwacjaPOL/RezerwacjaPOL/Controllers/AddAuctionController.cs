using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using RezerwacjaPOLLibrary.Models;
using RezerwacjaPOLLibrary.Settings;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    [Authorize]
    public class AddAuctionController : Controller
    {
        private static IHostingEnvironment _enviroment;
        private static IConfiguration _configuration;
        private static AuctionContext _context;
        private readonly IGlobalSettings _globalSettings;


        public AddAuctionController(IHostingEnvironment environment, IConfiguration configuration, AuctionContext context, IGlobalSettings globalSettings)
        {
            _enviroment = environment;
            _configuration = configuration;
            _context = context;
            _globalSettings = globalSettings;
        }
        public User GetLoggedUser()
        {
            return _context.Users.FirstOrDefault(x => x.Email == _globalSettings.Email);
        }

        public IActionResult Index()
        {
            ViewBag.Categories = _context.AuctionCategories.ToList<AuctionCategory>();
            return View();
        }

        [HttpPost]
        public IActionResult Index(AuctionViewModel newAuction)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();
                newAuction.User = GetLoggedUser();
                InsertAuction(newAuction);
                return RedirectToAction("Index","Home");
            }
            return View();
        }

        static void InsertAuction(AuctionViewModel newAuction)
        {
            List<AuctionPhoto> ConvertedPaths = new List<AuctionPhoto>();

            Auction auctionToAdd = new Auction();



            if (newAuction.Photos != null)
            {
                foreach (var photo in newAuction.Photos)
                {
                    AuctionPhoto auctionPhoto = new AuctionPhoto
                    {
                        PhotoPath = ImageTool.SaveImage(photo, _enviroment),
                        Auction = auctionToAdd
                    };
                    _context.AuctionPhotos.Add(auctionPhoto);
                    ConvertedPaths.Add(auctionPhoto);
                }
            }
            else
            {
                ConvertedPaths.Add(new AuctionPhoto
                {
                    PhotoPath = "default.png",
                    Auction = auctionToAdd
                });
            }

            
          
            auctionToAdd.Title = newAuction.Title;
            auctionToAdd.Description = newAuction.Description;
            auctionToAdd.PhoneNumber = newAuction.PhoneNumber;
            auctionToAdd.PhotosPath = ConvertedPaths;
            auctionToAdd.Category = _context.AuctionCategories.FirstOrDefault(x => x.Id == newAuction.CategoryId);
            auctionToAdd.User = newAuction.User;
            

            _context.Auctions.Add(auctionToAdd);
            _context.SaveChanges();
        }        

        static List<string> GetCategoryStrings()
        {
            List<AuctionCategory> tempList = _context.AuctionCategories.ToList<AuctionCategory>();
            List<string> stringsList = new List<string>();
            foreach(var item in tempList)
            {
                stringsList.Add(item.Name);
            }
            return stringsList;
        }
    }
}
