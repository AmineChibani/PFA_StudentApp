using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    public class AdsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
