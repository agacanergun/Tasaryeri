using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        [Route("/sepetim")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
