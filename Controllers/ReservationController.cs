using Microsoft.AspNetCore.Mvc;

namespace OpenTable.Controllers
{
    
    public class ReservationController : Controller
    {
        public IActionResult Manage()
        {
            return Content("Area:Regular, Controller:Reservation, Action:Manage");
        }
        public IActionResult List()
        {
            return Content("Area:Main, Controller:Reservation, Action:List");
        }

        public IActionResult Add()
        {
            return Content("Area:Main, Controller:Reservation, Action:Add");
        }

        public IActionResult Update()
        {
            return Content("Area:Main, Controller:Reservation, Action:Update");
        }

        public IActionResult Delete()
        {
            return Content("Area:Main, Controller:Reservation, Action:Delete");
        }
    }
}
