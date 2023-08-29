using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WeConnect.Models;
using WeConnect.Data;




namespace WeConnect.Controllers
{
    public class HomeController : Controller
    {
		private readonly ApplicationDbContext _db;

		public HomeController(ApplicationDbContext db){
			_db =db;
		}

        [Authorize]
        public IActionResult Index()
        {
            ViewData["name"]=  User.FindFirstValue(ClaimTypes.NameIdentifier);
			List<Posts> posts = _db.Posts.ToList();
            return View(posts);
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
