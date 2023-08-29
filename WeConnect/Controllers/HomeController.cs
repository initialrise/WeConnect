using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;
using WeConnect.Models;
using WeConnect.Data;
using WeConnect.ViewModels;
using System.Net.Http;
using System.Net.Http.Headers;

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
            var tid = current_user.ThreadID;
            ViewBag.uid = uid;
            ViewBag.threadID = tid; 
            ViewBag.postlists = _db.Posts.ToList();
            var posts = _db.Posts.ToList().Where(p=>p.ThreadID==tid);

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
			//Hosted web API REST Service base url
        public async Task<ActionResult> Notices()
        {
        string Baseurl = "https://gist.githubusercontent.com/";
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage Res = await client.GetAsync("ictsolved/34c4d9041f2749715c56eff551628995/raw");
                if (Res.IsSuccessStatusCode)
                {
                    var EmpResponse = Res.Content.ReadAsStringAsync().Result;
					ViewBag.response = EmpResponse;
                    //EmpInfo = JsonConvert.DeserializeObject<List<Employee>>(EmpResponse);
                }
                return View();
            }
        

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
