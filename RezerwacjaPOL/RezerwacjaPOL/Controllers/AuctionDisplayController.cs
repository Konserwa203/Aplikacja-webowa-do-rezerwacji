using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class AuctionDisplayController : Controller
    {
        private readonly AuctionContext _context;
        

        public AuctionDisplayController(AuctionContext context)
        {
            _context = context;
        
        }

        public IActionResult Index(int Id =0)
        {

            var getSingleAuction = _context.Auctions.Include(x => x.PhotosPath).ThenInclude(x => x.Auction.Category).Where(x=>x.Id==Id).ToList().First();
            var auction = new AuctionViewModel
            {
                Title = getSingleAuction.Title,
                ThumbnailPhotoDir = getSingleAuction.PhotosPath.Select(x => x.PhotoPath).FirstOrDefault(),
                Category = getSingleAuction.Category,
                DateAdded = getSingleAuction.CreatedOn,
                PhotosPath = getSingleAuction.PhotosPath,
                Description = getSingleAuction.Description,
                Id = getSingleAuction.Id
            };
            return View(auction);
        }
    }
}
