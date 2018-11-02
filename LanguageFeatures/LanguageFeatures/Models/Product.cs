using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LanguageFeatures.Models
{
    public class Product
    {
        public string Name { get; set; }
        public decimal? Price { get; set; }

        public static Product[] Get()
        {
            return new Product[] { new Product { Name = "crack", Price = 20.0M }, new Product { Name = "whore", Price = 200.53M } };
        }
    }
}
