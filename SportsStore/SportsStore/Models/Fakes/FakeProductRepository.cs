using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.Models.Fakes
{
    public class FakeProductRepository : IProductRepository
    {
        public IQueryable<Product> Products => new List<Product>()
        {
            new Product{Name="Butt",Price=10M},
            new Product{Name="Tits",Price=222M}
        }.AsQueryable<Product>();
    }
}
