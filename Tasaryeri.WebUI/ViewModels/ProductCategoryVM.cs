using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class ProductCategoryVM
    {
        public IEnumerable<ProductDTO> productDTOs { get; set; }
        public IEnumerable<MainCategoryDTO> Categories { get; set; }

    }
}
