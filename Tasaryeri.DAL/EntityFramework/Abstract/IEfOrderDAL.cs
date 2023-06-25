using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.EntityFramework.Abstract
{
    public interface IEfOrderDAL
    {
        public bool AddOrder(List<Order> orders);
        public IEnumerable<Order> GetMemberOrders(int id);
        public IEnumerable<Order> GetSalerOrders(int id);
        public bool UpdateOrderStatus(Order order);
    }
}
