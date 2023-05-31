using Microsoft.AspNetCore.Mvc;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            HomeIndexVM vm = new HomeIndexVM();
            return View(vm);
        }
    }
}
