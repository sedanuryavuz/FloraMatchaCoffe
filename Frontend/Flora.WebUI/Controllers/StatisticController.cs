using Microsoft.AspNetCore.Mvc;

namespace Flora.WebUI.Controllers
{
    public class StatisticController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
