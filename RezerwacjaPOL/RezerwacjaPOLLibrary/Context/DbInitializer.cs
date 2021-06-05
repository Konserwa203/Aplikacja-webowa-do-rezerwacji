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
                new User { FirstName = "Jan", LastName = "Kowalski", Email = "jan@jan.pl",Password = "jan123", AvatarPath="defaultAvatar.png"},
                new User { FirstName = "Andrzej", LastName = "Nowak", Email = "andzrej@nowak.pl",Password = "adrzej123", AvatarPath="defaultAvatar.png"},
                new User { FirstName = "Mirosław", LastName = "Kowalski", Email = "mirek@jan.pl",Password = "mirek123", AvatarPath="defaultAvatar.png"},
                new User { FirstName = "Dorota", LastName = "Tutor", Email = "dorota@tutor.pl",Password = "dorota123", AvatarPath="defaultAvatar.png"},
                new User { FirstName = "Katarzyna", LastName = "Kowalska", Email = "katarzyna@kowal.pl",Password = "kasia123", AvatarPath="defaultAvatar.png"},
            };

            context.AddRange(users);
            context.SaveChanges();
            var categories = new AuctionCategory[]
            {
                new AuctionCategory{Name="Fryzjer"},
                new AuctionCategory{Name="Tynkarz"},
                new AuctionCategory{Name="Grafik"}
            };
            context.AddRange(categories);
            context.SaveChanges();
            int i = 1;
            foreach (var user in users)
            {
                user.Auctions = new Auction[]
                {
                    new Auction
                    {
                        Title= $"Usługi fryzjerskie - pon - pt 8-16 {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                        Category = context.AuctionCategories.First(x=>x.Name=="Fryzjer"),
                          PhotosPath = new List<AuctionPhoto>
                         {
                              new AuctionPhoto{ PhotoPath="fryzjer.png"}
                         }


                    },
                    new Auction
                    {
                        Title= $"Tynkowanie domu! {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                        Category = context.AuctionCategories.First(x=>x.Name=="Tynkarz"),
                          PhotosPath = new List<AuctionPhoto>
                         {
                              new AuctionPhoto{ PhotoPath="murarz.png"}
                         }
                    },
                    new Auction
                    {
                        Title= $"Usługi graficzne {i++}",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Quisque ut dapibus nulla. Orci varius natoque penatibus et magnis dis parturient montes, nascetur ridiculus mus. Sed commodo sollicitudin finibus. Phasellus id justo id libero porta egestas. Suspendisse et mauris vel urna gravida tristique.",
                        CreatedOn = DateTime.Now,
                        Category = context.AuctionCategories.First(x=>x.Name=="Grafik"),
                           PhotosPath = new List<AuctionPhoto>
                         {
                              new AuctionPhoto{ PhotoPath="grafik.png"}
                         }
                    }
                };
            }

            context.SaveChanges();
        }
    }
}
