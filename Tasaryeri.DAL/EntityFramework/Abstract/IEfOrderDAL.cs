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
        bool AddOrder(List<Order> orders);
        IEnumerable<Order> GetMemberOrders(int id);
        IEnumerable<Order> GetSalerOrders(int id);
        bool UpdateOrderStatus(Order order);
    }
}
