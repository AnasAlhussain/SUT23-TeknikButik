using Microsoft.EntityFrameworkCore;
using SUT23_TeknikButikModels;
using System;

namespace SUT23_TeknikButik.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) :base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Test Data  Product
            modelBuilder.Entity<Product>().HasData(new Product
            {
                 ProductId = 1,
                  ProductName="Iphone 13",
                   Price = 8500.00m,
                   Category = Category.Phone

            });

            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 2,
                ProductName = "Samsung S10",
                Price = 3799.00m,
                Category = Category.Phone

            });
            modelBuilder.Entity<Product>().HasData(new Product
            {
                ProductId = 3,
                ProductName = "Asus RS6",
                Price = 7988.00m,
                Category = Category.Computer

            });

            // Test Data Customer
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 1,
                FirstName = "Anas",
                LastName = "Qlok",
                Email = "anas@qlok.se",
                Address = "Storgatan 55 B",
                Phone = "07777777"
            });
            modelBuilder.Entity<Customer>().HasData(new Customer
            {
                CustomerId = 2,
                FirstName = "Reidar",
                LastName = "Qlok",
                Email = "Reidar@qlok.se",
                Address = "SolGatan 77 ",
                Phone = "0987654"
            });


            //Test DAta Order

            modelBuilder.Entity<Order>().HasData(new Order
            {
                 OrderID = 1, CustomerId = 1, OrderPlaced= new DateTime(2021,06,22)
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderID = 2,
                CustomerId = 2,
                OrderPlaced = new DateTime(2023, 11, 15)
            });

            modelBuilder.Entity<Order>().HasData(new Order
            {
                OrderID = 3,
                CustomerId = 2,
                OrderPlaced = new DateTime(2020, 09, 11)
            });
        }
    }
}
