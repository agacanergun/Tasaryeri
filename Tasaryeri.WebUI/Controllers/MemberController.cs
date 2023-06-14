using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Controllers
{
    public class MemberController : Controller
    {
        IMemberLoginTransactions MemberLoginTransactions;
        public MemberController(IMemberLoginTransactions MemberLoginTransactions)
        {
            this.MemberLoginTransactions = MemberLoginTransactions;
        }

        [Route("/uye"), AllowAnonymous]
        public IActionResult Index(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;
            return View();
        }

        [Route("/uye"), HttpPost, AllowAnonymous]
        public async Task<IActionResult> Index(MemberLoginDTO MemberLoginDTO)
        {
            //Member paneline giriş için cookie oluşturma
            var response = MemberLoginTransactions.Login(MemberLoginDTO);

            if (response.Id != 0)
            {
                MemberLoginDTO MemberLoginDTOResponse = new MemberLoginDTO
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
                    new Claim(ClaimTypes.PrimarySid,MemberLoginDTOResponse.Id.ToString()),
                    new Claim(ClaimTypes.Name,MemberLoginDTOResponse.Name),
                    new Claim(ClaimTypes.Surname,MemberLoginDTOResponse.Surname),
                    new Claim(ClaimTypes.Email,MemberLoginDTOResponse.Email),
                };
                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "TasaryeriMemberAuth");
                await HttpContext.SignInAsync("TasaryeriMemberAuth", new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties() { IsPersistent = true });
                if (string.IsNullOrEmpty(MemberLoginDTO.ReturnUrl))

                    return Redirect("/");
                else return Redirect(MemberLoginDTO.ReturnUrl);
            }
            else
            {
                ViewBag.Error = "Geçersiz Kullanıcı Adı veya Şifre";
                return View();
            }
        }

        [Route("/uye/kayıt-ol"), HttpPost, AllowAnonymous]
        public IActionResult Register(MemberLoginDTO MemberLoginDTO)
        {
            if (ModelState.IsValid)
            {
                var response = MemberLoginTransactions.Register(MemberLoginDTO);
                if (response)
                {
                    TempData["RegisterInfo"] = "<span style='color:green'>Kayıt İşleminiz Başarılı</span>";
                    return Redirect("/uye");
                }
                else
                {
                    TempData["RegisterInfo"] = "<span style='color:red'>Kayıt İşleminiz Başarısız Kullanıcı Adı Veya E-mail Kayıtlı</span>";
                    return Redirect("/uye");
                }
            }
            TempData["RegisterInfo"] = "<span style='color:red'>Kayıt İşleminiz Başarısız</span>";
            return Redirect("/uye");
        }


        [Route("/uye/logout")]
        public async Task<IActionResult> LogOut()
        {

            await HttpContext.SignOutAsync();
            return Redirect("/");
        }
    }
}
