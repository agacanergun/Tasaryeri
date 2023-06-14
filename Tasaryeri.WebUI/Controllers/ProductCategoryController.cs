using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;

namespace Tasaryeri.WebUI.Controllers
{
    public class ProductCategoryController : Controller
    {
        IProductTransactionsUI productTransactionsUI;
        public ProductCategoryController(IProductTransactionsUI productTransactionsUI)
        {
            this.productTransactionsUI = productTransactionsUI;
        }
        public IActionResult Index(int id)
        {
            return View();
        }
    }
}
