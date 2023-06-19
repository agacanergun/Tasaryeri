using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasaryeri.BL.Dtos
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int MemberId { get; set; }

        public int SalerId { get; set; }

        [Column(TypeName = "varchar(500)"), Display(Name = "Mesaj İçeriği")]
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Mesajı Gönderen")]
        public string Sender { get; set; }
    }
}
