using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Areas.admin.ViewModels;


namespace Tasaryeri.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize(AuthenticationSchemes = "TasaryeriAdminAuth")]
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
            try
            {
                var response = slideTransactions.GetAll();
                SlideVM slideVM = new SlideVM
                {
                    SlideDTOList = response,
                };
                return View(slideVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("slide/delete")]
        public string Delete(SlideDTO slideDTO)
        {
            try
            {
                slideTransactions.Delete(slideDTO);
                return "Ok";

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("slide/slide-ekle"), HttpPost]
        public IActionResult Add(SlideDTO slideDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (slideTransactions.Add(slideDTO))
                    {
                        TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                        return Redirect("slidelar");
                    }
                }
                TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
                return Redirect("slidelar");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("slide/update"), HttpPost]
        public IActionResult Update(SlideDTO slideDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    if (slideTransactions.Update(slideDTO))
                    {
                        TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                        return Redirect("slidelar");
                    }
                }
                TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
                return Redirect("slidelar");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
