﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.BL.Dtos;

namespace Tasaryeri.BL.Abstract
{
    public interface IOrderTransactions
    {
        public bool AddOrder(AddOrderDTO addOrderDTO);
        public IEnumerable<OrderDTO> GetMemberOrders(int id);
        public IEnumerable<OrderDTO> GetSalerOrders(int id);
        public bool UpdateOrderStatus(int id, string status);
    }
}