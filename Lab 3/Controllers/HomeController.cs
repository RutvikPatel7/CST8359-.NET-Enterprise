using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lab3.Models;
using Microsoft.AspNetCore.Mvc;

namespace Lab3.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [HttpPost]
        public IActionResult Razor()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreatePerson()
        {
            return View();
        }

        [HttpPost]
        public IActionResult DisplayPerson(Person person)
        {
            return View(person);
        }

        public IActionResult Count(Person person)
        {
            return View(person);
        }
    }
}
