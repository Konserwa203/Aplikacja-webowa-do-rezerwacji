using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            ISearchResponse<SearchEngineModel> results;
            
            
                results = _client.Search<SearchEngineModel>(s => s
                    .Query(q => q
                        .MatchAll()));
            
            var titles = new List<string>();
            foreach (var item in results.Documents)
            {
                titles.Add(item.Title);
            }
            var auctions = _context.Auctions.Where(x => titles.Contains(x.Title)).ToList();
            var getData = _context.Auctions.Include(x => x.PhotosPath).ThenInclude(x => x.Auction.Category)
                .Where(x => titles.Contains(x.Title)).ToList();
            var data = new HomeIndexViewModel
            {
                Auctions = getData.Select(x => new AuctionViewModel
                {
                    Title = x.Title,
                    ThumbnailPhotoDir = x.PhotosPath.Select(x => x.PhotoPath).FirstOrDefault(),
                    Category = x.Category,
                    DateAdded = x.CreatedOn,
                    PhotosPath = x.PhotosPath,
                    Description = x.Description,
                    Id = x.Id
                })
            };
            ViewData["auctions"] = data.Auctions;
            return View("Index",results);
        }
        //[Route("SearchAuction/Index")]
        //[Route("SearchAuction/Index/{id?}{page?}")]
        [HttpPost]
        public IActionResult Index(string query)
        {
            ViewData["blad"] = "";
            ISearchResponse<SearchEngineModel> results;
            if (!string.IsNullOrWhiteSpace(query))
            {
                results = _client.Search<SearchEngineModel>(s => s
                .Query(q => q
                .Match(t => t
                .Field(f => f.Title)
                .Query(query)
                     )
                   )
                );
            }
            else
            {
                results = _client.Search<SearchEngineModel>(s => s
                    .Query(q => q
                        .MatchAll()
                    )
                );
                ViewData["blad"]= "Niestyty nie znaleziono tego czego szukasz";
            }
            var titles = new List<string>();
            foreach (var item in results.Documents)
            {
                titles.Add(item.Title);
            }
            var auctions = _context.Auctions.Where(x => titles.Contains(x.Title)).ToList();
            var getData = _context.Auctions.Include(x => x.PhotosPath).ThenInclude(x => x.Auction.Category)
                .Where(x => titles.Contains(x.Title)).ToList();
            var data = new HomeIndexViewModel
            {
                Auctions = getData.Select(x => new AuctionViewModel
                {
                    Title = x.Title,
                    ThumbnailPhotoDir = x.PhotosPath.Select(x => x.PhotoPath).FirstOrDefault(),
                    Category = x.Category,
                    DateAdded = x.CreatedOn,
                    PhotosPath = x.PhotosPath,
                    Description = x.Description,
                    Id = x.Id
                })
            };
            ViewData["auctions"] = data.Auctions;
            return View("Index", results);
        }
    }
}
