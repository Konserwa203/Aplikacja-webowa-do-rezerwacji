using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RezerwacjaPOL.Models
{
    public class SearchEngineModel
    {
        public int Id { get; set; } 
        public string Title { get; set; }
        public string Description { get; set; }
        public string PhoneNumber { get; set; }
        //public ICollection<IFormFile> Photos { get; set; }
       // public string ThumbnailPhotoDir { get; set; }
        public DateTime DateAdded { get; set; }
        //public string Category { get; set; }
        //public AuctionCategory? Category { get; set; }
        public string CategoryString { get; set; }
        //public int? CategoryId { get; set; }
        public string User { get; set; }

        //public virtual ICollection<AuctionPhoto> PhotosPath { get; set; }
    }
}
