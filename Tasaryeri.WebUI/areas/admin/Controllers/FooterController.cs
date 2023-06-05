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

        [Route("footer/kontak-ekle"), HttpPost]
        public IActionResult AddContact(ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.AddContact(contactDTO))
                {
                    TempData["AddContactInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kontak");
                }
            }
            TempData["AddContactInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kontak");
        }

        [Route("footer/kontak-sil"),]
        public string DeleteContact(int id)
        {
            ContactDTO contactDTO = new ContactDTO
            {
                Id = id,
            };
            footerTransactions.DeleteContact(contactDTO);
            return "Ok";
        }

        [Route("footer/kontak-güncelle"), HttpPost]
        public IActionResult UpdateContact(ContactDTO contactDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.UpdateContact(contactDTO))
                {
                    TempData["UpdateContactInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kontak");
                }
            }
            TempData["UpdateContactInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kontak");
        }




        [Route("footer/hakkimizda")]
        public IActionResult AboutUs()
        {
            var response = footerTransactions.GetAboutUs();
            AboutUsVM vm = new AboutUsVM
            {
                AboutUsDTOs = response,
            };
            return View(vm);
        }

        [Route("footer/hakkimizda-ekle"), HttpPost]
        public IActionResult AddAboutUs(AboutUsDTO aboutUsDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.AddAboutUs(aboutUsDTO))
                {
                    TempData["AddAboutUsInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("hakkimizda");
                }
            }
            TempData["AddAboutUsInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("hakkimizda");
        }

        [Route("footer/hakkimizda-sil"),]
        public string DeleteAboutUs(int id)
        {
            AboutUsDTO aboutUsDTO = new AboutUsDTO
            {
                Id = id,
            };
            footerTransactions.DeleteAboutUs(aboutUsDTO);
            return "Ok";
        }

        [Route("footer/hakkimizda-güncelle"), HttpPost]
        public IActionResult UpdateAboutUs(AboutUsDTO aboutUsDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.UpdateAboutUs(aboutUsDTO))
                {
                    TempData["UpdateAboutUsInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("hakkimizda");
                }
            }
            TempData["UpdateAboutUsInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("hakkimizda");
        }



        [Route("footer/kurumsal")]
        public IActionResult Institutional()
        {
            var response = footerTransactions.GetInstitutionals();
            InstitutionalVM ınstitutionalVM = new InstitutionalVM
            {
                InstitutionalDTOs = response,
            };
            return View(ınstitutionalVM);
        }

        [Route("footer/kurumsal-ekle"), HttpPost]
        public IActionResult AddInstitutional(InstitutionalDTO InstitutionalDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.AddInstitutional(InstitutionalDTO))
                {
                    TempData["AddInstitutionalInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kurumsal");
                }
            }
            TempData["AddInstitutionalInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kurumsal");
        }

        [Route("footer/kurumsal-sil"),]
        public string DeleteInstitutional(int id)
        {
            InstitutionalDTO InstitutionalDTO = new InstitutionalDTO
            {
                Id = id,
            };
            footerTransactions.DeleteInstitutional(InstitutionalDTO);
            return "Ok";
        }

        [Route("footer/kurumsal-güncelle"), HttpPost]
        public IActionResult UpdateInstitutional(InstitutionalDTO InstitutionalDTO)
        {
            if (ModelState.IsValid)
            {
                if (footerTransactions.UpdateInstitutional(InstitutionalDTO))
                {
                    TempData["UpdateInstitutionalInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kurumsal");
                }
            }
            TempData["UpdateInstitutionalInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kurumsal");
        }
    }
}
