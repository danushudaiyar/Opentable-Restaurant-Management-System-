using Microsoft.AspNetCore.Mvc;

namespace OpenTable.Controllers
{
    
    public class MobileController : Controller
    {
        public IActionResult List()
        {
            return Content("Area:Regular, Controller:Mobile, Action:List");
        }
    }
}
