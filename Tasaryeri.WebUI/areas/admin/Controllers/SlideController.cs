using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.WebUI.Areas.admin.ViewModels;

namespace Tasaryeri.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class SlideController : Controller
    {
        ISlideTransactions slideTransactions;
        public SlideController(ISlideTransactions slideTransactions)
        {
            this.slideTransactions = slideTransactions;
        }

        [Route("slide/slidelar")]
        public IActionResult Index()
        {
            var response = slideTransactions.GetAll();
            SlideVM slideVM = new SlideVM
            {
                SlideDTOList = response,
            };
            return View(slideVM);
        }

        [Route("slide/delete")]
        public string Delete(int id)
        {
            //adminBusiness.Delete(id);
            return "Ok";
        }



    }
}
