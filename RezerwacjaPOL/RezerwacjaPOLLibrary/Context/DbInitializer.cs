using RezerwacjaPOLLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RezerwacjaPOLLibrary.Context
{
    public static class DbInitializer
    {
        public static void Initialize(AuctionContext context)
        {
            context.Database.EnsureCreated();
            if (context.Users.Any())
            {
                return;
            }

            var users = new User[]
            {
                new User { FirstName = "Jan", LastName = "Kowalski", Email = "jan@jan.pl",Password = "jan123"},
                new User { FirstName = "Andrzej", LastName = "Nowak", Email = "andzrej@nowak.pl",Password = "adrzej123"},
                new User { FirstName = "Mirosław", LastName = "Kowalski", Email = "mirek@jan.pl",Password = "mirek123"},
                new User { FirstName = "Dorota", LastName = "Tutor", Email = "dorota@tutor.pl",Password = "dorota123"},
                new User { FirstName = "Katarzyna", LastName = "Kowalska", Email = "katarzyna@kowal.pl",Password = "kasia123"},
            };

            context.AddRange(users);
            context.SaveChanges();

            int i = 1;
            foreach (var user in users)
            {
                user.Auctions = new Auction[]
                {
                    new Auction
                    {
                        Title= $"Title {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                    },
                    new Auction
                    {
                        Title= $"Title {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                    },
                    new Auction
                    {
                        Title= $"Title {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                    }
                };
            }

            context.SaveChanges();
        }
    }
}
