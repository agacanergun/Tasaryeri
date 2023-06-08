using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.saler.Controllers
{
    [Area("saler"), Authorize(AuthenticationSchemes = "TasaryeriSalerAuth")]
    public class HomeController : Controller
    {
        ISalerLoginTransactions salerLoginTransactions;
        public HomeController(ISalerLoginTransactions salerLoginTransactions)
        {
            this.salerLoginTransactions = salerLoginTransactions;
        }

        [Route("/satici"), AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/satici"), HttpPost, AllowAnonymous]
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
                await HttpContext.SignInAsync("TasaryeriSalerAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
                if (string.IsNullOrEmpty(salerLoginDTO.ReturnUrl))

                    return Redirect("satici/satici-urunleri");
                else return Redirect(salerLoginDTO.ReturnUrl);
            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        [Route("/satici/kayıt-ol"), HttpPost, AllowAnonymous]
        public IActionResult Register(SalerLoginDTO salerLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var response = salerLoginTransactions.Register(salerLoginDTO);
                if (response)
                {
                    TempData["RegisterInfo"] = "<span style='color:green'>Kayıt İşleminiz Başarılı</span>";
                    return Redirect("/satici");
                }
                else
                {
                    TempData["RegisterInfo"] = "<span style='color:red'>Kayıt İşleminiz Başarısız Kullanıcı Adı Veya E-mail Kayıtlı</span>";
                    return Redirect("/satici");
                }
            }
            TempData["RegisterInfo"] = "<span style='color:red'>Kayıt İşleminiz Başarısız</span>";
            return Redirect("/satici");
        }


        [Route("/satici/logout")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
