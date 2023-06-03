using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class HomeIndexVM
    {
        public IEnumerable<SlideDTO> Slides { get; set; }
        public IEnumerable<SubCategoryDTO> Categories { get; set; }
    }
}
