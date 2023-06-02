using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.ViewModels
{
    public class CategoryVM
    {
        public IEnumerable<MainCategoryDTO> MainCategoryDTO { get; set; }
        public MainCategoryDTO MainCategoryDTO1 { get; set; }
        public IEnumerable<SubCategoryDTO> SubCategoryDTO { get; set; }
        public SubCategoryDTO SubCategoryDTO1 { get; set; }
    }
}
