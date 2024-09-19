using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductService.Infrastructure.Persistance
{
    public class EShopDbContext : DbContext
    {
        public EShopDbContext(DbContextOptions options):base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure relationships and constraints
            modelBuilder.Entity<Product>()
                .HasOne(p => p.Category)
                .WithMany(c => c.Products)
                .HasForeignKey(p => p.CategoryId);

            modelBuilder.Entity<Category>()
                .HasOne(c => c.ParentCategory)
                .WithMany(c => c.SubCategories)
                .HasForeignKey(c => c.ParentCategoryId);

            //modelBuilder.Entity<Order>()
            //    .HasOne(o => o.Customer)
            //    .WithMany(c => c.Orders)
            //    .HasForeignKey(o => o.CustomerId);

            //modelBuilder.Entity<OrderItem>()
            //    .HasOne(oi => oi.Order)
            //    .WithMany(o => o.OrderItems)
            //    .HasForeignKey(oi => oi.OrderId);

            //modelBuilder.Entity<OrderItem>()
            //    .HasOne(oi => oi.Product)
            //    .WithMany(p => p.OrderItems)
            //    .HasForeignKey(oi => oi.ProductId);

            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.Product)
            //    .WithMany(p => p.Reviews)
            //    .HasForeignKey(r => r.ProductId);

            //modelBuilder.Entity<Review>()
            //    .HasOne(r => r.Customer)
            //    .WithMany(c => c.Reviews)
            //    .HasForeignKey(r => r.CustomerId);

            //modelBuilder.Entity<Cart>()
            //    .HasOne(c => c.Customer)
            //    .WithOne(c => c.Cart)
            //    .HasForeignKey<Cart>(c => c.CustomerId);

            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Cart)
            //    .WithMany(c => c.CartItems)
            //    .HasForeignKey(ci => ci.CartId);

            //modelBuilder.Entity<CartItem>()
            //    .HasOne(ci => ci.Product)
            //    .WithMany(p => p.CartItems)
            //    .HasForeignKey(ci => ci.ProductId);
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Order> Orders { get; set; }
        //public DbSet<OrderItem> OrderItems { get; set; }
        //public DbSet<Review> Reviews { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<CartItem> CartItems { get; set; }
    }
}
