using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class SalerProductController : Controller
    {
        IProductTransactions productTransactions;
        public SalerProductController(IProductTransactions productTransactions)
        {
            this.productTransactions = productTransactions;
        }
        [Route("satici/satici-ürünleri")]
        public IActionResult Index()
        {
            var response = productTransactions.GetAll(5);
            return View(response);
        }
    }
}
