using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasaryeri.BL.Dtos
{
    public class MainCategoryDTO
    {
        public int Id { get; set; }
        public IEnumerable<SubCategoryDTO> subCategoriesDTO { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kategori Adı Boş Geçilemez"), Display(Name = "Kategori Adı")]
        public string Name { get; set; }
        [Display(Name = "Görüntülenme Sırası")]
        public int? DisplayIndex { get; set; }
    }
}
