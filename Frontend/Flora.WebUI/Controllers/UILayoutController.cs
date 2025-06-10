using Microsoft.AspNetCore.Mvc;

namespace Flora.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
