using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Tasaryeri.BL.Dtos
{
    public class MemberDTO
    {
        public int Id { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Ad Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Soy Ad Boş Geçilemez"), Display(Name = "Soy Ad")]
        public string Surname { get; set; }
    }
}
