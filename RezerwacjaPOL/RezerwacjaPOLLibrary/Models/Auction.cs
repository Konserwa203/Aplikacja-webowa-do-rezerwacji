using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Models
{
    public class Auction
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime CreatedOn { get; set; }
        public AuctionCategory Category { get; set; }

        public string Description { get; set; }

        public virtual ICollection<AuctionPhoto> PhotosPath { get; set; }

        public string PhoneNumber { get; set; }

        public virtual User User { get; set; }

        public Auction()
        {
            CreatedOn = DateTime.Now;
        }
    }

    public class AuctionPhoto
    {
        public int Id { get; set; }
        public string PhotoPath { get; set; }

        public virtual Auction Auction { get; set; }

    }
}
