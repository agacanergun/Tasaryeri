using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Abstract;
using Tasaryeri.BL.Dtos;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;
using Tasaryeri.DAL.Enums;

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

        public IEnumerable<OrderDTO> GetMemberOrders(int id)
        {
            var response = efOrderDAL.GetMemberOrders(id);
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (var item in response)
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    Address = item.Address,
                    City = item.City,
                    Detail = item.Detail,
                    ID = item.ID,
                    Mail = item.Mail,
                    Member = item.Member,
                    MemberID = item.MemberID,
                    Name = item.Name,
                    OrderNumber = item.OrderNumber,
                    OrderStatus = item.OrderStatus,
                    Phone = item.Phone,
                    Picture = item.Picture,
                    Price = item.Price,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    ProductName = item.ProductName,
                    RecDate = item.RecDate,
                    SalerID = item.SalerID,
                    Surname = item.Surname,
                    ZipCode = item.ZipCode,
                };
                orders.Add(orderDTO);
            }
            return orders;
        }

        public IEnumerable<OrderDTO> GetSalerOrders(int id)
        {
            var response = efOrderDAL.GetSalerOrders(id);
            List<OrderDTO> orders = new List<OrderDTO>();
            foreach (var item in response)
            {
                OrderDTO orderDTO = new OrderDTO
                {
                    Address = item.Address,
                    City = item.City,
                    Detail = item.Detail,
                    ID = item.ID,
                    Mail = item.Mail,
                    Member = item.Member,
                    MemberID = item.MemberID,
                    Name = item.Name,
                    OrderNumber = item.OrderNumber,
                    OrderStatus = item.OrderStatus,
                    Phone = item.Phone,
                    Picture = item.Picture,
                    Price = item.Price,
                    ProductID = item.ProductID,
                    Quantity = item.Quantity,
                    ProductName = item.ProductName,
                    RecDate = item.RecDate,
                    SalerID = item.SalerID,
                    Surname = item.Surname,
                    ZipCode = item.ZipCode,
                };
                orders.Add(orderDTO);
            }
            return orders;
        }

        public bool UpdateOrderStatus(int id, string status)
        {
            Order order = new Order
            {
                ID = id,
            };
            switch (status)
            {
                case nameof(EOrderStatus.Hazırlanıyor):
                    order.OrderStatus = EOrderStatus.Hazırlanıyor;
                    break;
                case nameof(EOrderStatus.Paketlendi):
                    order.OrderStatus = EOrderStatus.Paketlendi;
                    break;
                case nameof(EOrderStatus.KargoyaVerildi):
                    order.OrderStatus = EOrderStatus.KargoyaVerildi;
                    break;
                case nameof(EOrderStatus.TeslimEdildi):
                    order.OrderStatus = EOrderStatus.TeslimEdildi;
                    break;
                case nameof(EOrderStatus.İptalEdildi):
                    order.OrderStatus = EOrderStatus.İptalEdildi;
                    break;
            }
            return efOrderDAL.UpdateOrderStatus(order);
        }
    }
}
