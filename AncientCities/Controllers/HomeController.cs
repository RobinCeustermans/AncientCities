using Microsoft.AspNetCore.Mvc;

namespace AncientCities.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
