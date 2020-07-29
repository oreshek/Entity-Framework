using Entity_Framework.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entity_Framework
{
    public class AsupContext : DbContext
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Materials> Materials { get; set; }
        public DbSet<Vendor> Vendor { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=helloappdb;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProductMaterials>()
                .HasKey(t => new { t.ProductId, t.MaterialId });

            modelBuilder.Entity<ProductMaterials>()
                .HasOne(x => x.Product)
                .WithMany(y => y.ProductMaterials)
                .HasForeignKey(x => x.ProductId);

            modelBuilder.Entity<ProductMaterials>()
                .HasOne(x => x.Material)
                .WithMany(y => y.ProductMaterials)
                .HasForeignKey(x => x.MaterialId);
        }


    }
}
