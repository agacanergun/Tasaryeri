using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
