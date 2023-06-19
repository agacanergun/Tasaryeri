using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class ProductDetailVM
    {
        public List<ProductDTO> productDTOs = new List<ProductDTO>();
        public ProductDTO productDTO { get; set; }
    }
}
