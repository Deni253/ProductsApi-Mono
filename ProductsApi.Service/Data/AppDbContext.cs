using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProductsApi.Service.Models;

namespace ProductsApi.Service.Data
{
    public class AppDbContext : DbContext
    {
        
        public DbSet<Category> categories  { get; set; }
        public DbSet<Product> products  { get; set; }
        public AppDbContext(DbContextOptions options):base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { Id = Guid.Parse("aa640f87-912d-417e-b063-98c40ac1df62"), Name = "Electronics", Description = "Electronic devices" },
                new Category { Id = Guid.Parse("21afa39e-fc53-492b-829b-5ee4fbe93cf8"), Name = "Golf Equipment", Description = "golf clubs and bags" }
                
            );
            modelBuilder.Entity<Product>().HasData(
                new Product { Id = Guid.Parse("02d69507-7869-4487-a9f5-e1780a7f856b"), CategoryId = Guid.Parse("21afa39e-fc53-492b-829b-5ee4fbe93cf8"), Name = "Yellow Golf Club", Price = 29.99, StockQuantity = 20, IsActive = true, CreatedAt = new DateTime(2024, 1, 1, 0, 0, 0, DateTimeKind.Utc) }
            );
        }
    }
}
