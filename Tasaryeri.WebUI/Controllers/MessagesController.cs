using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Controllers
{
    [Authorize(AuthenticationSchemes = "TasaryeriMemberAuth")]
    public class MessagesController : Controller
    {
        IMessageTransactions messageTransactions;
        public MessagesController(IMessageTransactions messageTransactions)
        {
            this.messageTransactions = messageTransactions;
        }
        [Route("uye/mesajlar")]
        public IActionResult Index()
        {
            return View();
        }
        [Route("uye/mesajlar"), HttpPost]
        public IActionResult Index(MemberLoginDTO asd)
        {
            return View();
        }

        public IActionResult SendMessage(int salerId, string productName, int productId)
        {
            var saler = messageTransactions.GetSaler(salerId);
            return View();
        }
    }
}
