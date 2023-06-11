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
        [Route("satici/ürün-resimleri")]
        public IActionResult Index(int productid)
        {
            var response = productPictureTransactions.GetAll(productid);
            ViewBag.ProductID = productid;
            ProductPictureVM productPictureVM = new ProductPictureVM
            {
                productPictureDTOs = response,
            };
            return View(productPictureVM);

        }

        [Route("satici/ürün-resimleri-ekle")]
        public IActionResult Add(int productId)
        {
            return View();
        }

        [Route("satici/ürün-resimleri-ekle"), HttpPost]
        public IActionResult Add(ProductPictureDTO productPictureDTO)
        {
            return Redirect("ürün-resimleri");
        }

        [Route("satici/ürün-resimleri-düzenle")]
        public IActionResult Edit(int pictureId)
        {
            return View();
        }

        [Route("satici/ürün-resimleri-düzenle"), HttpPost]
        public IActionResult Edit(ProductPictureDTO productPictureDTO)
        {
            return Redirect("ürün-resimleri");
        }

        public string Delete(int id)
        {
            return "OK";
        }
    }
}
