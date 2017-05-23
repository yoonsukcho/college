using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace YCBusService.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            TempData["message"] = "TempData Message.";
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "About Yoonsuk Bus Service Company.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Yoonsuk Bus Service contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
