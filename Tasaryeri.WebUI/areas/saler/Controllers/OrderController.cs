using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.DAL.Enums;

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
        [Route("satici/siparislerim")]
        public IActionResult Index()
        {
            int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            var response = orderTransactions.GetSalerOrders(salerId);
            return View(response);
        }
        [Route("satici/siparislerim-güncelle"),HttpPost]
        public string UpdateOrderStatus(int id, string selectedValue)
        {
            orderTransactions.UpdateOrderStatus(id, selectedValue);
            return "Ok";
        }
    }
}
