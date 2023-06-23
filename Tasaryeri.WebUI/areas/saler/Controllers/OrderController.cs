using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class OrderController : Controller
    {
        IOrderTransactions orderTransactions;
        public OrderController(IOrderTransactions orderTransactions)
        {
            this.orderTransactions = orderTransactions;
        }
        public IActionResult Index()
        {
            int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            var response = orderTransactions.GetSalerOrders(salerId);
            return View(response);
        }
    }
}
