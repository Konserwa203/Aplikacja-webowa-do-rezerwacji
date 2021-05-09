using Microsoft.AspNetCore.Mvc;
using RezerwacjaPOLLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class LoginController : Controller
    {
        private readonly AuctionContext _context;
        public LoginController(AuctionContext auctionContext)
        {
            _context = auctionContext;
        }

        public IActionResult Index()
        {
            return View();
        }
        
    }
}
