using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Areas.saler.ViewModels;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class ProductPictureController : Controller
    {
        IProductPictureTransactions productPictureTransactions;
        public ProductPictureController(IProductPictureTransactions productPictureTransactions)
        {
            this.productPictureTransactions = productPictureTransactions;
        }
        [Route("satici/urun-resimleri")]
        public IActionResult Index(int productid)
        {
            var response = productPictureTransactions.GetAll(productid);
            ProductPictureDTO productPictureDTO1 = new ProductPictureDTO
            {
                ProductID = productid,
            };
            ProductPictureVM productPictureVM = new ProductPictureVM
            {
                productPictureDTOs = response,
                productPictureDTO = productPictureDTO1,
            };
            return View(productPictureVM);

        }

        [Route("satici/urun-resimleri-ekle")]
        public IActionResult Add(int productId)
        {
            ProductPictureDTO productPictureDTO = new ProductPictureDTO
            {
                ProductID = productId
            };
            return View(productPictureDTO);
        }

        [Route("satici/urun-resimleri-ekle"), HttpPost]
        public IActionResult Add(ProductPictureDTO productPictureDTO)
        {
            if (ModelState.IsValid)
            {
                if (productPictureTransactions.Add(productPictureDTO))
                {
                    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return RedirectToAction("Index", "ProductPicture", new { productid = productPictureDTO.ProductID });
                }
                TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";

            }
            return RedirectToAction("Index", "ProductPicture", new { productid = productPictureDTO.ProductID });
        }

        [Route("satici/urun-resimleri-düzenle")]
        public IActionResult Edit(int id)
        {
            var response = productPictureTransactions.GetById(id);
            return View(response);
        }

        [Route("satici/urun-resimleri-düzenle"), HttpPost]
        public IActionResult Edit(ProductPictureDTO productPictureDTO)
        {
            if (ModelState.IsValid)
            {
                if (productPictureTransactions.Update(productPictureDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return RedirectToAction("Index", "ProductPicture", new { productid = productPictureDTO.ProductID });
                }

            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return RedirectToAction("Index", "ProductPicture", new { productid = productPictureDTO.ProductID });
        }

        [Route("satici/delete-görsel")]
        public string Delete(int id)
        {
            productPictureTransactions.Delete(id);
            return "Ok";
        }
    }
}
