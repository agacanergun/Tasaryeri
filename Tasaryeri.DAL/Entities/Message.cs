using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.DAL.Entities
{
    public class Message
    {
        public int Id { get; set; }
        public int? ProductId { get; set; }
        public Product Product { get; set; }
    
        public int? MemberId { get; set; }
        public Member Member { get; set; }

        public int? SalerId { get; set; }
        public Saler Saler { get; set; }

        [Column(TypeName = "varchar(500)"), Display(Name = "Mesaj İçeriği")]
        public string Content { get; set; }
        public DateTime Timestamp { get; set; }

        [Column(TypeName = "varchar(20)"), Display(Name = "Mesajı Gönderen")]
        public string Sender { get; set; }
    }
}
