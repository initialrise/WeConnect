using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WeConnect.Models;

namespace WeConnect.Controllers
{
    public class HomeController : Controller
    {
        [Authorize]
        public IActionResult Index()
        {
            return View();
        }


        public IActionResult Jobs()
        {
            return View();
        }
          public IActionResult Notices()
        {
            return View();
        }

        public IActionResult Create()
        {
            return View();
        }

        public IActionResult Account()
        {
            return View();
        }
        public IActionResult Edit(int id)
        {
            return View();
        }
        public IActionResult Delete(int id)
        {
            return View();
        }


    }
}