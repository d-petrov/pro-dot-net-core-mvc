using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SportsStore.Models;

namespace SportsStore.Views.Shared.Components
{
    public class CartSummaryViewComponent : ViewComponent
    {
        private Cart cart;
        //from registered service
        public CartSummaryViewComponent(Cart cartService) => cart = cartService;
        public IViewComponentResult Invoke() => View(cart);
    }
}
