using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Areas.saler.ViewModels;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class SalerProductController : Controller
    {
        IProductTransactions productTransactions;
        public SalerProductController(IProductTransactions productTransactions)
        {
            this.productTransactions = productTransactions;
        }
        [Route("satici/satici-ürünleri")]
        public IActionResult Index()
        {
            int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
            var response = productTransactions.GetAll(id);
            return View(response);
        }

        [Route("satici/delete")]
        public string Delete(int id)
        {
            productTransactions.Delete(id);
            return "Ok";
        }

        [Route("satici/ürün-ekle")]
        public IActionResult Add()
        {
            var response = productTransactions.GetSubCategories();
            ProductVM productVM = new ProductVM
            {
                subCategories = response,
            };
            return View(productVM);
        }

        [Route("satici/ürün-ekle"), HttpPost]
        public IActionResult Add(ProductVM productVM)
        {
            if (ModelState.IsValid)
            {
                //if (productTransactions.Add(productDTO))
                //{
                //    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                   return Redirect("satici-ürünleri");
                //}
            }
            TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("satici-ürünleri");
        }

        [Route("satici/update")]
        public IActionResult Update(int id)
        {
            return View(productTransactions.GetById(id));
        }

        [Route("satici/update"), HttpPost]
        public IActionResult Update(ProductDTO productDTO)
        {
            if (ModelState.IsValid)
            {
                if (productTransactions.Update(productDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("satici-ürünleri");
                }
            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("satici-ürünleri");
        }
    }
}
