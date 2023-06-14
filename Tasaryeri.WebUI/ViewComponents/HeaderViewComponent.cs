using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
