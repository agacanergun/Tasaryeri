using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.ViewModels;

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
            int memberId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            MessageDTO MessageDTO = new MessageDTO
            {
                ProductId = productId,
                MemberId = memberId,
                SalerId = salerId,
            };
            SendMessageVM sendMessageVM = new SendMessageVM
            {
                MessageDTO = MessageDTO,
                SalerDTO = saler,
            };
            return View(sendMessageVM);
        }
    }
}
