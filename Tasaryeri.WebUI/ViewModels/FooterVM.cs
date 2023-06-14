using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class FooterVM
    {
        public SocialMediaDTO SocialMediaDTO { get; set; }
        public IEnumerable<AboutUsDTO> AboutUsDTOs { get; set; }
        public IEnumerable<ContactDTO> ContactDTOs { get; set; }
        public IEnumerable<InstitutionalDTO> InstitutionalDTOs { get; set; }

    }
}
