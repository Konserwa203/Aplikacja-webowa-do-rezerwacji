using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class AuctionDisplayController : Controller
    {
        public IActionResult Index(int Id =0)
        {
            return View();
        }
    }
}
