using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            var response = productTransactions.GetAll(id);
            return View(response);
        }
    }
}
