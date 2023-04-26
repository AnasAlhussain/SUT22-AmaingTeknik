using AmazingTeknikModels;
using Microsoft.EntityFrameworkCore;

namespace SUT22_AmaingTeknik.Models
{
    public class AppDbContex : DbContext
    {
        public AppDbContex(DbContextOptions<AppDbContex> options) : base(options)
        {
            
        }


        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);



            //Seed Product
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductId = 1,
                    ProductName = "Iphone 13",
                    Price = 8500.00m,
                    Category = Category.Phone
                });
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductId = 2,
                    ProductName = "Samsung S10",
                    Price = 3799.00m,
                    Category = Category.Tablet
                });
            modelBuilder.Entity<Product>().
                HasData(new Product
                {
                    ProductId = 3,
                    ProductName = "Asus RS6",
                    Price = 7988.00m,
                    Category = Category.Computer
                });

            //Seed Customer 
            modelBuilder.Entity<Customer>().
                HasData(new Customer
                {
                    CustomerId = 1,
                    FirstName = "Anas",
                    LastName = "Qlok",
                    Email = "anas@qlok.se",
                    Address = "Storgatan 55 B",
                    Phone = "07777777"
                });
            modelBuilder.Entity<Customer>().
                HasData(new Customer
                {
                    CustomerId = 2,
                    FirstName = "Reidar",
                    LastName = "Nilsen",
                    Email = "reidar@hot.se",
                    Address = "Sammagata 21 B",
                    Phone = "078965487",
                });

            // Seed Order 
            modelBuilder.Entity<Order>().
                HasData(new Order { OrderId = 1, CustomerId = 1, OrderPlaced = new DateTime(2021, 06, 22) });
            modelBuilder.Entity<Order>().
                HasData(new Order { OrderId = 2, CustomerId = 2, OrderPlaced = new DateTime(2020, 11, 22) });
            modelBuilder.Entity<Order>().
                HasData(new Order { OrderId = 3, CustomerId = 2, OrderPlaced = new DateTime(2021, 09, 15) });
        }
    }
}
