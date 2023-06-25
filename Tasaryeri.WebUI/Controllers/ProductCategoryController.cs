using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Concreate;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        IProductTransactionsUI productTransactionsUI;
        ICategoryTransactions categoryTransactions;
        public ProductCategoryController(IProductTransactionsUI productTransactionsUI, ICategoryTransactions categoryTransactions)
        {
            this.productTransactionsUI = productTransactionsUI;
            this.categoryTransactions = categoryTransactions;

        }
        public IActionResult Index(int id)
        {
            try
            {
                var response = productTransactionsUI.GetAll(id);
                var responseCategories = categoryTransactions.GetAllSubCategories();

                var groupedCategories = responseCategories
                    .GroupBy(x => x.MainCategoryDTO.Name)
                    .Select(group => new MainCategoryDTO
                    {
                        Name = group.Key,
                        subCategoriesDTO = group.ToList(),
                        DisplayIndex = group.First().MainCategoryDTO.DisplayIndex

                    })
                    .ToList();
                ProductCategoryVM productCategoryVM = new ProductCategoryVM
                {
                    Categories = groupedCategories,
                    productDTOs = response,
                };
                return View(productCategoryVM);
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("Urun-Detayi/{name}-{id}")]
        public IActionResult ProductDetail(string name, int id)
        {
            try
            {
                var randomProducts = productTransactionsUI.GetRandom();
                var responseProduct = productTransactionsUI.GetProduct(id);
                ProductDetailVM productDetailVM = new ProductDetailVM
                {
                    productDTO = responseProduct,
                    productDTOs = randomProducts,
                };
                return View(productDetailVM);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}