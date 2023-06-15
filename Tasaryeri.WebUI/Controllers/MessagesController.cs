using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Tasaryeri.WebUI.Controllers
{
    [Authorize(AuthenticationSchemes = "TasaryeriMemberAuth")]
    public class MessagesController : Controller
    {
        [Route("uye/mesajlar")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
