using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.areas.admin.ViewModels;

namespace Tasaryeri.WebUI.areas.Category.Controllers
{
    [Area("admin"), Authorize(AuthenticationSchemes = "TasaryeriAdminAuth")]
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
            MainCategoryDTO mainCategoryDTO = new MainCategoryDTO
            {
                Id = id,
            };
            categoryTransactions.Delete(mainCategoryDTO);
            return "Ok";
        }

        [Route("kategori/delete-subcategory")]
        public string DeleteSubCategory(int id)
        {
            SubCategoryDTO subCategoryDTO = new SubCategoryDTO
            {
                Id = id,
            };
            categoryTransactions.Delete(subCategoryDTO);
            return "Ok";
        }


        [Route("kategori/ana-kategori-ekle"), HttpPost]
        public IActionResult AddMainCategory(MainCategoryDTO MainCategoryDTO1)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(MainCategoryDTO1))
                {
                    TempData["AddMainCategoryInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["AddMainCategoryInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("kategori/sub-kategori-ekle"), HttpPost]
        public IActionResult AddSubCategory(SubCategoryDTO SubCategoryDTO1)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(SubCategoryDTO1))
                {
                    TempData["AddSubCatInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["AddSubCatInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("kategori/update-ana-kategori"), HttpPost]
        public IActionResult UpdateMainCategory(MainCategoryDTO MainCategoryDTO1)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(MainCategoryDTO1))
                {
                    TempData["UpdateMainCatInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["UpdateMainCatInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }

        [Route("kategori/update-sub-kategori"), HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryDTO SubCategoryDTO1)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(SubCategoryDTO1))
                {
                    TempData["UpdateSubCatInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("kategoriler");
                }
            }
            TempData["UpdateSubCatInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("kategoriler");
        }
    }
}

