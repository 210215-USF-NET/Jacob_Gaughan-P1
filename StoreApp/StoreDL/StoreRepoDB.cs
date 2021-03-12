using Microsoft.EntityFrameworkCore;
using StoreModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreDL
{
    public class StoreRepoDB : ICustomerRepository, ILocationRepository, IProductRepository, IOrderRepository, IInventoryRepository, IManagerRepository, ICartRepository
    {
        private readonly StoreDBContext _context;

        public StoreRepoDB(StoreDBContext context)
        {
            _context = context;
        }

        public Customer AddCustomer(Customer newCustomer)
        {
            _context.Customers.Add(newCustomer);
            _context.SaveChanges();
            return newCustomer;
        }

        public Customer DeleteCustomer(Customer customer2BDeleted)
        {
            _context.Customers.Remove(customer2BDeleted);
            _context.SaveChanges();
            return customer2BDeleted;
        }

        public Customer UpdateCustomer(Customer customer2Bupdated)
        {
            Customer oldCustomer = _context.Customers.Find(customer2Bupdated.Id);
            _context.Entry(oldCustomer).CurrentValues.SetValues(customer2Bupdated);
            return customer2Bupdated;
        }

        public Inventory AddInventory(Inventory newInventory)
        {
            _context.Inventories.Add(newInventory);
            _context.SaveChanges();
            return newInventory;
        }

        public Location AddLocation(Location newLocation)
        {
            _context.Locations.Add(newLocation);
            _context.SaveChanges();
            return newLocation;
        }

        public Order AddOrder(Order newOrder)
        {
            _context.Orders.Add(newOrder);
            _context.SaveChanges();
            return newOrder;
        }

        public Product AddProduct(Product newProduct)
        {
            _context.Products.Add(newProduct);
            _context.SaveChanges();
            return newProduct;
        }

        public Location DeleteLocation(Location location2BDeleted)
        {
            _context.Locations.Remove(location2BDeleted);
            _context.SaveChanges();
            return location2BDeleted;
        }

        public Customer GetCustomerByEmail(string email)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(customer => customer.CustomerEmail == email);
        }

        public Customer CheckCustomerLoginInfo(string email, string password)
        {
            return _context.Customers.AsNoTracking().FirstOrDefault(customer => customer.CustomerEmail == email && customer.CustomerPassword == password);
        }
        public List<Customer> GetCustomers()
        {
            return _context.Customers.AsNoTracking().Select(customer => customer).ToList();
        }

        public List<Inventory> GetInventories()
        {
            return _context.Inventories.AsNoTracking().Select(inventory => inventory).ToList();
        }

        public Inventory GetInventoryById(int prodId, int locId)
        {
            return _context.Inventories.AsNoTracking().FirstOrDefault(inventory => inventory.ProductId == prodId && inventory.LocationId == locId);
        }

        public Location GetLocationById(int locId)
        {
            return _context.Locations.AsNoTracking().FirstOrDefault(location => location.Id == locId);
        }

        public List<Location> GetLocations()
        {
            return _context.Locations.AsNoTracking().Select(location => location).ToList();
        }

        public List<Order> GetOrders()
        {
            return _context.Orders.AsNoTracking().Select(order => order).ToList();
        }

        public Product GetProductById(int prodId)
        {
            return _context.Products.Find(prodId);
        }

        public decimal GetProductPrice(int prodId)
        {
            return GetProductById(prodId).ProductPrice;
        }

        public List<Product> GetProducts()
        {
            return _context.Products.AsNoTracking().Select(product => product).ToList();
        }

        public int GetQuantity(int prodId, int locId)
        {
            return GetInventoryById(prodId, locId).Quantity;
        }

        public Inventory UpdateInventory(Inventory inventory2Bupdated)
        {
            Inventory oldCustomer = _context.Inventories.Find(inventory2Bupdated.Id);
            _context.Entry(oldCustomer).CurrentValues.SetValues(inventory2Bupdated);
            return inventory2Bupdated;
        }

        public List<Manager> GetManagers()
        {
            return _context.Managers.AsNoTracking().Select(manager => manager).ToList();
        }

        public Manager AddManager(Manager newManager)
        {
            _context.Managers.Add(newManager);
            _context.SaveChanges();
            return newManager;
        }

        public Manager DeleteManager(Manager manager2BDeleted)
        {
            _context.Managers.Remove(manager2BDeleted);
            _context.SaveChanges();
            return manager2BDeleted;
        }

        public Manager GetManagerByEmail(string email)
        {
            return _context.Managers.AsNoTracking().FirstOrDefault(manager => manager.ManagerEmail == email);
        }

        public Location UpdateLocation(Location location2Bupdated)
        {
            Location oldLocation = _context.Locations.Find(location2Bupdated.Id);
            _context.Entry(oldLocation).CurrentValues.SetValues(location2Bupdated);
            _context.SaveChanges();
            _context.ChangeTracker.Clear();
            return location2Bupdated;
        }

        public Cart AddCart(Cart newCart)
        {
            _context.Carts.Add(newCart);
            _context.SaveChanges();
            return newCart;
        }

        public Cart AddToCart(Cart newCart, int invId, int quantity2Add)
        {
            throw new NotImplementedException();
        }

        public Cart GetCartById(int custId, int locId)
        {
            return _context.Carts.AsNoTracking().FirstOrDefault(cart => cart.CustomerId == custId && cart.LocationId == locId);
        }
    }
}