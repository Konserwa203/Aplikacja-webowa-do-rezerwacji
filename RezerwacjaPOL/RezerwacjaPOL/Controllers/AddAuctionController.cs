﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using RezerwacjaPOL.Models;
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
    public class AddAuctionController : Controller
    {
        private static IHostingEnvironment _enviroment;
        private static IConfiguration _configuration;
        private static AuctionContext _context;

        public AddAuctionController(IHostingEnvironment environment, IConfiguration configuration, AuctionContext context)
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
        public IActionResult Index(AuctionViewModel newAuction)
        {
            if (ModelState.IsValid)
            {
                _context.Database.EnsureCreated();
                InsertAuction(newAuction);
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

            _context.Auctions.Add(auctionToAdd);
            _context.SaveChanges();
        }        
    }
}