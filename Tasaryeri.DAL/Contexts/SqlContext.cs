using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tasaryeri.DAL.Entities;

namespace Tasaryeri.DAL.Contexts
{
    public class SqlContext : DbContext
    {
        public SqlContext(DbContextOptions<SqlContext> options) : base(options)
        {
        }
        public DbSet<ProcessIcons> ProcessIcon { get; set; }
        public DbSet<Admin> Admin { get; set; }  //bitti
        public DbSet<MainCategory> MainCategory { get; set; } //bitti
        public DbSet<SubCategory> SubCategory { get; set; } //bitti
        public DbSet<Slide> Slide { get; set; } //bitti
        public DbSet<SocialMedia> SocialMedia { get; set; } //bitti
        public DbSet<Contact> Contact { get; set; } //bitti
        public DbSet<AboutUs> AboutUs { get; set; } //bitti
        public DbSet<Institutional> Institutional { get; set; } //bitti




        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // MainCategory birden çok SubCategorysi olabilir ama SubCategorynin bir main categorysi olabilir.
            // Bu tablolar Maincategory'deki Id ve SubCategorydeki MainCategoryId ile birbirine bağlanmıştır.
            //eğer bir maincategory silinirse tüm alt kategorileri silinecektir.
            modelBuilder.Entity<MainCategory>().HasMany(x => x.subCategories).WithOne(x => x.MainCategory).HasForeignKey(x => x.MainCategoryId);

            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, Name = "Ağacan", Surname = "Ergün", Password = "4c49a6720254293c040d06f1207d6796", UserName = "ağacan" });


        }
    }
}
