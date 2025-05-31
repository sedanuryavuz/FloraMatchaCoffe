using Microsoft.AspNetCore.Mvc;

namespace Flora.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
