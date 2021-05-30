using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class SearchAuctionController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
