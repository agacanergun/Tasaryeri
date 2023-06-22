using Tasaryeri.BL.Dtos;
using Tasaryeri.WebUI.Models;

namespace Tasaryeri.WebUI.ViewModels
{
    public class CompleteOrderVM
    {
        public List<ShoppingCart> ShoppingCart { get; set; }
        public List<OrderInfoDTO> orderInfoDTOs { get; set; }
        public OrderDTO orderDTO { get; set; }
        
    }
}
