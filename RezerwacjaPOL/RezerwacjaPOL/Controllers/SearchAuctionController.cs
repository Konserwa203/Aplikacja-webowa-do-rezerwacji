using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Nest;
using RezerwacjaPOL.Models;
using RezerwacjaPOLLibrary.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Controllers
{
    public class SearchAuctionController : Controller
    {
        private readonly ElasticClient _client;
        private readonly ILogger<SearchAuctionController> _logger;
        private static AuctionContext _context;
        public SearchAuctionController(ILogger<SearchAuctionController> logger, ElasticClient client, AuctionContext context)
        {
            _client = client;
            _logger = logger;
            _context = context;
        }
        public IActionResult Index()
        {
            var results = _client.Search<SearchEngineModel>(s => s
                .Query(q => q
                .MatchAll()
            ));
            var titles = new List<string>();
            foreach (var item in results.Documents)
            {
                titles.Add(item.Title);
            }

            _context.Auctions.Any(x => titles.Contains(x.Title));
            return View("Index",results);
        }
        //[Route("SearchAuction/Index")]
        //[Route("SearchAuction/Index/{id?}{page?}")]
        public IActionResult Indexx(string id,int page)
        {
            return View();
        }
    }
}
