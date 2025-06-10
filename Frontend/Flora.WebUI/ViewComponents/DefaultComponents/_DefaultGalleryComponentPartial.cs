using Microsoft.AspNetCore.Mvc;

namespace Flora.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultGalleryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
