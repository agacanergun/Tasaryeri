using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Tasaryeri.BL.Abstract;
using Tasaryeri.WebUI.Models;

namespace Tasaryeri.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductTransactionsUI ProductTransactionsUI;
        public ShoppingCartController(IProductTransactionsUI ProductTransactionsUI)
        {
            this.ProductTransactionsUI = ProductTransactionsUI;
        }
        [Route("/sepetim")]
        public IActionResult Index()
        {
            //1.02.47
            return View();
        }
        [Route("/sepetim/ekle")]
        public string AddCart(int productid, int quantity)
        {
            var response = ProductTransactionsUI.GetProduct(productid);
            if (response != null)
            {

                ShoppingCart shoppingCart = new ShoppingCart
                {
                    ProductId = response.Id,
                    Name = response.Name,
                    Price = response.Price,
                    Quantity = quantity,
                    Picture = response.ProductPictures.Any() ?
                    response.ProductPictures.FirstOrDefault().Picture : "/assetsUI/img/görsel-hazirlaniyor.jpg"

                };
                List<ShoppingCart> shoppingCarts = new List<ShoppingCart>();
                if (Request.Cookies["MyCart"] != null)
                {
                    shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                    foreach (var item in shoppingCarts)
                    {
                        if (item.ProductId == productid)
                        {
                            item.Quantity += quantity;
                            break;
                        }
                    }
                    return response.Name;
                }
                else
                {
                    shoppingCarts.Add(shoppingCart);
                    CookieOptions cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30),
                    };
                    Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(shoppingCarts), cookieOptions);
                    return response.Name;
                }
            }
            return "";
        }
    }
}