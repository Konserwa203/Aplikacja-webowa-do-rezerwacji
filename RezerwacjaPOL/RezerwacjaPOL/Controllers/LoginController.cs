using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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

        [HttpPost]
        [ActionName("Index")]
        public async Task<IActionResult> IndexPostAsync(LoginViewModel loginData)
        {
            if (ModelState.IsValid)
            {
                var user = _context.Users.FirstOrDefault(x => x.Email == loginData.Email && x.Password == loginData.Password);
                if(user != null)
                {
                    var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.Email,user.Email)
                    };

                    var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    await HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                    return RedirectToAction("Index","Home");
                }
            }

            return NotFound();
        }
        
    }
}
