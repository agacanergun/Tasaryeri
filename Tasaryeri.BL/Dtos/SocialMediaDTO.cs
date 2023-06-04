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
    public class SocialMediaDTO
    {
        public int Id { get; set; }

        [StringLength(130), Column(TypeName = "varchar(130)"), Required(ErrorMessage = "Facebook Linki Boş Geçilemez"), Display(Name = "Facebook Linki")]
        public string FacebookLink { get; set; }

        [StringLength(130), Column(TypeName = "varchar(130)"), Required(ErrorMessage = "Instagram Linki Boş Geçilemez"), Display(Name = "Instagram Linki")]
        public string InstagramLink { get; set; }

        [StringLength(130), Column(TypeName = "varchar(130)"), Required(ErrorMessage = "Twitter Linki Boş Geçilemez"), Display(Name = "Twitter Linki")]
        public string TwitterLink { get; set; }

        [StringLength(130), Column(TypeName = "varchar(130)"), Required(ErrorMessage = "Youtube Linki Boş Geçilemez"), Display(Name = "Youtube Linki")]
        public string YoutubeLink { get; set; }
    }
}
