using EshopMicroservice.Models;
using Microsoft.EntityFrameworkCore;

namespace EshopMicroservice.DBContext
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
            new Category
            {
                Id = 1,
                Name = "Electronics",
                Description = "Electronic Items",
            },
            new Category
            {
                Id = 2,
                Name = "Clothes",
                Description = "Dresses",
            },
            new Category
            {
                Id = 3,
                Name = "Grocery",
                Description = "Grocery Items",
            }
        );

            modelBuilder.Entity<Product>().HasData(
            new Product
            {
                Id = 1,
                Name = "Mobile",
                Price = 1000,
                Description = "Mobile Phone",
                CategoryId = 1,
            },
            new Product
            {
                Id = 2,
                Name = "Laptop",
                Price = 5000,
                Description = "Laptop",
                CategoryId = 1,
            },
            new Product
            {
                Id = 3,
                Name = "Shoes",
                Price = 100,
                Description = "Shoes",
                CategoryId = 2,
            },
            new Product
            {
                Id = 4,
                Name = "Pants",
                Price = 100,
                Description = "Pants",
                CategoryId = 2,
            });
        }
    }
}

