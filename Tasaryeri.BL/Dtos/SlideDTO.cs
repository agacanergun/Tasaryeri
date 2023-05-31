using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace Tasaryeri.BL.Dtos
{
    public class SlideDTO
    {
        public int Id { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Required, Display(Name = "Slayt Adı")]
        public string Name { get; set; }

        [StringLength(50), Column(TypeName = "varchar(50)"), Display(Name = "Slayt Başlığı")]
        public string Title { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Kısa Slayt Açıklaması")]
        public string ShortDescription { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Uzun Slayt Açıklaması")]
        public string LongDescription { get; set; }

        [Column(TypeName = "varchar(150)"), Display(Name = "Slayt Resmi")]
        public string Picture { get; set; }

        [Display(Name = "Slayt Resmi")]
        public IFormFile PictureFile { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Bağlantı Linki")]
        public string Link { get; set; }

        [Display(Name = "Görüntülenme Sırası")]
        public int? DisplayIndex { get; set; }
    }
}
