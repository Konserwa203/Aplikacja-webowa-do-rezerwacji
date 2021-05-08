using Microsoft.AspNetCore.Mvc;
using RezerwacjaPOLLibrary.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class UserRegisterController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(UserViewModel userViewModel)
        {

            return View();
        }
    }
}
