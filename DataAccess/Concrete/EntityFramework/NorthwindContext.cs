using Core.Entities.Concrete;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    // Context = Db tabloları ile proje classlarını bağlamak.
    // Dbcontext, yüklediğimiz Ef.sql paketinden base olarak gelir.
    public class NorthwindContext : DbContext
    {
        // Hangi veritabanına bağlanacığını gösterdik
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-MP6HDBU; Database=Northwind; Trusted_Connection=true");
        }

        // Hangi classın hangi tabloya karşılık geldiğini gösterdik.
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OperationClaim> OperationClaims { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserOperationClaim> UserOperationClaims { get; set; }
    }
}
