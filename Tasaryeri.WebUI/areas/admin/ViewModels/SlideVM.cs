using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Areas.admin.ViewModels
{
    public class SlideVM
    {
        public IEnumerable<SlideDTO> SlideDTOList { get; set; }
        public SlideDTO SlideDTO { get; set; }
    }
}
