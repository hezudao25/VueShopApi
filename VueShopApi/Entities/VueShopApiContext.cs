using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VueShopApi.Entities
{
    public class VueShopApiContext:DbContext
    {
        public VueShopApiContext() { 
        
        }
        public VueShopApiContext(DbContextOptions<VueShopApiContext> options):base(options) { 
        
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) {
                optionsBuilder.UseSqlServer("Data Source =127.0.0.1;database=VueShopDb;uid=sa;pwd =123456");
            }
        }
        public DbSet<Products> Products { get; set; }
        public DbSet<ShoppingCarts> ShoppingCarts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Products>().ToTable("ShoppingCarts", "ps");
            modelBuilder.Entity<Products>().ToTable("Products", "ps");
            modelBuilder.Entity<Products>(entity =>
            entity.Property(e => e.ImageUrl).HasMaxLength(500)
            );
            base.OnModelCreating(modelBuilder);
        }
    }
}
