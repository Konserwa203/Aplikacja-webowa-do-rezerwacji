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

        
        public string Description { get; set; }

        public List<string> PhotosPath { get; set; }

        public string PhoneNumber { get; set; }
        

    }
}
