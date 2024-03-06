using Microsoft.EntityFrameworkCore;
using Turon_Mchj_E_Commerce.Entities.Models;

namespace Turon_Mchj_E_Commerce.DataBase
{
    public class TuronDbContext : DbContext
    {



        public DbSet<Product> Products { get; set; }

        public DbSet<ShoppingList> ShoppingLists { get; set; }

        public DbSet<Order> Orders { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = "server=DESKTOP-4HKLI08\\MSSQLSERVER01;database=Movie;Trusted_connection=true;trustservercertificate=true";
            optionsBuilder.UseSqlServer(connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>()
                .Property(p => p.Price).HasColumnType("decimal");
        }
    }
}
