using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsStore.Models;
using SportsStore.Models.ViewModels;
using SportsStore.Infrastructure;

namespace SportsStore.Controllers
{
    public class CartController : Controller
    {
        private IProductRepository repo;
        private Cart cart;

        //cart service registered in startup maps Cart to SessionCart
        public CartController(IProductRepository repo, Cart cartService)
        {
            this.repo = repo;
            cart = cartService;
        }

        private Cart GetCart()
        {
            return HttpContext.Session.GetJson<Cart>(Cart.SessionKey) ?? new Cart();
        }

        private void SetCart(Cart cart)
        {
            if (cart != null)
            {
                HttpContext.Session.SetJson(Cart.SessionKey, cart);
            }
        }

        public IActionResult Index(string returnUrl)
        {
            CartIndexViewModel viewModel = new CartIndexViewModel
            {
                Cart = cart,
                ReturnUrl = returnUrl
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddToCart(int productId, string returnUrl, int quantity = 1)
        {
            Product product = repo.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {                
                cart.AddItem(product, quantity);                
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repo.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {                
                cart.RemoveItem(productId);                
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpPost]
        public IActionResult ClearCart(string returnUrl)
        {            
            cart.RemoveAllItems();         
            return View("Empty", returnUrl);
        }
    }
}