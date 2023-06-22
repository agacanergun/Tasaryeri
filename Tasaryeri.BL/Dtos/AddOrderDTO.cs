using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.BL.Dtos
{
    public class AddOrderDTO
    {
        public List<OrderInfoDTO> orderInfoDTOs { get; set; }
        public OrderDTO orderDTO { get; set; }
    }
}
