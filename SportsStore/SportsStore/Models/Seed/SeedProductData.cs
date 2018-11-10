using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using SportsStore.Models;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace SportsStore.Models.Seed
{
    public static class SeedProductData
    {
        private static Product[] GenerateProducts() =>        
            new Product[]{
                new Product {Name = "Kayak", Description = "A boat for one person",
                            Category = "Watersports", Price = 275 },
                new Product {Name = "Lifejacket", Description = "Protective and fashionable",
                            Category = "Watersports", Price = 48.95m },
                new Product {Name = "Soccer Ball",Description = "FIFA-approved size and weight",
                            Category = "Soccer", Price = 19.50m },
                new Product {Name = "Corner Flags",Description = "Give your playing field a professional touch",
                            Category = "Soccer", Price = 34.95m },
                new Product {Name = "Stadium",Description = "Flat-packed 35,000-seat stadium",
                            Category = "Soccer", Price = 79500 },
                new Product {Name = "Whorehouse",Description = "Flat-packed 35,000-whore house",
                            Category = "Soccer", Price = 179500 },
                new Product {Name = "Idiot population",Description = "one million idiots",
                            Category = "Idiots", Price = 0 },


            };        
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext dbContext = app.ApplicationServices.GetRequiredService<ApplicationDbContext>();
            dbContext.Database.Migrate();

            if (!dbContext.Products.Any())
            {                
                dbContext.Products.AddRange(GenerateProducts());
            }
            dbContext.SaveChanges();
        }

    }
}
