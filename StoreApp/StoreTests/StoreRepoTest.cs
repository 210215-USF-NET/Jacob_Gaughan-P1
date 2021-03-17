using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;
using StoreBL;
using StoreDL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreTests
{
    public class StoreRepoTest
    {
        private readonly DbContextOptions<StoreDBContext> options;

        public StoreRepoTest()
        {
            options = new DbContextOptionsBuilder<StoreDBContext>()
                .UseSqlite("Filename=Test.db")
                .Options;
            Seed();
        }

        [Fact]
        public void GetCustomersReturnsAllCustomers()
        {
            using (var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new StoreRepoDB(context);

                var customers = _repo.GetCustomers();

                Assert.Equal(2, customers.Count);
            }
        }

        [Fact]
        public void GetCustomerByIdShouldReturnCustomer()
        {
            using (var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new StoreRepoDB(context);

                var foundCustomer = _repo.GetCustomerById(1);

                Assert.NotNull(foundCustomer);
                Assert.Equal(1, foundCustomer.Id);
            }
        }

        [Fact]
        public void FindProductsInCartGivenCartId()
        {
            using (var context = new StoreDBContext(options))
            {
                ICartRepository _repo = new StoreRepoDB(context);

                List<int> productList = _repo.GetCartByCartId(1).ProductIds;
                List<int> expectedList = new List<int>();
                expectedList.Add(1);
                expectedList.Add(2);

                Assert.Equal(expectedList, productList);
            }
        }

        [Fact]
        public void AddProductToCart()
        {
            using (var context = new StoreDBContext(options))
            {
                ICartRepository _repo = new StoreRepoDB(context);

                List<int> expectedList = new List<int>();
                expectedList.Add(1);
                expectedList.Add(2);
                expectedList.Add(3);

                Cart newCart = _repo.GetCartByCartId(2);
                newCart.ProductIds.Add(3);

                Assert.Equal(expectedList, newCart.ProductIds);
            }
        }

        [Fact]
        public void GetAllLocations()
        {
            using (var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new StoreRepoDB(context);

                var locationList = _repo.GetLocations();

                Assert.Equal(2, locationList.Count);
            }
        }

        [Fact]
        public void GetLocationById()
        {
            using (var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new StoreRepoDB(context);

                Location location1 = new Location();
                location1.Id = 1;
                location1.Address = "1234 Big St.";
                location1.City = "Hays";
                location1.State = "KS";
                location1.Zipcode = "12345";

                var location = _repo.GetLocationById(1);

                Assert.Equal(location1, location);
            }
        }

        [Fact]
        public void GetCustomerByEmail()
        {
            using (var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new StoreRepoDB(context);

                var customer = _repo.GetCustomerByEmail("testing@test.com");

                Assert.Equal(1, customer.Id);
            }
        }

        [Fact]
        public void CheckCustomerUserNameAndPassword()
        {
            using (var context = new StoreDBContext(options))
            {
                ICustomerRepository _repo = new StoreRepoDB(context);

                Location location1 = new Location();
                location1.Id = 1;
                location1.Address = "1234 Big St.";
                location1.City = "Hays";
                location1.State = "KS";
                location1.Zipcode = "12345";

                var customer = _repo.CheckCustomerLoginInfo("testing@test.com", "testPassword");

                Assert.Equal(2, customer);
            }
        }

        [Fact]
        public void GetLocationsByNameShouldReturnOneLocation()
        {
            using (var context = new StoreDBContext(options))
            {
                ILocationRepository _repo = new StoreRepoDB(context);

                var locations = _repo.GetLocationByName("Tampa");

                Assert.Equal("Tampa", locations.LocationName);
            }
        }

        [Fact]
        public void AddOrderShouldAddNewOrder()
        {
            using (var context = new StoreDBContext(options))
            {
                //arrange
                IOrderRepository _repo = new StoreRepoDB(context);

                Order order = new Order();
                order.LocationID = 2;
                order.OrderDate = DateTime.Now;
                order.CustomerID = 1;
                order.TotalCost = 3000.28m;

                //act
                var returnedOrder = _repo.AddOrder(order);

                //assert
                Assert.Equal(2, returnedOrder.LocationID);
            }
        }

        [Fact]
        public void GetOrderByIDShouldReturnOrder()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderRepository _repo = new StoreRepoDB(context);

                var order = _repo.GetOrderByID(1);

                Assert.Equal(1499.97m, order.TotalCost);
            }
        }

        [Fact]
        public void GetRecentOrderShouldReturnMostRecentOrder()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderRepository _repo = new StoreRepoDB(context);

                var order = _repo.GetRecentOrder();

                Assert.Equal(2045.94m, order.TotalCost);
            }
        }

        [Fact]
        public void GetOrdersForCustomersShouldGetCustomerOrderSpecified()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderRepository _repo = new StoreRepoDB(context);

                var order = _repo.GetOrdersForCustomer(1);

                Assert.Single(order);
            }
        }

        [Fact]
        public void GetProductByIDShouldReturnProduct()
        {
            using (var context = new StoreDBContext(options))
            {
                IProductRepository _repo = new StoreRepoDB(context);

                var product = _repo.GetProductByID(1);

                Assert.Equal("Microbrute", product.ProductName);
            }
        }

        [Fact]
        public void GetProductsShouldReturnAllProducts()
        {
            using (var context = new StoreDBContext(options))
            {
                IProductRepository _repo = new StoreRepoDB(context);

                var product = _repo.GetProducts();

                Assert.Equal(2, product.Count);
            }
        }

        [Fact]
        public void GetProductByNameShouldReturnProduct()
        {
            using (var context = new StoreDBContext(options))
            {
                IProductRepository _repo = new StoreRepoDB(context);

                var product = _repo.GetProductByName("Microbrute");

                Assert.Equal("Microbrute", product.ProductName);
            }
        }

        [Fact]
        public void ProcessProductsShouldReturnListOfOrderProducts()
        {
            using (var context = new StoreDBContext(options))
            {
            }
        }

        [Fact]
        public void GetOrdersWithCustomersShouldReturnAnOrderWithCustomerObject()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderRepository _repo = new StoreRepoDB(context);

                var orders = _repo.GetOrdersWithCustomers();

                Assert.NotNull(orders.First().Customer);
            }
        }

        [Fact]
        public void GetOrdersShouldReturnListOfOrders()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderRepository _repo = new StoreRepoDB(context);

                var orders = _repo.GetOrdersWithCustomers();

                Assert.Equal(2, orders.Count);
            }
        }

        [Fact]
        public void GetOrderProductsShouldReturnListOrderProducts()
        {
            using (var context = new StoreDBContext(options))
            {
                IOrderProductsRepoDB _repo = new StoreRepoDB(context);

                var ops = _repo.GetOrderProducts(1);

                Assert.Single(ops);
            }
        }

        [Fact]
        public void ProductControllerShouldReturnIndex()
        {
            using (var context = new StoreDBContext(options))
            {
                var _productBL = new Mock<IProductBL>();

                IProductRepository _repo = new StoreRepoDB(context);

                _productBL.Setup(x => x.GetProductById())
                    .Returns(_repo.GetProducts);

                var controller = new ProductController(_productBL.Object, new Mapper());

                var result = controller.Index();

                //assert
                var viewResult = Assert.IsType<ViewResult>(result);
                var model = Assert.IsAssignableFrom<IEnumerable<StoreMVC.Models.ProductVM>>(viewResult.ViewData.Model);
                Assert.Equal(2, model.Count());
            }
        }

        private void Seed()
        {
            using (var context = new StoreDBContext(options))
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();

                context.Customers.AddRange
                (
                    new Customer
                    {
                        Id = 1,
                        CustomerEmail = "testing@test.com",
                        CustomerName = "Test Customer",
                        CustomerPassword = "testPassword"
                    },
                    new Customer
                    {
                        Id = 2,
                        CustomerEmail = "testing2@test.com",
                        CustomerName = "Test Second",
                        CustomerPassword = "testPassword2"
                    }
                );

                context.Locations.AddRange
                (
                    new Location
                    {
                        Id = 1,
                        Address = "1234 Big St.",
                        City = "Hays",
                        State = "KS",
                        Zipcode = "12345"
                    },
                    new Location
                    {
                        Id = 2,
                        Address = "1234 Big St.",
                        City = "Durango",
                        State = "CO",
                        Zipcode = "67890"
                    }
                );

                context.Orders.AddRange
                (
                    new Order
                    {
                        Id = 1,
                        CustomerId = 1,
                        LocationId = 1,
                        Total = 20.00m,
                        Date = DateTime.Parse("2021-03-16 9:9:00")
                    },
                    new Order
                    {
                        Id = 2,
                        CustomerId = 2,
                        LocationId = 2,
                        Total = 20.00m,
                        Date = DateTime.Parse("2021-03-16 9:9:00")
                    }
                );

                context.Products.AddRange
                (
                    new Product
                    {
                        Id = 1,
                        ProductName = "Vanilla",
                        LocationId = 1,
                        Quantity = 50,
                        ProductPrice = 5.00m,
                    },
                    new Product
                    {
                        Id = 2,
                        ProductName = "Chocolate",
                        LocationId = 2,
                        Quantity = 20,
                        ProductPrice = 2.50m,
                    }
                );

                context.Carts.AddRange
                (
                    new Cart
                    {
                        Id = 1,
                        ProductIds = { 2, 1 },
                        ProductQuantities = { 4, 2 },
                        CustomerId = 1,
                        LocationId = 1
                    },
                    new Cart
                    {
                        Id = 2,
                        ProductIds = { 1, 2 },
                        ProductQuantities = { 2, 4 },
                        CustomerId = 2,
                        LocationId = 2
                    }
                );

                context.Managers.AddRange
                (
                    new Manager
                    {
                        Id = 1,
                        ManagerName = "admin",
                        ManagerEmail = "admin@admin.com",
                        ManagerPassword = "password"
                    }
                );

                context.SaveChanges();
            }
        }
    }
}