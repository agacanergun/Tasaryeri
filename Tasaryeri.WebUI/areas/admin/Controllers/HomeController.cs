using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.WebUI.areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class HomeController : Controller
    {
        [Route("/admin"), AllowAnonymous]
        public IActionResult Index()
        {
            return View();
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
