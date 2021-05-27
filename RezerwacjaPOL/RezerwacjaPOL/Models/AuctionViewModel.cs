﻿using Microsoft.AspNetCore.Http;
using RezerwacjaPOLLibrary.Models;
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
        public string ThumbnailPhotoDir { get; set; }
        public DateTime DateAdded { get; set; }
        public string Category { get; set; }
        public virtual ICollection<AuctionPhoto> PhotosPath { get; set; }
        //w razie potrzeby trzeba będzie tu coś pododawać
    }
}
