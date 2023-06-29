using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IOrderTransactions
    {
       bool AddOrder(AddOrderDTO addOrderDTO);
       IEnumerable<OrderDTO> GetMemberOrders(int id);
       IEnumerable<OrderDTO> GetSalerOrders(int id);
       bool UpdateOrderStatus(int id, string status);
    }
}
