using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class SalerProductController : Controller
    {
        [Route("satici/satici-ürünleri")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
