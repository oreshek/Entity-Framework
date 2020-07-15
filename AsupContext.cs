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


    }
}
