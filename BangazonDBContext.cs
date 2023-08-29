using BangazonBE_SB.Models;
using Microsoft.EntityFrameworkCore;

namespace BangazonBE_SB
{
    public class BangazonDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Users_PaymentTypes> UserPaymentTypes { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<PaymentTypes> PaymentTypes { get; set; }
        public DbSet<OrderStatuses> OrderStatuses { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<ProductCategories> Categories { get; set; }

        public BangazonDBContext(DbContextOptions<BangazonDBContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Seed data for Orders
            modelBuilder.Entity<Orders>().HasData(new Orders[]
            {
                new Orders {OrderId = 1, UserId = 1, StatusId = 1},
                new Orders {OrderId = 2, UserId = 2, StatusId = 2},
                new Orders {OrderId = 3, UserId = 1, StatusId = 1},
            });

            // Seed data for OrderStatuses
            modelBuilder.Entity<OrderStatuses>().HasData(new OrderStatuses[]
            {
                new OrderStatuses {OrderStatusId = 1, OrderStatus = "Ordered"},
                new OrderStatuses {OrderStatusId = 2, OrderStatus = "Shipped"},
                new OrderStatuses {OrderStatusId = 3, OrderStatus = "Completed"},
                new OrderStatuses {OrderStatusId = 4, OrderStatus = "Cancelled"}
            });

            // Seed data for PaymentTypes
            modelBuilder.Entity<PaymentTypes>().HasData(new PaymentTypes[]
            {
                new PaymentTypes {PaymentTypeId = 1, Name = "Credit Card"},
                new PaymentTypes {PaymentTypeId = 2, Name = "PayPal"},
                new PaymentTypes {PaymentTypeId = 3, Name = "Cash"}
            });

            // Seed data for ProductCategories
            modelBuilder.Entity<ProductCategories>().HasData(new ProductCategories[]
            {
                new ProductCategories {ProductCatagoryId = 1, Name = "Electronics"},
                new ProductCategories {ProductCatagoryId = 2, Name = "Clothing"},
                new ProductCategories {ProductCatagoryId = 3, Name = "Furniture"}
            });

            // Seed data for Products
            modelBuilder.Entity<Products>().HasData(new Products[]
            {
                new Products {ProductId = 1, Name = "Product A", Price = 10.99M, UserId = 1, ProductCategoryId = 1},
                new Products {ProductId = 2, Name = "Product B", Price = 20.49M, UserId = 2, ProductCategoryId = 2},
                new Products {ProductId = 3, Name = "Product C", Price = 5.99M, UserId = 1, ProductCategoryId = 1}
            });

            // Seed data for Users
            modelBuilder.Entity<User>().HasData(new User[]
            {
                new User {UserId = 1, Name = "Jack Smith", NickName = "JSmith", TimeCreated = DateTime.Now, IsSeller = true},
                new User {UserId = 2, Name = "Chris Lee", NickName = "CLee", TimeCreated = DateTime.Now, IsSeller = false},
                new User {UserId = 3, Name = "Steve Wilson", NickName = "SWilson", TimeCreated = DateTime.Now, IsSeller = false}
            });

            // Seed data for Users_PaymentTypes
            modelBuilder.Entity<Users_PaymentTypes>().HasData(new Users_PaymentTypes[]
            {
                new Users_PaymentTypes {UserPaymentTypeId = 1, UserId = 1, PaymentId = 1},
                new Users_PaymentTypes {UserPaymentTypeId = 2, UserId = 2, PaymentId = 2},
                new Users_PaymentTypes {UserPaymentTypeId = 3, UserId = 3, PaymentId = 3}
            });
        }
    }
}
