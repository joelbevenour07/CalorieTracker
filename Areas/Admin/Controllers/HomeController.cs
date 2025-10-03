using Microsoft.AspNetCore.Mvc;

namespace CalorieCalc.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        public IActionResult Admin()
        {
            return View();
        }
    }
}
