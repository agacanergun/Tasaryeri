using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ISlideTransactions slideTransactions;
        ICategoryTransactions categoryTransactions;
        IProductTransactionsUI productTransactionsUI;
        public HomeController(ISlideTransactions slideTransactions, ICategoryTransactions categoryTransactions, IProductTransactionsUI productTransactionsUI)
        {
            this.slideTransactions = slideTransactions;
            this.categoryTransactions = categoryTransactions;
            this.productTransactionsUI = productTransactionsUI;
        }
        public IActionResult Index()
        {
            var responseSlides = slideTransactions.GetAll();
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

            var randomProducts = productTransactionsUI.GetRandom();

            HomeIndexVM vm = new HomeIndexVM
            {
                Slides = responseSlides,
                Categories = groupedCategories,
                RandomProducts = randomProducts,
            };

            return View(vm);
        }
 
        public IActionResult InstitutionalAndAboutUs(string name, string Description)
        {
            InstitutionalAndAboutUsVM institutionalAndAboutUsVM = new InstitutionalAndAboutUsVM
            {
                Name = name,
                Description = Description,
            };
            return View(institutionalAndAboutUsVM);
        }


    }
}

