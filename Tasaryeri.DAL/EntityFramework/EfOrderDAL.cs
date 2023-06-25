using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.Core.Interfaces;
using Tasaryeri.DAL.Entities;
using Tasaryeri.DAL.EntityFramework.Abstract;

namespace Tasaryeri.DAL.EntityFramework
{
    public class EfOrderDAL : IEfOrderDAL
    {
        IRepository<Order> repoOrder;
        IRepository<Member> repoMember;
        IRepository<Product> repoProduct;
        public EfOrderDAL(IRepository<Order> repoOrder, IRepository<Member> repoMember, IRepository<Product> repoProduct)
        {
            this.repoOrder = repoOrder;
            this.repoMember = repoMember;
            this.repoProduct = repoProduct;
        }
        public bool AddOrder(List<Order> orders)
        {
            var member = repoMember.GetBy(x => x.Id == orders.FirstOrDefault().MemberID);
            foreach (var item in orders)
            {
                item.Name = member.Name;
                item.Surname = member.Surname;
                item.Phone = member.PhoneNumber;
                item.Mail = member.Email;
                item.OrderStatus = Enums.EOrderStatus.Hazırlanıyor;
            }

            foreach (var item in orders)
            {
                var response = repoProduct.GetAll(x => x.Id == item.ProductID).Include(x => x.ProductPictures).ToList();
                item.ProductName = response.FirstOrDefault().Name;
                item.Picture = response.FirstOrDefault().ProductPictures?.FirstOrDefault()?.Picture;
                item.Price = response.FirstOrDefault().Price * item.Quantity;
                item.SalerID = response.FirstOrDefault().SalerId;
            }
            var responseAdd = repoOrder.AddRange(orders);
            if (responseAdd > 0)
                return true;
            return false;
        }

        public IEnumerable<Order> GetMemberOrders(int id)
        {
            return repoOrder.GetAll(x => x.MemberID == id);
        }

        public IEnumerable<Order> GetSalerOrders(int id)
        {
            return repoOrder.GetAll(x => x.SalerID == id);
        }

        public bool UpdateOrderStatus(Order order)
        {
            var response = repoOrder.GetBy(x => x.ID == order.ID);
            response.OrderStatus = order.OrderStatus;
            var updateResponse = repoOrder.Update(response);
            if (updateResponse == 1)
                return true;
            return false;
        }
    }
}
