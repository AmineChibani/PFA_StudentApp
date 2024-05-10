using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    public class StatisticsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
