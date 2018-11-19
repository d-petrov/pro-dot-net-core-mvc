﻿using System;
using System.Collections.Generic;
using System.Linq;
using SportsStore.Models;

namespace SportsStore.Infrastructure
{
    public static class Pagination 
    {
        public static IEnumerable<Product> GetPage(IEnumerable<Product> input, int pageSize, int currentPage) =>
             input.OrderBy(p => p.ProductID)
                                .Skip(pageSize * (currentPage - 1))
                                .Take(pageSize);
    }
}