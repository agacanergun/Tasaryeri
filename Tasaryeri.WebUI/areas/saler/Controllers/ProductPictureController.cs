using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class ProductPictureController : Controller
    {
        [Route("satici/ürün-resimleri")]
        public IActionResult Index(int productid)
        {
            return View();
        }

        [Route("satici/ürün-resimleri-ekle")]
        public IActionResult Add()
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
