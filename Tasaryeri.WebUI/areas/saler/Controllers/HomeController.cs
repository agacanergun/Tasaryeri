using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.saler.Controllers
{
    [Area("saler"), Authorize]
    public class HomeController : Controller
    {
        ISalerLoginTransactions salerLoginTransactions;
        public HomeController(ISalerLoginTransactions salerLoginTransactions)
        {
            this.salerLoginTransactions = salerLoginTransactions;
        }

        [Route("/saler"), AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/saler"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(SalerLoginDTO salerLoginDTO)
        {
            //saler paneline giriş için cookie oluşturma
            var response = salerLoginTransactions.Login(salerLoginDTO);

            if (response.Id != 0)
            {
                SalerLoginDTO salerLoginDTOResponse = new SalerLoginDTO
                {
                    Id = response.Id,
                    Age = response.Age,
                    Email = response.Email,
                    Gender = response.Gender,
                    Name = response.Name,
                    Password = response.Password,
                    PhoneNumber = response.PhoneNumber,
                    Surname = response.Surname,
                    Username = response.Username,
                };
                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid,salerLoginDTOResponse.Id.ToString()),
                    new Claim(ClaimTypes.Name,salerLoginDTOResponse.Name),
                    new Claim(ClaimTypes.Surname,salerLoginDTOResponse.Surname),
                    new Claim(ClaimTypes.Email,salerLoginDTOResponse.Email),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "TasaryeriSalerAuth");
                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
                if (string.IsNullOrEmpty(salerLoginDTO.ReturnUrl))
                    return Redirect("/saler/ürünler");
                else return Redirect(salerLoginDTO.ReturnUrl);
            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        [Route("/saler/logout")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
