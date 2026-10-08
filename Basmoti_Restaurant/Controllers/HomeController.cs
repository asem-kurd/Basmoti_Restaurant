using Microsoft.AspNetCore.Mvc;

namespace Basmoti_Restaurant.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
