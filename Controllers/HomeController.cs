using Microsoft.AspNetCore.Mvc;

namespace OpenTable.Controllers  
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View(); // ✅ Test response
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult PrivacyPolicy()
        {
            return View();
        }
    }
}
