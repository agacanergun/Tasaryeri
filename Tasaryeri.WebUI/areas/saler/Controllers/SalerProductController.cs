﻿using Microsoft.AspNetCore.Authorization;
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

        [Route("satici/urun-ekle")]
        public IActionResult Add()
        {
            var response = productTransactions.GetSubCategories();
            ProductVM productVM = new ProductVM
            {
                subCategories = response,
            };
            return View(productVM);
        }

        [Route("satici/urun-ekle"), HttpPost]
        public IActionResult Add(ProductVM productVM)
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

        [Route("satici/update")]
        public IActionResult Update(int id, string categories)
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

        [Route("satici/update"), HttpPost]
        public IActionResult Update(ProductVMUpdate productVMupd)
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
    }
}
