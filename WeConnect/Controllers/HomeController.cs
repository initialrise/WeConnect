using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WeConnect.Models;
using WeConnect.Data;
using WeConnect.ViewModels;

namespace WeConnect.Controllers
{
    public class HomeController : Controller
    {
		private readonly ApplicationDbContext _db;

		public HomeController(ApplicationDbContext db){
			_db =db;
		}

        [Authorize]
        [HttpGet]
        public IActionResult Index()
        {
            var uid=  User.FindFirstValue(ClaimTypes.NameIdentifier);
            var current_user = _db.ApplicationUsers.Find(uid);
            ViewBag.uid = uid;
                        ViewBag.threadID = current_user.ThreadID;
                        ViewBag.postlists = _db.Posts.ToList();

            /*
                        IndexView iv = new IndexView();
                        iv.User = current_user;
                        iv.Posts = _db.Posts.ToList();
            */
            var posts = _db.Posts.ToList();
            List<ApplicationUser> users = _db.ApplicationUsers.ToList();

            List<Uposts> uposts = new List<Uposts>();
        
            foreach(var p in posts)
            {
                var up = new Uposts();
                var uuid = p.UserID;
                var uname = users.Where(u=>u.Id==uuid).First().Name;
                //uname.
                up.uname = uname;
                up.Id = p.Id;
                up.Likes = p.Likes;
                up.Content = p.Content;
                up.Dislikes = p.Dislikes;
                up.Timestamp = p.Timestamp;
                up.ImageURL = p.ImageURL;
                up.ThreadID = p.ThreadID;
                up.UserID = p.UserID;
                uposts.Add(up);
            }
            ViewBag.uposts = uposts;
            return View();
        }

        [Authorize]
        [HttpPost]
        public IActionResult Index(Posts post)
        {
            _db.Posts.Add(post);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }



        public IActionResult Jobs()
        {
            return View();
        }
          public IActionResult Notices()
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
