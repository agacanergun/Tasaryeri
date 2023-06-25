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
        [Route("satici/satici-urunleri")]
        public IActionResult Index()
        {
            try
            {
                int id = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var response = productTransactions.GetAll(id);
                return View(response);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/product-delete")]
        public string Delete(int id)
        {
            try
            {
                productTransactions.Delete(id);
                return "Ok";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/urun-ekle")]
        public IActionResult Add()
        {
            try
            {
                var response = productTransactions.GetSubCategories();
                ProductVM productVM = new ProductVM
                {
                    subCategories = response,
                };
                return View(productVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/urun-ekle"), HttpPost]
        public IActionResult Add(ProductVM productVM)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = new ProductDTO();

                    productDTO = productVM.productDTO;
                    productDTO.CategoriyIDs = productVM.CategoriyIDs;
                    productDTO.SalerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                    if (productTransactions.Add(productDTO))
                    {
                        TempData["AddInfo"] = "<span style='color:green'>Ürün Ekleme İşlemi Başarılı</span>";
                        return Redirect("satici-urunleri");
                    }
                }
                TempData["AddInfo"] = "<span style='color:red'>Ürün Ekleme İşlemi Başarısız</span>";
                return Redirect("satici-urunleri");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/update")]
        public IActionResult Update(int id, string categories)
        {
            try
            {
                var response = productTransactions.GetById(id);
                var subCategories = productTransactions.GetSubCategories();

                ProductVMUpdate productVM = new ProductVMUpdate
                {
                    subCategories = subCategories,
                    productDTO = response,
                    CategoryNames = categories.Split(',')
                };

                return View(productVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("satici/update"), HttpPost]
        public IActionResult Update(ProductVMUpdate productVMupd)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    ProductDTO productDTO = new ProductDTO();
                    productDTO = productVMupd.productDTO;
                    productDTO.CategoriyIDs = productVMupd.CategoriyIDs;
                    productDTO.SalerId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);

                    if (productTransactions.Update(productDTO))
                    {
                        TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                        return Redirect("satici-urunleri");
                    }
                }
                TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
                return Redirect("satici-urunleri");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
