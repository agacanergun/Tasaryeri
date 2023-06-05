using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.ViewModels
{
    public class InstitutionalVM
    {
        public IEnumerable<InstitutionalDTO> InstitutionalDTOs { get; set; }
        public InstitutionalDTO InstitutionalDTO { get; set; }
    }
}
