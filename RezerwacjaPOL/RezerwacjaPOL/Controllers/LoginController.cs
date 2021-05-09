using Microsoft.AspNetCore.Mvc;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using RezerwacjaPOLLibrary.ViewModels;
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

        [ActionName("Index")]
        public IActionResult IndexPost(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == loginData.Email && x.Password == loginData.Password);
                if(user != null)
                {
                    return Ok(user);
                }
            }

            return NotFound();
        }
        
    }
}
