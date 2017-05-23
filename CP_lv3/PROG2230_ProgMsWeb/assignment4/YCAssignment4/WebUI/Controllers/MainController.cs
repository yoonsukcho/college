﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers
{
    public class MainController : Controller
    {
        // GET: /<controller>/
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Authenticate()
        {

            if (ModelState.IsValid)
            {

                return RedirectToAction("Index", "LoggedIn");
            }
            else
            {
                return RedirectToAction("Index", "Main");
            }
        }
    }
}
