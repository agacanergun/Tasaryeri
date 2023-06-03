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
        public HomeController(ISlideTransactions slideTransactions, ICategoryTransactions categoryTransactions)
        {
            this.slideTransactions = slideTransactions;
            this.categoryTransactions = categoryTransactions;
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

            HomeIndexVM vm = new HomeIndexVM
            {
                Slides = responseSlides,
                Categories = groupedCategories
            };

            return View(vm);
        }

    }
}

