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
            if (Request.Cookies["MyCart"] != null)
                return View(JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]));
            else
                return Redirect("/");
        }
        [Route("/sepetim/sayiver")]
        public int GetCartCount()
        {
            if (Request.Cookies["MyCart"] != null)
            {
                return JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]).Sum(x => x.Quantity);
            }
            else
                return 0;
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
                bool hasProduct = false;
                if (Request.Cookies["MyCart"] != null)
                {
                    shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);

                    foreach (var item in shoppingCarts)
                    {
                        if (item.ProductId == productid)
                        {
                            hasProduct = true;
                            item.Quantity += quantity;
                            if (response.Stock < item.Quantity)
                                item.Quantity = response.Stock;
                            break;
                        }
                    }
                }
                if (hasProduct == false)
                    shoppingCarts.Add(shoppingCart);

                CookieOptions cookieOptions = new CookieOptions
                {
                    Expires = DateTime.Now.AddDays(30),
                };
                Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(shoppingCarts), cookieOptions);
                return response.Name;
            }
            return "";
        }
    }
}