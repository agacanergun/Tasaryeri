using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
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

            HomeIndexVM vm = new HomeIndexVM
            {
                Slides = responseSlides,
                Categories = responseCategories
            };

            return View(vm);
        }

    }
}

