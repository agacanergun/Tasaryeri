using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.BL.Dtos
{
    public class ProductPictureDTO
    {
        public int Id { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Required(ErrorMessage = "Ürün resim adı boş geçilemez..."), Display(Name = "Ürün Resim Adı")]
        public string Name { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Resmi")]
        public string Picture { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
    }
}
