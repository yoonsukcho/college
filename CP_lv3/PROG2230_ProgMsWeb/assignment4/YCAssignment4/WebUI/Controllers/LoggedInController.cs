using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using WebUI.Models;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class LoggedInController : Controller
    {

        // GET: /<controller>/


        public LoggedInController( UserManager<ApplicationUser> userManager, ILoggerFactory loggerFactory)
        {

        }



        public IActionResult Index()
        {
            HttpContext.Session.SetString("Login", "OK");
            HttpContext.Session.SetString("LoginName", "Yoonsuk");
            HttpContext.Session.SetString("CustomerID", "12345");

            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        public IActionResult LoggedOut()
        {
            HttpContext.Session.Remove("Login");
            HttpContext.Session.Remove("LoginName");
            HttpContext.Session.Remove("CustomerID");
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

    }
}
