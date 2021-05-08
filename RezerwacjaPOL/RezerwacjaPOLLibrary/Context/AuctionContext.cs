using Microsoft.EntityFrameworkCore;
using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Context
{
    public class AuctionContext : DbContext
    {
        public DbSet<Auction> Auctions { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<AuctionPhoto> AuctionPhotos { get; set; }

        public AuctionContext(DbContextOptions<AuctionContext> options) : base(options)
        {
        }

    }
}
