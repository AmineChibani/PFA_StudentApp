using Microsoft.AspNetCore.Mvc;

namespace StudentApp.Controllers
{
    public class ErrorController : Controller
    {
        [ActionName("Errors500")]
        public IActionResult Errors500()
        {
            return View();
        }


        [ActionName("Errors404Basic")]
        public IActionResult Errors404Basic()
        {
            return View();
        }
    }
}
