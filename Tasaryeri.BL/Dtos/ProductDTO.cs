using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.BL.Dtos
{
    public class ProductDTO
    {
        public int Id { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Required(ErrorMessage = "Ürün adı boş geçilemez..."), Display(Name = "Ürün Adı")]
        public string Name { get; set; }

        [StringLength(250), Column(TypeName = "varchar(250)"), Display(Name = "Ürün Açıklaması")]
        public string Description { get; set; }

        [Column(TypeName = "text"), Display(Name = "Ürün Detayı")]
        public string Detail { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Satış Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Stok Miktarı")]
        public int Stock { get; set; }

        public int SalerId { get; set; }

        [Display(Name = "Ürün Resimleri")]
        public ICollection<ProductPicture> ProductPictures { get; set; }

        public Saler saler { get; set; }

        public int[] CategoriyIDs { get; set; }

    }
}
