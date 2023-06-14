using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.Controllers
{
    public class MemberController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
