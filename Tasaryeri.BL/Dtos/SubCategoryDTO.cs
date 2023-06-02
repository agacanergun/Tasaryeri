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
    public class SubCategoryDTO
    {
        public int Id { get; set; }

        public int MainCategoryId { get; set; }
        public MainCategoryDTO MainCategoryDTO { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kategori Adı Boş Geçilemez"), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Görüntülenme Sırası")]
        public int? DisplayIndex { get; set; }
    }
}
