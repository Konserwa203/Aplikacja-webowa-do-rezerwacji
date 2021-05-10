using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Models
{
    public class AuctionViewModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<IFormFile> Photos { get; set; }
        //w razie potrzeby trzeba będzie tu coś pododawać
    }
}
