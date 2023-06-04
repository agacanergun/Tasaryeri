using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.areas.admin.Controllers
{
    public class FooterController : Controller
    {
        //sosyalmedya
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult AboutUs()
        {
            return View();
        }
        public IActionResult Institutional()
        {
            return View();
        }
    }
}
