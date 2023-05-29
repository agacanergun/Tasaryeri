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
    public class AdminLoginDTO
    {
        public int? Id { get; set; }
        public string? ReturnUrl { get; set; }
        [StringLength(30), Column(TypeName = "varchar(30)"), Required(ErrorMessage = "Kullanıcı adı boş geçilemez..."), Display(Name = "Kullanıcı Adı")]
        public string UserName { get; set; }

        [StringLength(32), Column(TypeName = "varchar(32)"), Required(ErrorMessage = "Şifre boş geçilemez..."), Display(Name = "Şifre")]
        public string Password { get; set; }
    }
}
