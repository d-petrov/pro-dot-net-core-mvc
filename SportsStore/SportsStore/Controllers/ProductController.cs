using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860
using SportsStore.Infrastructure;

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
        public IActionResult List(string category = null, int productPage = 1) =>
            View("ListExt", new ProductListViewModel
            {
                Products = Pagination.GetPage(repository.Products, PageSize, productPage, category),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = productPage,
                    ItemsPerPage = PageSize,
                    TotalItems = Pagination.GetTotalItemsByCategory(category,repository.Products)
                },
                CurrentCategory = category
            });

    }
}
