using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.Models
{
    public abstract class BaseProductRepository : IProductRepository
    {
        public abstract IQueryable<Product> Products { get; }
    }
}
