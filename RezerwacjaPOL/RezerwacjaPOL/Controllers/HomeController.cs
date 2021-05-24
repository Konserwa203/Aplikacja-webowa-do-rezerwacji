using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class HomeController : Controller
    {
        private readonly AuctionContext _context;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, AuctionContext context)
        {
            _context = context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            var data = new HomeIndexViewModel
            {
                Auctions = _context.Auctions.Select(x => new AuctionViewModel
                {
                    Title = x.Title,
                    ThumbnailPhotoDir = "23.png",
                    Category = x.Category.Name,
                    DateAdded = x.CreatedOn,
                })
            };
            return View(data);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
