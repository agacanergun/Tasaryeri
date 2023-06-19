using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tasaryeri.BL.Dtos
{
    public class SalerDTO
    {
        public int Id { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Ad Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Soy Ad Boş Geçilemez"), Display(Name = "Soy Ad")]
        public string Surname { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Cinsiyet Boş Geçilemez"), Display(Name = "Cinsiyet")]
    }
}
