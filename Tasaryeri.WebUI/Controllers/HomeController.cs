using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Controllers
{
    public class HomeController : Controller
    {
        ISlideTransactions slideTransactions;
        public HomeController(ISlideTransactions slideTransactions)
        {
            this.slideTransactions = slideTransactions;
        }
        public IActionResult Index()
        {
            var response = slideTransactions.GetAll();
            HomeIndexVM vm = new HomeIndexVM
            {
                Slides = response
            };

            return View(vm);
        }

    }
}

