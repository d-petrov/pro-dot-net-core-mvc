using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SportsStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly int PageSize = 4;
        private IProductRepository repository;
        public ProductController(IProductRepository repository)
        {
            this.repository = repository;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult List([FromQuery]int productPage = 1) =>      
            View(new ProductListViewModel
            {
                Products = repository.Products
                .OrderBy(p => p.ProductID)
                .Skip(PageSize * (productPage - 1))
                .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = repository.Products.Count()
                }
            });
        
    }
}
