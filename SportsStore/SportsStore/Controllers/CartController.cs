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

        public CartController(IProductRepository repo)
        {
            this.repo = repo;
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
                Cart = GetCart(),
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
                Cart cart = GetCart();
                cart.AddItem(product, quantity);
                SetCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpPost]
        public IActionResult RemoveFromCart(int productId, string returnUrl)
        {
            Product product = repo.Products.Where(p => p.ProductID == productId).FirstOrDefault();
            if (product != null)
            {
                Cart cart = GetCart();
                cart.RemoveItem(productId);
                SetCart(cart);
            }
            return RedirectToAction("Index", new { returnUrl });
        }
        [HttpPost]
        public IActionResult ClearCart(string returnUrl)
        {
            Cart cart = GetCart();
            cart.ClearAllItems();
            SetCart(cart);
            return View("Empty", returnUrl);
        }
    }
}