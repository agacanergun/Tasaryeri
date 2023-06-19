using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasaryeri.BL.Dtos
{
    public class MessageDTO
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public int SenderId { get; set; }

        public int RecipientId { get; set; }

        [Column(TypeName = "varchar(500)"), Display(Name = "Mesaj İçeriği")]
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }
    }
}
