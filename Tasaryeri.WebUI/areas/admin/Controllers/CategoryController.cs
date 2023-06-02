using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

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
        [Route("category/categoryler")]
        public IActionResult Index()
        {
            //tüm main ve alt kategoriler gönderilecek

            return View();
        }

        [Route("category/delete-maincategory")]
        public string DeleteMainCategory(int id)
        {
         
            return "Ok";
        }

        [Route("category/delete-subcategory")]
        public string DeleteSubCategory(int id)
        {

            return "Ok";
        }


        [Route("category/Ana-category-ekle"), HttpPost]
        public IActionResult AddMainCategory(MainCategoryDTO MainCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(MainCategoryDTO))
                {
                    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("category");
                }
            }
            TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("categoryler");
        }

        [Route("category/Sub-Category-ekle"), HttpPost]
        public IActionResult AddSubCategory(SubCategoryDTO SubCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Add(SubCategoryDTO))
                {
                    TempData["AddInfo"] = "<span style='color:green'>Ekleme İşlemi Başarılı</span>";
                    return Redirect("categoryler");
                }
            }
            TempData["AddInfo"] = "<span style='color:red'>Ekleme İşlemi Başarısız</span>";
            return Redirect("categoryler");
        }

        [Route("category/update-ana-kategori"), HttpPost]
        public IActionResult UpdateMainCategory(MainCategoryDTO MainCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(MainCategoryDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("categoryler");
                }
            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("categoryler");
        }

        [Route("category/update-sub-kategori"), HttpPost]
        public IActionResult UpdateSubCategory(SubCategoryDTO SubCategoryDTO)
        {
            if (ModelState.IsValid)
            {
                if (categoryTransactions.Update(SubCategoryDTO))
                {
                    TempData["UpdateInfo"] = "<span style='color:green'>Güncelleme İşlemi Başarılı</span>";
                    return Redirect("categoryler");
                }
            }
            TempData["UpdateInfo"] = "<span style='color:red'>Güncelleme İşlemi Başarısız</span>";
            return Redirect("categoryler");
        }
    }
}

