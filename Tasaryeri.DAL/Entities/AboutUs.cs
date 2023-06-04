using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.DAL.Entities
{
    public class AboutUs
    {
        public int Id { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Hakkımızda Başlığı Boş Geçilemez"), Display(Name = "Hakkımızda Başlık")]
        public string Name { get; set; }
        [StringLength(1100), Column(TypeName = "varchar(1100)"), Required(ErrorMessage = "Açıklama Boş Geçilemez"), Display(Name = "Açıklama")]
        public string Description { get; set; }
        [Display(Name = "Görüntülenme Sırası")]
        public int DisplayIndex { get; set; }
    }
}
