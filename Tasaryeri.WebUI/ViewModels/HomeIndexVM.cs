using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<SlideDTO> Slides { get; set; }
        public IEnumerable<MainCategoryDTO> Categories { get; set; }
        public List<ProductDTO> RandomProducts { get; set; }
    }
}
