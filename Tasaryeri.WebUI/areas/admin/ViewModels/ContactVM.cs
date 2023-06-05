using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.areas.admin.ViewModels
{
    public class ContactVM
    {
        public IEnumerable<ContactDTO> ContactDTOs { get; set; }
        public ContactDTO ContactDTO { get; set; }
    }
}
