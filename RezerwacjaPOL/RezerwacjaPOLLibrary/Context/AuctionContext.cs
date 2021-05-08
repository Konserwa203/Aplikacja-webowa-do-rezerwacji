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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseSqlServer("Server=DESKTOP-FRI3VUI\\SQLEXPRESS;Database=TestingDbForRezerwacja;Trusted_Connection=True;");
             // Todo - podmienić
            base.OnConfiguring(optionsBuilder);
        }
    }
}
