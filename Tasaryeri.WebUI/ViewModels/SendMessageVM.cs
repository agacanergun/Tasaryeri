using Tasaryeri.BL.Dtos;

namespace Tasaryeri.WebUI.ViewModels
{
    public class SendMessageVM
    {
        public MessageDTO MessageDTO { get; set; }
        public IEnumerable<MessageDTO> Messages { get; set; }
        public IEnumerable<MessageDTO> OldMessages { get; set; }
        public SalerDTO SalerDTO { get; set; }
        public ProductDTO productDTO { get; set; }
    }
}
