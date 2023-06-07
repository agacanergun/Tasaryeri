using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Areas.saler.ViewModels
{
    public class ProductVM
    {
        public ProductDTO productDTO { get; set; }
        public List<SubCategoryDTO> subCategories;
        public int[] CategoriyIDs { get; set; }
    }
}
