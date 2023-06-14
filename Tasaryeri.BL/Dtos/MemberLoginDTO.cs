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
    public class MemberLoginDTO
    {
        public int Id { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Ad Boş Geçilemez"), Display(Name = "Ad")]
        public string Name { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Soy Ad Boş Geçilemez"), Display(Name = "Soy Ad")]
        public string Surname { get; set; }
        [StringLength(20), Column(TypeName = "varchar(20)"), Required(ErrorMessage = "Cinsiyet Boş Geçilemez"), Display(Name = "Cinsiyet")]
        public string Gender { get; set; }
        [Required(ErrorMessage = "Yaş Boş Geçilemez"), Display(Name = "Yaş")]
        public int Age { get; set; }
        [StringLength(20), Column(TypeName = "varchar(10)"), Required(ErrorMessage = "Kullanıcı Adı Boş Geçilemez"), Display(Name = "Kullanıcı Adı ")]
        public string Username { get; set; }
        [StringLength(32), Column(TypeName = "varchar(32)"), Required(ErrorMessage = "Şifre Boş Geçilemez"), Display(Name = "Şifre")]
        public string Password { get; set; }
        [StringLength(25), Column(TypeName = "varchar(25)"), Required(ErrorMessage = "E-Mail Boş Geçilemez"), Display(Name = "E-Mail")]
        public string Email { get; set; }
        [StringLength(12), Column(TypeName = "varchar(12)"), Required(ErrorMessage = "Telefon Boş Geçilemez"), Display(Name = "Telefon Numarası")]
        public string PhoneNumber { get; set; }
   
        public string? ReturnUrl { get; set; }
    }
}
