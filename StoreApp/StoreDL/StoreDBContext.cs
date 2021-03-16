using Microsoft.EntityFrameworkCore;
using StoreModels;

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
                .WithOne(order => order.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            //foriegn key connections for Carts
            modelBuilder.Entity<Cart>()
                .HasMany(cart => cart.Products)
                .WithOne();

            //foriegn key connections for Location
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Products)
                .WithOne(product => product.Location)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Orders)
                .WithOne(order => order.Location)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Orders)
                .WithOne(order => order.Location)
                .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<Location>()
                .HasMany(location => location.Carts)
                .WithOne(cart => cart.Location)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}