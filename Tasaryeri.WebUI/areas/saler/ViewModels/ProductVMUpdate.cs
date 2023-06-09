using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Areas.saler.ViewModels
{
    public class ProductVMUpdate
    {
        public ProductDTO productDTO { get; set; }
        public List<SubCategoryDTO> subCategories;
        public int[] CategoriyIDs { get; set; }
        public string[] CategoryNames { get; set; }
    }
}
