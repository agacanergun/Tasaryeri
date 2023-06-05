using Azure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Concreate;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.areas.admin.ViewModels;

namespace Tasaryeri.WebUI.areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class FooterController : Controller
    {
        IFooterTransactions footerTransactions;
        public FooterController(IFooterTransactions footerTransactions)
        {
            this.footerTransactions = footerTransactions;
        }
        //sosyalmedya
        [Route("footer/sosyalmedya")]
        public IActionResult Index()
        {
            var response = footerTransactions.GetSocialMedia();
            return View(response);
        }

        [Route("footer/sosyalmedya-ekle"), HttpPost]
        public IActionResult AddSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.GetSocialMedia() != null)
                {
                    TempData["AddSocialMediaInfo"] = "<span style='color:red'>Bu Kategoride Yanlızca 1 Adet Veri Ekleyebilirsiniz.</span>";
                    return Redirect("sosyalmedya");
                }
                if (footerTransactions.AddSocialMedia(socialMediaDTO))
                {
                    TempData["AddSocialMediaInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("sosyalmedya");
                }
            }
            TempData["AddSocialMediaInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("sosyalmedya");
        }

        [Route("footer/sosyalmedya-sil"),]
        public string DeleteSocialMedia(int id)
        {
            SocialMediaDTO socialMediaDTO = new SocialMediaDTO
            {
                Id = id,
            };
            footerTransactions.DeleteSocialMedia(socialMediaDTO);
            return "Ok";
        }

        [Route("footer/sosyalmedya-güncelle"), HttpPost]
        public IActionResult UpdateSocialMedia(SocialMediaDTO socialMediaDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.UpdateSocialMedia(socialMediaDTO))
                {
                    TempData["UpdateSocialMediaInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("sosyalmedya");
                }
            }
            TempData["UpdateSocialMediaInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("sosyalmedya");
        }


        [Route("footer/kontak")]
        public IActionResult Contact()
        {
            var response = footerTransactions.GetContacts();
            ContactVM contactVM = new ContactVM
            {
                ContactDTOs = response,
            };
            return View(contactVM);
        }


        [Route("footer/hakkımızda")]
        public IActionResult AboutUs()
        {
            return View();
        }


        [Route("footer/kurumsal")]
        public IActionResult Institutional()
        {
            return View();
        }
    }
}
