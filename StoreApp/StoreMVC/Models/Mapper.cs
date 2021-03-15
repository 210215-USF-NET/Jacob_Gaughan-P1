using StoreModels;

namespace StoreMVC.Models
{
    public class Mapper : IMapper
    {
        public CustomerIndexVM cast2CustomerIndexVM(Customer customer2Bcasted)
        {
            return new CustomerIndexVM
            {
                Id = customer2Bcasted.Id,
                CustomerName = customer2Bcasted.CustomerName,
                CustomerEmail = customer2Bcasted.CustomerEmail
            };
        }

        public Customer cast2Customer(CustomerCRVM customer2Bcasted)
        {
            return new Customer
            {
                Id = customer2Bcasted.Id,
                CustomerName = customer2Bcasted.CustomerName,
                CustomerEmail = customer2Bcasted.CustomerEmail,
                CustomerPassword = customer2Bcasted.CustomerPassword
            };
        }

        public Customer cast2Customer(CustomerEditVM customer2Bcasted)
        {
            return new Customer
            {
                Id = customer2Bcasted.Id,
                CustomerName = customer2Bcasted.CustomerName,
                CustomerEmail = customer2Bcasted.CustomerEmail,
                CustomerPassword = customer2Bcasted.CustomerPassword
            };
        }

        public Customer cast2CustomerEditVM(Customer customer2Bcasted)
        {
            return new Customer
            {
                Id = customer2Bcasted.Id,
                CustomerName = customer2Bcasted.CustomerName,
                CustomerEmail = customer2Bcasted.CustomerEmail,
                CustomerPassword = customer2Bcasted.CustomerPassword
            };
        }

        public CustomerCRVM cast2CustomerCRVM(Customer customer)
        {
            return new CustomerCRVM
            {
                Id = customer.Id,
                CustomerName = customer.CustomerName,
                CustomerEmail = customer.CustomerEmail,
                CustomerPassword = customer.CustomerPassword
            };
        }

        public Location cast2Location(LocationCRVM location2Bcasted)
        {
            return new Location
            {
                Id = location2Bcasted.Id,
                Address = location2Bcasted.Address,
                City = location2Bcasted.City,
                State = location2Bcasted.State,
                Zipcode = location2Bcasted.Zipcode
            };
        }

        public LocationCRVM cast2LocationCRVM(Location location)
        {
            return new LocationCRVM
            {
                Id = location.Id,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode
            };
        }

        public LocationIndexVM cast2LocationIndexVM(Location location2Bcasted)
        {
            return new LocationIndexVM
            {
                Id = location2Bcasted.Id,
                Address = location2Bcasted.Address,
                City = location2Bcasted.City,
                State = location2Bcasted.State,
                Zipcode = location2Bcasted.Zipcode
            };
        }

        public Location cast2Location(LocationEditVM location2Bcasted)
        {
            return new Location
            {
                Id = location2Bcasted.Id,
                Address = location2Bcasted.Address,
                City = location2Bcasted.City,
                State = location2Bcasted.State,
                Zipcode = location2Bcasted.Zipcode
            };
        }

        public LocationEditVM cast2LocationEditVM(Location location)
        {
            return new LocationEditVM
            {
                Id = location.Id,
                Address = location.Address,
                City = location.City,
                State = location.State,
                Zipcode = location.Zipcode
            };
        }

        public Manager cast2Manager(ManagerCRVM manager2Bcasted)
        {
            return new Manager
            {
                Id = manager2Bcasted.Id,
                ManagerName = manager2Bcasted.ManagerName,
                ManagerEmail = manager2Bcasted.ManagerEmail,
                ManagerPassword = manager2Bcasted.ManagerPassword
            };
        }

        public Manager cast2Manager(ManagerEditVM manager2Bcasted)
        {
            return new Manager
            {
                Id = manager2Bcasted.Id,
                ManagerName = manager2Bcasted.ManagerName,
                ManagerEmail = manager2Bcasted.ManagerEmail,
                ManagerPassword = manager2Bcasted.ManagerPassword
            };
        }

        public ManagerCRVM cast2ManagerCRVM(Manager manager)
        {
            return new ManagerCRVM
            {
                Id = manager.Id,
                ManagerName = manager.ManagerName,
                ManagerEmail = manager.ManagerEmail,
                ManagerPassword = manager.ManagerPassword
            };
        }

        public ManagerIndexVM cast2ManagerIndexVM(Manager manager2Bcasted)
        {
            return new ManagerIndexVM
            {
                Id = manager2Bcasted.Id,
                ManagerName = manager2Bcasted.ManagerName,
                ManagerEmail = manager2Bcasted.ManagerEmail
            };
        }

        public Manager cast2ManagerEditVM(Manager manager2Bcasted)
        {
            return new Manager
            {
                Id = manager2Bcasted.Id,
                ManagerName = manager2Bcasted.ManagerName,
                ManagerEmail = manager2Bcasted.ManagerEmail,
                ManagerPassword = manager2Bcasted.ManagerPassword
            };
        }

        public Product cast2Product(ProductCRVM product2Bcasted)
        {
            return new Product
            {
                Id = product2Bcasted.Id,
                ProductName = product2Bcasted.ProductName,
                ProductPrice = product2Bcasted.ProductPrice,
                Quantity = product2Bcasted.Quantity,
                LocationId = product2Bcasted.LocationId
            };
        }

        public Product cast2Product(ProductEditVM product2Bcasted)
        {
            return new Product
            {
                Id = product2Bcasted.Id,
                ProductName = product2Bcasted.ProductName,
                ProductPrice = product2Bcasted.ProductPrice,
                Quantity = product2Bcasted.Quantity,
                LocationId = product2Bcasted.LocationId
            };
        }

        public ProductCRVM cast2ProductCRVM(Product product)
        {
            return new ProductCRVM
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Quantity = product.Quantity,
                LocationId = product.LocationId
            };
        }

        public ProductIndexVM cast2ProductIndexVM(Product product)
        {
            return new ProductIndexVM
            {
                Id = product.Id,
                ProductName = product.ProductName,
                ProductPrice = product.ProductPrice,
                Quantity = product.Quantity,
                LocationId = product.LocationId
            };
        }

        public Product cast2ProductEditVM(Product product2Bcasted)
        {
            return new Product
            {
                Id = product2Bcasted.Id,
                ProductName = product2Bcasted.ProductName,
                ProductPrice = product2Bcasted.ProductPrice,
                Quantity = product2Bcasted.Quantity,
                LocationId = product2Bcasted.LocationId
            };
        }

        public CartCRVM cast2CartCRVM(Cart cart)
        {
            return new CartCRVM
            {
                Id = cart.Id,
                CustomerId = cart.CustomerId,
                LocationId = cart.LocationId,
                ProductIds = cart.ProductIds,
                ProductQuantities = cart.ProductQuantities
            };
        }

        public Cart cast2Cart(CartCRVM cart2Bcasted)
        {
            return new Cart
            {
                Id = cart2Bcasted.Id,
                CustomerId = cart2Bcasted.CustomerId,
                LocationId = cart2Bcasted.LocationId,
                ProductIds = cart2Bcasted.ProductIds,
                ProductQuantities = cart2Bcasted.ProductQuantities
            };
        }

        public OrderIndexVM cast2OrderIndexVM(Order order)
        {
            return new OrderIndexVM
            {
                Id = order.Id,
                ProductIds = order.ProductIds,
                CustomerId = order.CustomerId,
                LocationId = order.LocationId,
                Total = order.Total,
                Date = order.Date
            };
        }

        public Order cast2Order(OrderIndexVM order2Bcasted)
        {
            return new Order
            {
                Id = order2Bcasted.Id,
                ProductIds = order2Bcasted.ProductIds,
                CustomerId = order2Bcasted.CustomerId,
                LocationId = order2Bcasted.LocationId,
                Total = order2Bcasted.Total,
                Date = order2Bcasted.Date
            };
        }
    }
}