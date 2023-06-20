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
                int salerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var oldMessages = messageTransactions.GetOldMessagesForSaler(salerId);
                return View(oldMessages);
            }

            [Route("satici/mesaj-gonder")]
            public IActionResult SendMessage(int salerId, int productId)
            {
                var saler = messageTransactions.GetSaler(salerId);
                int memberId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var oldMessages = messageTransactions.GetOldMessagesForMember(memberId);
                var messages = messageTransactions.GetMessages(salerId, memberId, productId);
                var product = messageTransactions.GetProduct(productId);
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
                    Messages = messages,
                    productDTO = product,
                    OldMessages = oldMessages,
                };
                return View(sendMessageVM);
            }
            [Route("satici/mesaj-gonder"), HttpPost]
            public IActionResult SendMessage(MessageDTO messageDTO)
            {
                messageDTO.Timestamp = DateTime.Now;
                messageDTO.Sender = "Member";
                var response = messageTransactions.SendMessage(messageDTO);
                int memberId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var oldMessages = messageTransactions.GetOldMessagesForMember(memberId);
                var saler = messageTransactions.GetSaler(messageDTO.SalerId);
                var messages = messageTransactions.GetMessages(messageDTO.SalerId, messageDTO.MemberId, messageDTO.ProductId);
                var product = messageTransactions.GetProduct(messageDTO.ProductId);

                SendMessageVM sendMessageVM = new SendMessageVM
                {
                    MessageDTO = messageDTO,
                    SalerDTO = saler,
                    Messages = messages,
                    productDTO = product,
                    OldMessages = oldMessages,
                };
                return View(sendMessageVM);
            }
        }
    }

