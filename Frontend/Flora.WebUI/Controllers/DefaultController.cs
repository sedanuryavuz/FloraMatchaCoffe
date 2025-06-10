using Microsoft.AspNetCore.Mvc;

namespace Flora.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
