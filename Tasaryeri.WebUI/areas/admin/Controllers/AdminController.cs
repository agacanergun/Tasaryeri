using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;

namespace Tasaryeri.WebUI.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class AdminController : Controller
    {
        IAdminTransactions adminBusiness;
        public AdminController(IAdminTransactions adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }
        [Route("admin/adminler")]
        public IActionResult Index()
        {
            return View(adminBusiness.GetAll());
        }

    }
}
