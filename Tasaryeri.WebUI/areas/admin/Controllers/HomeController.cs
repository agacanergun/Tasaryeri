using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.DAL.Entities;
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
        public IActionResult Index(AdminDTO dto)
        {
            dto.Name = "agacan";
            dto.UserName = "admin1";
            dto.Surname = "ergun";
            dto.Password = "123";

            if (adminBusiness.Register(dto))
            {
                @ViewBag.Error = "KAYIT BAŞARILI";
                return View();
            }
            else
            {
                @ViewBag.Error = "KAYIT BAŞARISIZ";
                return View();
            }

        }

        [Route("/admin"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(string ReturnUrl, string Username, string Password)
        {

            return View();
        }

        [Route("/admin/logout")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
