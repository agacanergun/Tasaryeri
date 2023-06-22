using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.BL.Dtos
{
    public class OrderInfoDTO
    {
        public int ProductId { get; set; }

        [Display(Name = "Miktarı")]
        public int Quantity { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Detayı")]
        public string Detail { get; set; }

        public string ProductName { get; set; }
    }
}
