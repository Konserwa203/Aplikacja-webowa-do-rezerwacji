using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Models
{
    public class HomeIndexViewModel
    {
        public IEnumerable<AuctionViewModel> Auctions { get; set; }
    }
}
