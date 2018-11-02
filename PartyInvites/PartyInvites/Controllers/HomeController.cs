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
            ViewBag.Title = "Welcome";
            ViewBag.now = now;
            ViewBag.greeting = (now.Hour - 12 <= 0) ? "Good morning fucker" : "Good afternoon asshat";
            return View("Welcome");
        }
        [HttpGet]
        public IActionResult RsvpForm()
        {
            return View();
        }
        [HttpPost]
        public IActionResult RsvpForm(GuestResponse response)
        {
            bool validState = ModelState.IsValid;
            bool addSuccess = false;
            if (validState)
            {
                addSuccess = Repository.Add(response);                
            }
            if (addSuccess)
            {
                return View("Thanks", response);
            }
            else
            {    
                //TODO:if not valid how to display error
                return View();
            }
        }
        [HttpGet]
        public IActionResult ListResponses()
        {
            return View(Repository.Responses.Where(resp => resp.WillAttend == true));
        }
    }
}
