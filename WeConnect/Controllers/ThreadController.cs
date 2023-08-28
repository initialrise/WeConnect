using Microsoft.AspNetCore.Mvc;

namespace WeConnect.Controllers
{
    public class ThreadController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
