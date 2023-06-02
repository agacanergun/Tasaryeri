﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.areas.admin.ViewModels;

namespace Tasaryeri.WebUI.areas.Category.Controllers
{
    [Area("admin"), Authorize]
    public class CategoryController : Controller
    {

        ICategoryTransactions categoryTransactions;
        public CategoryController(ICategoryTransactions categoryTransactions)
        {
            this.categoryTransactions = categoryTransactions;
        }
        [Route("kategori/kategoriler")]
        public IActionResult Index()
        {
            var responseMainCategories = categoryTransactions.GetAllMainCategories();
            var responseSubCategories = categoryTransactions.GetAllSubCategories();
            CategoryVM categoryVM = new CategoryVM
            {
                MainCategoryDTO = responseMainCategories,
                SubCategoryDTO = responseSubCategories,
            };
            return View(categoryVM);
        }

        [Route("kategori/delete-maincategory")]
        public string DeleteMainCategory(int id)
        {

            return "Ok";
        }

        [Route("kategori/delete-subcategory")]
        public string DeleteSubCategory(int id)
        {

            return "Ok";
        }


        [Route("kategori/ana-kategori-ekle"), HttpPost]
        public IActionResult AddMainCategory(MainCategoryDTO MainCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(MainCategoryDTO))
                {
                    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("kategori/sub-kategori-ekle"), HttpPost]
        public IActionResult AddSubCategory(SubCategoryDTO SubCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(SubCategoryDTO))
                {
                    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("category/update-ana-kategori"), HttpPost]
        public IActionResult UpdateMainCategory(MainCategoryDTO MainCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(MainCategoryDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("kategori/update-sub-kategori"), HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryDTO SubCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(SubCategoryDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }
    }
}

