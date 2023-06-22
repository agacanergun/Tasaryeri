using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Enums;

namespace Tasaryeri.DAL.Entities
{
    public class Order
    {
        public int ID { get; set; }

        [StringLength(10), Column(TypeName = "varchar(10)"), Display(Name = "Sipariş Numarası"), Required(ErrorMessage = "Sipariş Numarası boş geçilemez")]
        public string OrderNumber { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Adı"), Required(ErrorMessage = "Ad bilgisi boş geçilemez")]
        public string Name { get; set; }

        [StringLength(30), Column(TypeName = "varchar(30)"), Display(Name = "Soyadı"), Required(ErrorMessage = "Soyad bilgisi boş geçilemez")]
        public string Surname { get; set; }

        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Adres Tanımı"), Required(ErrorMessage = "Adresbilgisi boş geçilemez")]
        public string Address { get; set; }

        [StringLength(20), Column(TypeName = "varchar(20)"), Display(Name = "Şehir"), Required(ErrorMessage = "Şehir boş geçilemez")]
        public string City { get; set; }

        [StringLength(5), Column(TypeName = "char(5)"), Display(Name = "Posta Kodu")]
        public string ZipCode { get; set; }

        [StringLength(11), Column(TypeName = "char(11)"), Display(Name = "Telefon"), Required(ErrorMessage = "Telefon bilgisi boş geçilemez")]
        public string Phone { get; set; }

        [StringLength(80), Column(TypeName = "varchar(80)"), Display(Name = "Mail"), Required(ErrorMessage = "Mail bilgisi boş geçilemez")]
        public string Mail { get; set; }

        [Display(Name = "Sipariş Durumu")]
        public EOrderStatus OrderStatus { get; set; }

        [Display(Name = "Sipariş Tarihi")]
        public DateTime RecDate { get; set; }

        public int ProductID { get; set; }
        public Product Product { get; set; }
        [StringLength(100), Column(TypeName = "varchar(100)"), Display(Name = "Ürün Adı")]
        public string ProductName { get; set; }

        [StringLength(150), Column(TypeName = "varchar(150)"), Display(Name = "Ürün Resmi")]
        public string Picture { get; set; }

        [Column(TypeName = "decimal(18,2)"), Display(Name = "Ürün Fiyatı")]
        public decimal Price { get; set; }

        [Display(Name = "Miktarı")]
        public int Quantity { get; set; }
    }
}
