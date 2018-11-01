using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PartyInvites.Models;

namespace PartyInvites.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            DateTime now = DateTime.Now;
            ViewBag.now = now;
            ViewBag.greeting = (now.Hour - 12 <= 0) ? "Good morning fucker" : "Good afternoon asshat";
            return View("Example");
        }
        public IActionResult RsvpForm()
        {
            return View();
        }
    }
}
