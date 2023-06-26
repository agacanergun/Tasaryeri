using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{

    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class MessagesController : Controller
    {
        IMessageTransactions messageTransactions;
        public MessagesController(IMessageTransactions messageTransactions)
        {
            this.messageTransactions = messageTransactions;
        }
        [Route("satici/mesajlar")]
        public IActionResult Index()
        {
            try
            {
                int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var oldMessages = messageTransactions.GetOldMessagesForSaler(salerId);
                return View(oldMessages);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/mesaj-gonder")]
        public IActionResult SendMessage(int MemberId, int productId)
        {
            try
            {
                var member = messageTransactions.GetMember(MemberId);
                int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var oldMessages = messageTransactions.GetOldMessagesForSaler(salerId);
                var messages = messageTransactions.GetMessages(salerId, MemberId, productId);
                var product = messageTransactions.GetProduct(productId);
                MessageDTO MessageDTO = new MessageDTO
                {
                    ProductId = productId,
                    MemberId = MemberId,
                    SalerId = salerId,
                };
                SendMessageVM sendMessageVM = new SendMessageVM
                {
                    MessageDTO = MessageDTO,
                    MemberDTO = member,
                    Messages = messages,
                    productDTO = product,
                    OldMessages = oldMessages,
                };
                return View(sendMessageVM);
            }
            catch (Exception)
            {

                throw;
            }
        }
        [Route("satici/mesaj-gonder"), HttpPost]
        public IActionResult SendMessage(MessageDTO messageDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    messageDTO.Timestamp = DateTime.Now;
                    messageDTO.Sender = "Saler";
                    var response = messageTransactions.SendMessage(messageDTO);
                    int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                    var oldMessages = messageTransactions.GetOldMessagesForSaler(salerId);
                    var member = messageTransactions.GetMember(messageDTO.MemberId);
                    var messages = messageTransactions.GetMessages(messageDTO.SalerId, messageDTO.MemberId, messageDTO.ProductId);
                    var product = messageTransactions.GetProduct(messageDTO.ProductId);

                    SendMessageVM sendMessageVM = new SendMessageVM
                    {
                        MessageDTO = messageDTO,
                        MemberDTO = member,
                        Messages = messages,
                        productDTO = product,
                        OldMessages = oldMessages,
                    };
                    return View(sendMessageVM);
                }
                return Redirect("/satici/mesajlar");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

