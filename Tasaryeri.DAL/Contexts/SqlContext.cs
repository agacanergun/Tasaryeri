using Microsoft.EntityFrameworkCore;
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
        public DbSet<Admin> Admin { get; set; }










        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Admin>().HasData(new Admin { ID = 1, Name = "Ağacan", Surname = "Ergün", Password = "4c49a6720254293c040d06f1207d6796", UserName = "ağacan" });
        }
    }
}
