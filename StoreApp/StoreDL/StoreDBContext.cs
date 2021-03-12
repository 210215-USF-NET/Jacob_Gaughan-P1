using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreDL
{
    public class StoreDBContext : DbContext
    {
        public StoreDBContext(DbContextOptions options) : base(options)
        {
        }

        protected StoreDBContext()
        {
        }
        
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Manager> Managers { get; set; }
        public DbSet<Cart> Carts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .Property(customer => customer.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Location>()
                .Property(location => location.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Product>()
                .Property(product => product.Id)
                .ValueGeneratedOnAdd();
            modelBuilder.Entity<Inventory>()
               .Property(inventory => inventory.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Order>()
               .Property(order => order.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Manager>()
               .Property(manager => manager.Id)
               .ValueGeneratedOnAdd();
            modelBuilder.Entity<Cart>()
               .Property(cart => cart.Id)
               .ValueGeneratedOnAdd();

            //foriegn key connections for customers
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Carts)
                .WithOne(cart => cart.Customer)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Customer>()
                .HasMany(customer => customer.Orders)
                .WithOne(cart => cart.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            //foriegn key connections for Carts
            modelBuilder.Entity<Cart>()
                .HasMany(cart => cart.Products)
                .WithOne(product => product.Cart)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Cart>()
                .HasOne(cart => cart.Location)
                .WithOne(location => location.Cart)
                .OnDelete(DeleteBehavior.Cascade);

            //foriegn key connections for Inventory
            modelBuilder.Entity<Inventory>()
                .HasOne(inventory => inventory.Product)
                .WithOne(product => product.Inventory)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Inventory>()
                .HasOne(inventory => inventory.Location)
                .WithOne(location => location.Inventory)
                .OnDelete(DeleteBehavior.Cascade);

            //foriegn key connections for Location
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Products)
                .WithOne(product => product.Location)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Orders)
                .WithOne(order => order.Location)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
