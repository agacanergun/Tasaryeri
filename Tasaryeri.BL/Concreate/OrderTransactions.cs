using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.BL.Concreate
{
    public class OrderTransactions : IOrderTransactions
    {
        IEfOrderDAL efOrderDAL;
        public OrderTransactions(IEfOrderDAL efOrderDAL)
        {
            this.efOrderDAL = efOrderDAL;
        }
        public bool AddOrder(AddOrderDTO addOrderDTO)
        {
            List<Order> orders = new List<Order>();

            foreach (var item in addOrderDTO.orderInfoDTOs)
            {
                Order order = new Order
                {
                    MemberID = addOrderDTO.orderDTO.MemberID,
                    OrderNumber = Guid.NewGuid().ToString(),
                    Address = addOrderDTO.orderDTO.Address,
                    City = addOrderDTO.orderDTO.City,
                    ZipCode = addOrderDTO.orderDTO.ZipCode,
                    RecDate = DateTime.Now,
                    ProductID = item.ProductId,
                    Quantity = item.Quantity,
                    Detail = item.Detail,
                };
                orders.Add(order);
            }
            return efOrderDAL.AddOrder(orders);
        }
    }
}
