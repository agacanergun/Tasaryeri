using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.ViewModels
{
    public class CategoryVM
    {
        public IEnumerable<MainCategoryDTO> MainCategoryDTO { get; set; }
        public IEnumerable<SubCategoryDTO> SubCategoryDTO { get; set; }
    }
}
