using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
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
            //admin paneline giriş için cookie oluşturma
            var response = adminBusiness.Login(adminLoginDTO);

            if (response.Id != 0)
            {
                AdminLoginDTO adminLoginDTOResponse = adminBusiness.Login(adminLoginDTO);
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,adminLoginDTOResponse.Id.ToString()),
                    new Claim(ClaimTypes.Name,adminLoginDTO.UserName)
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "TasaryeriAuth");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
                if (string.IsNullOrEmpty(adminLoginDTO.ReturnUrl))
                    return Redirect("/admin/adminler");
                else return Redirect(adminLoginDTO.ReturnUrl);
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
