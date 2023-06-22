﻿using Microsoft.AspNetCore.Authorization;
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

        [Route("/sepetim/sil")]
        public string RemoveCart(int productid)
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
        [Route("/sepetim/tamamla"), Authorize(AuthenticationSchemes = "TasaryeriMemberAuth")]
        public IActionResult Complete()
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
        [Route("/sepetim/tamamla"), Authorize(AuthenticationSchemes = "TasaryeriMemberAuth"), HttpPost]
        public IActionResult Complete(CompleteOrderVM completeOrderVM)
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
    }
}