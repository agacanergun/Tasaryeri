using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller
    {
        IAdminTransactions adminBusiness;
        public HomeController(IAdminTransactions adminBusiness)
        {
            this.adminBusiness = adminBusiness;
        }

        [Route("/admin"), AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/admin"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(AdminLoginDTO adminLoginDTO)
        {
            if (adminBusiness.Login(adminLoginDTO))
            {

            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        [Route("/admin/logout")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
