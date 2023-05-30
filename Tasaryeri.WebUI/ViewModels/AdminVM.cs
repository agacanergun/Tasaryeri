using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class AdminVM
    {
        public IEnumerable<AdminDTO> AdminDTOList { get; set; }
        public AdminDTO AdminDTO { get; set; }
    }
}
