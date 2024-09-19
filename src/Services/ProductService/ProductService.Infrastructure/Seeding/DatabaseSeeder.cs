using Microsoft.EntityFrameworkCore;
using ProductService.Domain.Models;
using ProductService.Infrastructure.Persistance;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

public class DatabaseSeeder
{
    public static async Task SeedAsync(EShopDbContext context)
    {

        // Ensure database is created
        context.Database.EnsureCreated();

        if (await context.Products.AnyAsync())
        {
            // Database already seeded
            return;
        }
        using var transaction = await context.Database.BeginTransactionAsync();
        try
        {
            // Seed Categories
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories ON");
            await SeedCategoriesAsync(context);
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Categories OFF");
            await context.SaveChangesAsync();
            // Seed Products
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Products ON");
            await SeedProductsAsync(context);
            await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Products OFF");


            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Customers ON");
            //await SeedCustomersAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Customers OFF");


            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Carts ON");
            //await SeedCartsAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Carts OFF");


            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Orders ON");
            //await SeedOrdersAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Orders OFF");

            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT OrderItems ON");
            //await SeedOrderItemsAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT OrderItems OFF");


            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Reviews ON");
            //await SeedReviewsAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT Reviews OFF");

            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT CartItems ON");
            //await SeedCartItemsAsync(context);
            //await context.Database.ExecuteSqlRawAsync("SET IDENTITY_INSERT CartItems OFF");
            await context.SaveChangesAsync();


            // Commit transaction
            await transaction.CommitAsync();
        }
        catch (Exception x)
        {
            await transaction.RollbackAsync();
            throw;
        }
        finally
        {
        }
    }








    private static async Task SeedCategoriesAsync(EShopDbContext context)
    {
        var categories = new List<Category>
        {
            new Category { CategoryId = 1, Name = "Electronics", Description = "Devices and gadgets", ParentCategoryId = null, CreatedDate = DateTime.Now },
            new Category { CategoryId = 2, Name = "Clothing", Description = "Apparel and fashion", ParentCategoryId = null, CreatedDate = DateTime.Now },
            new Category { CategoryId = 3, Name = "Home Appliances", Description = "Appliances for home use", ParentCategoryId = null, CreatedDate = DateTime.Now },
            new Category { CategoryId = 4, Name = "Smartphones", Description = "Smartphones and accessories", ParentCategoryId = 1, CreatedDate = DateTime.Now }
        };

        await context.Categories.AddRangeAsync(categories);

    }

    private static async Task SeedProductsAsync(EShopDbContext context)
    {
        var products = new List<Product>
        {
            new Product { ProductId = 1, Name = "Smartphone X1", Description = "Latest model with high-end features", Price = 699.99m, CategoryId = 4, StockQuantity = 50, IsActive = true, CreatedDate = DateTime.Now },
            new Product { ProductId = 2, Name = "Smartphone Y2", Description = "Affordable smartphone with good performance", Price = 399.99m, CategoryId = 4, StockQuantity = 100, IsActive = true, CreatedDate = DateTime.Now },
            new Product { ProductId = 3, Name = "Leather Jacket", Description = "Stylish leather jacket for winter", Price = 129.99m, CategoryId = 2, StockQuantity = 30, IsActive = true, CreatedDate = DateTime.Now },
            new Product { ProductId = 4, Name = "Washing Machine", Description = "High-efficiency washing machine", Price = 499.99m, CategoryId = 3, StockQuantity = 20, IsActive = true, CreatedDate = DateTime.Now }
        };

        await context.Products.AddRangeAsync(products);
    }

    //private static async Task SeedCustomersAsync(EShopDbContext context)
    //{
    //    var customers = new List<Customer>
    //    {
    //        new Customer { CustomerId = 1, FirstName = "John", LastName = "Doe", Email = "john.doe@example.com", PasswordHash = "hashedpassword1", PhoneNumber = "555-1234", ShippingAddress = "123 Elm Street", BillingAddress = "123 Elm Street", CreatedDate = DateTime.Now },
    //        new Customer { CustomerId = 2, FirstName = "Jane", LastName = "Smith", Email = "jane.smith@example.com", PasswordHash = "hashedpassword2", PhoneNumber = "555-5678", ShippingAddress = "456 Oak Avenue", BillingAddress = "456 Oak Avenue", CreatedDate = DateTime.Now }
    //    };

    //    await context.Customers.AddRangeAsync(customers);
    //}

    //private static async Task SeedCartsAsync(EShopDbContext context)
    //{
    //    var carts = new List<Cart>
    //    {
    //        new Cart { CartId = 1, CustomerId = 1, CreatedDate = DateTime.Now },
    //        new Cart { CartId = 2, CustomerId = 2, CreatedDate = DateTime.Now }
    //    };

    //    await context.Carts.AddRangeAsync(carts);
    //}

    //private static async Task SeedOrdersAsync(EShopDbContext context)
    //{
    //    var orders = new List<Order>
    //    {
    //        new Order { OrderId = 1, CustomerId = 1, OrderDate = DateTime.Now, ShippingAddress = "123 Elm Street", BillingAddress = "123 Elm Street", OrderTotal = 1099.97m, OrderStatus = "Pending", CreatedDate = DateTime.Now },
    //        new Order { OrderId = 2, CustomerId = 2, OrderDate = DateTime.Now, ShippingAddress = "456 Oak Avenue", BillingAddress = "456 Oak Avenue", OrderTotal = 529.98m, OrderStatus = "Shipped", CreatedDate = DateTime.Now }
    //    };

    //    await context.Orders.AddRangeAsync(orders);
    //}

    //private static async Task SeedOrderItemsAsync(EShopDbContext context)
    //{
    //    var orderItems = new List<OrderItem>
    //    {
    //        new OrderItem { OrderItemId = 1, OrderId = 1, ProductId = 1, Quantity = 1, UnitPrice = 699.99m },
    //        new OrderItem { OrderItemId = 2, OrderId = 1, ProductId = 3, Quantity = 2, UnitPrice = 129.99m },
    //        new OrderItem { OrderItemId = 3, OrderId = 2, ProductId = 2, Quantity = 1, UnitPrice = 399.99m },
    //        new OrderItem { OrderItemId = 4, OrderId = 2, ProductId = 4, Quantity = 1, UnitPrice = 499.99m }
    //    };

    //    await context.OrderItems.AddRangeAsync(orderItems);
    //}

    //private static async Task SeedReviewsAsync(EShopDbContext context)
    //{
    //    var reviews = new List<Review>
    //    {
    //        new Review { ReviewId = 1, ProductId = 1, CustomerId = 1, Rating = 5, Comment = "Excellent smartphone with great features!", CreatedDate = DateTime.Now },
    //        new Review { ReviewId = 2, ProductId = 2, CustomerId = 2, Rating = 4, Comment = "Good value for money.", CreatedDate = DateTime.Now },
    //        new Review { ReviewId = 3, ProductId = 3, CustomerId = 1, Rating = 5, Comment = "High-quality leather jacket, very stylish.", CreatedDate = DateTime.Now }
    //    };

    //    await context.Reviews.AddRangeAsync(reviews);
    //}

    //private static async Task SeedCartItemsAsync(EShopDbContext context)
    //{
    //    var cartItems = new List<CartItem>
    //    {
    //        new CartItem { CartItemId = 1, CartId = 1, ProductId = 2, Quantity = 1, AddedDate = DateTime.Now },
    //        new CartItem { CartItemId = 2, CartId = 1, ProductId = 4, Quantity = 1, AddedDate = DateTime.Now },
    //        new CartItem { CartItemId = 3, CartId = 2, ProductId = 1, Quantity = 1, AddedDate = DateTime.Now }
    //    };

    //    await context.CartItems.AddRangeAsync(cartItems);
    //}
}
