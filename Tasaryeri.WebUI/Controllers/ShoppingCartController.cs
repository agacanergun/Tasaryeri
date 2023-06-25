using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Security.Claims;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Models;
using Tasaryeri.WebUI.ViewModels;

namespace Tasaryeri.WebUI.Controllers
{
    public class ShoppingCartController : Controller
    {
        IProductTransactionsUI ProductTransactionsUI;
        IOrderTransactions OrderTransactions;
        public ShoppingCartController(IProductTransactionsUI ProductTransactionsUI, IOrderTransactions orderTransactions)
        {
            this.ProductTransactionsUI = ProductTransactionsUI;
            OrderTransactions = orderTransactions;

        }

        [Route("/sepetim")]
        public IActionResult Index()
        {
            try
            {
                if (Request.Cookies["MyCart"] != null)
                {
                    var carts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                    if (carts.Count() == 0)
                        return Redirect("/");
                    return View(JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]));
                }
                else
                    return Redirect("/");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("sepetim/arttir")]
        public int PlusQuantity(int productid)
        {
            try
            {
                var carts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                foreach (var item in carts)
                {
                    if (item.ProductId == productid)
                    {
                        var response = ProductTransactionsUI.GetProduct(item.ProductId);
                        item.Quantity++;
                        if (response.Stock < item.Quantity)
                            return response.Stock;
                        CookieOptions cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(30),
                        };
                        Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
                        return item.Quantity;
                    }
                }
                return -1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("sepetim/azalt")]
        public int MinusQuantity(int productid)
        {
            try
            {
                var carts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                foreach (var item in carts)
                {
                    if (item.ProductId == productid)
                    {
                        item.Quantity--;
                        if (item.Quantity == 0)
                        {
                            carts.Remove(item);
                            CookieOptions cookieOptions1 = new CookieOptions
                            {
                                Expires = DateTime.Now.AddDays(30),
                            };
                            Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions1);

                        }
                        CookieOptions cookieOptions = new CookieOptions
                        {
                            Expires = DateTime.Now.AddDays(30),
                        };
                        Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(carts), cookieOptions);
                        return item.Quantity;
                    }
                }
                return -1;

            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/sepetim/sayiver")]
        public int GetCartCount()
        {
            try
            {
                if (Request.Cookies["MyCart"] != null)
                {
                    return JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]).Sum(x => x.Quantity);
                }
                else
                    return 0;
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/sepetim/sil")]
        public string RemoveCart(int productid)
        {
            try
            {
                if (Request.Cookies["MyCart"] != null)
                {
                    List<ShoppingCart> shoppingCarts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                    shoppingCarts.Remove(shoppingCarts.FirstOrDefault(x => x.ProductId == productid));
                    CookieOptions cookieOptions = new CookieOptions
                    {
                        Expires = DateTime.Now.AddDays(30),
                    };
                    Response.Cookies.Append("MyCart", JsonConvert.SerializeObject(shoppingCarts), cookieOptions);
                    return "Ok";
                }
                else
                    return "";
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/sepetim/ekle")]
        public string AddCart(int productid, int quantity)
        {
            try
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
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/sepetim/tamamla"), Authorize(AuthenticationSchemes = "TasaryeriMemberAuth")]
        public IActionResult Complete()
        {
            try
            {
                if (Request.Cookies["MyCart"] != null)
                {
                    var carts = JsonConvert.DeserializeObject<List<ShoppingCart>>(Request.Cookies["MyCart"]);
                    if (carts.Count() == 0)
                        return Redirect("/");
                    List<OrderInfoDTO> orders = new List<OrderInfoDTO>();
                    foreach (var item in carts)
                    {
                        OrderInfoDTO orderInfoDTO = new OrderInfoDTO
                        {
                            ProductName = item.Name,
                            ProductId = item.ProductId,
                            Quantity = item.Quantity,
                        };
                        orders.Add(orderInfoDTO);
                    }

                    CompleteOrderVM completeOrderVM = new CompleteOrderVM
                    {
                        ShoppingCart = carts,
                        orderInfoDTOs = orders,
                    };
                    return View(completeOrderVM);
                }
                else
                    return Redirect("/");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/sepetim/tamamla"), Authorize(AuthenticationSchemes = "TasaryeriMemberAuth"), HttpPost]
        public IActionResult Complete(CompleteOrderVM completeOrderVM)
        {
            try
            {
                completeOrderVM.orderDTO.MemberID = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                AddOrderDTO addOrderDTO = new AddOrderDTO
                {
                    orderDTO = completeOrderVM.orderDTO,
                    orderInfoDTOs = completeOrderVM.orderInfoDTOs,
                };
                if (OrderTransactions.AddOrder(addOrderDTO))
                {
                    Response.Cookies.Delete("MyCart");
                    return Redirect("/");
                }
                return Redirect("/");
            }
            catch (Exception)
            {

                throw;
            }
        }

        [Route("/siparislerim"), Authorize(AuthenticationSchemes = "TasaryeriMemberAuth")]
        public IActionResult Orders()
        {
            try
            {
                int memberId = int.Parse(HttpContext.User.FindFirst(ClaimTypes.PrimarySid)?.Value);
                var response = OrderTransactions.GetMemberOrders(memberId);
                return View(response);
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}