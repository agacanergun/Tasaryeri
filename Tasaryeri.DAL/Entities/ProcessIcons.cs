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
    public class ProcessIcons
    {
        public int Id { get; set; }
        [StringLength(40), Column(TypeName = "varchar(40)"), Required(ErrorMessage = "Bilgisayar İconu Yazısı Boş Geçilemez"), Display(Name = "Bilgisayar İconu Yazısı")]
        public string PcIcon { get; set; }
        [StringLength(40), Column(TypeName = "varchar(40)"), Required(ErrorMessage = "Kargo İconu Yazısı Boş Geçilemez"), Display(Name = "Kargo İconu Yazısı")]
        public string CargoIcon { get; set; }
        [StringLength(40), Column(TypeName = "varchar(40)"), Required(ErrorMessage = "Kullanıcı İconu Yazısı Boş Geçilemez"), Display(Name = "Kullanıcı İconu Yazısı")]
        public string UserIcon { get; set; }
        [StringLength(40), Column(TypeName = "varchar(40)"), Required(ErrorMessage = "Para İconu Yazısı Boş Geçilemez"), Display(Name = "Para İconu Yazısı")]
        public string MoneyIcon { get; set; }
    }
}
