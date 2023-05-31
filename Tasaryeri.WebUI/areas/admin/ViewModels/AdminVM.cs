using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.Areas.admin.ViewModels
{
    public class AdminVM
    {
        public IEnumerable<AdminDTO> AdminDTOList { get; set; }
        public AdminDTO AdminDTO { get; set; }
    }
}
