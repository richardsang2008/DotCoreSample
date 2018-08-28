using System;
using System.Linq;
using DataModels.Entities;

namespace Infrastructure.DataAccess
{
    public  class DbInitializer
    {
        public static void Initialize(AppDbContext context, bool isDev)
        {
            #region ensure products, pets, order tables are created             
            context.Database.EnsureCreated();
            
                        
            if (context.Products.Any() && context.Pets.Any() && context.Orders.Any())
            {
                return; //db has been seeded
            }

            #endregion

            if (isDev)
            {
                #region setup testing data for products table if table is empty
                var products = new[]
                {
                    new Product
                    {
                        Id =1,
                        Description = "Ping pong ball by yin he",
                        IsDiscontinued = false,
                        Name = "Yin He 3 strars 40+ ball"
                    },
                    new Product
                    {
                        Id =2,
                        Description = "Ping pong ball by DHS",
                        IsDiscontinued = true,
                        Name = "Double Happiness 3 strars 40 ball"                    
                    }
                };
                foreach (Product p in products)
                {
                    context.Products.Add(p);
                }

                context.SaveChanges();

                #endregion

                #region setup testing data for pets table if table is empty 

                var pets = new[]
                {
                    new Pet
                    {
                        Id =1,
                        Breed = "German",
                        Name = "Lily",
                        PetType = PetType.Dog
                    },
                    new Pet
                    {
                        Id =2,
                        Breed = "France",
                        Name = "Pottle",
                        PetType = PetType.Dog
                    },
                };
                foreach (Pet p in pets)
                {
                    context.Pets.Add(p);
                }

                context.SaveChanges();
                #endregion
                
                #region setup testing data for orders table if table is empty

                var orders = new[]
                {
                    new Order
                    {
                        Id =1,
                        Description = "3 order of DHS balls",
                        OrderDate = DateTime.Parse("2018-8-24")
                    },
                    new Order
                    {
                        Id =2,
                        Description = "3 order of German dogs",
                        OrderDate = DateTime.Parse("2018-8-22")
                    },
                };
                foreach (Order p in orders) 
                {
                    context.Orders.Add(p);
                }

                context.SaveChanges();

                #endregion
            }
        }
    }
}