using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.Controllers
{
    [Area("admin"), Authorize(AuthenticationSchemes = "TasaryeriAdminAuth")]
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
            try
            {
                ViewBag.ReturnUrl = ReturnUrl;
                return View();

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/admin"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(AdminLoginDTO adminLoginDTO)
        {
            try
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
                    ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "TasaryeriAdminAuth");
                    await HttpContext.SignInAsync("TasaryeriAdminAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
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
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/admin/logout")]
        public async Task<IActionResult> LogOut()
        {
            try
            {
                await HttpContext.SignOutAsync();
                return Redirect("/");
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
