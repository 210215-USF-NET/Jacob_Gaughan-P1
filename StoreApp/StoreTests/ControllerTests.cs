using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Moq;
using StoreBL;
using StoreModels;
using StoreMVC.Controllers;
using StoreMVC.Models;
using System.Collections.Generic;
using System.Linq;
using Xunit;

namespace StoreTests
{
    public class ControllerTests
    {
        private Mock<ICartBL> mockRepoCart = new Mock<ICartBL>();
        private Mock<ICustomerBL> mockRepoCustomer = new Mock<ICustomerBL>();
        private Mock<ILocationBL> mockRepoLocation = new Mock<ILocationBL>();
        private Mock<IProductBL> mockRepoProduct = new Mock<IProductBL>();
        private Mock<IManagerBL> mockRepoManager = new Mock<IManagerBL>();
        private Mock<IOrderBL> mockRepoOrder = new Mock<IOrderBL>();
        private Mock<IMapper> mockMapper = new Mock<IMapper>();
        private Mock<ILogger<HomeController>> mockLogger = new Mock<ILogger<HomeController>>();
        [Fact]
        public void LocationControllerCustomerIndexShouldReturnLocations()
        {
            mockRepoLocation.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
                     new Location
                     {
                        Id = 1,
                        Address = "123 Street",
                        City = "Hays",
                        State = "KS",
                        Zipcode = "Hays"
                     },
                     new Location
                     {
                        Id = 2,
                        Address = "1234 Street1",
                        City = "Hays1",
                        State = "OK",
                        Zipcode = "Hays1"
                     }
                }
                );
            var locationController = new LocationController(mockRepoCustomer.Object, mockRepoLocation.Object, mockMapper.Object, mockRepoProduct.Object, mockRepoCart.Object, mockRepoOrder.Object,
                mockLogger.Object);
            var result = locationController.CustomerIndex(1);
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void LocationControllerManagerIndexShouldReturnLocations()
        {
            mockRepoLocation.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
                     new Location
                     {
                        Id = 1,
                        Address = "123 Street",
                        City = "Hays",
                        State = "KS",
                        Zipcode = "Hays"
                     },
                     new Location
                     {
                        Id = 2,
                        Address = "1234 Street1",
                        City = "Hays1",
                        State = "OK",
                        Zipcode = "Hays1"
                     }
                }
                );
            var locationController = new LocationController(mockRepoCustomer.Object, mockRepoLocation.Object, mockMapper.Object, mockRepoProduct.Object, mockRepoCart.Object, mockRepoOrder.Object,
                mockLogger.Object);
            var result = locationController.ManagerIndex();
            Assert.IsType<ViewResult>(result);
        }

        [Fact]
        public void LocationControllerManagerIndexShouldTwoLocations()
        {
            mockRepoLocation.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
                     new Location
                     {
                        Id = 1,
                        Address = "123 Street",
                        City = "Hays",
                        State = "KS",
                        Zipcode = "Hays"
                     },
                     new Location
                     {
                        Id = 2,
                        Address = "1234 Street1",
                        City = "Hays1",
                        State = "OK",
                        Zipcode = "Hays1"
                     }
                }
                );
            var locationController = new LocationController(mockRepoCustomer.Object, mockRepoLocation.Object, mockMapper.Object, mockRepoProduct.Object, mockRepoCart.Object, mockRepoOrder.Object,
                mockLogger.Object);
            var result = locationController.ManagerIndex();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<LocationIndexVM>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void LocationControllerCustomerIndexShouldTwoLocations()
        {
            mockRepoLocation.Setup(x => x.GetLocations())
                .Returns(new List<Location>()
                {
                     new Location
                     {
                        Id = 1,
                        Address = "123 Street",
                        City = "Hays",
                        State = "KS",
                        Zipcode = "Hays"
                     },
                     new Location
                     {
                        Id = 2,
                        Address = "1234 Street1",
                        City = "Hays1",
                        State = "OK",
                        Zipcode = "Hays1"
                     }
                }
                );
            var locationController = new LocationController(mockRepoCustomer.Object, mockRepoLocation.Object, mockMapper.Object, mockRepoProduct.Object, mockRepoCart.Object, mockRepoOrder.Object,
                mockLogger.Object);
            var result = locationController.CustomerIndex(1);
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<LocationIndexVM>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }

        [Fact]
        public void CustomerControllerGetAllCustomers()
        {
            mockRepoCustomer.Setup(x => x.GetCustomers())
                .Returns(new List<Customer>()
                {
                     new Customer
                     {
                        Id = 1,
                        CustomerEmail = "123@123.com",
                        CustomerName = "ABC",
                        CustomerPassword = "A"
                     },
                     new Customer
                     {
                        Id = 2,
                        CustomerEmail = "1234@1234.com",
                        CustomerName = "ABCD",
                        CustomerPassword = "B"
                     }
                }
                );
            var CustomerController = new CustomerController(mockRepoCustomer.Object, mockRepoCart.Object, mockMapper.Object, mockRepoLocation.Object, mockRepoOrder.Object, mockLogger.Object);
            var result = CustomerController.AllCustomers();
            Assert.IsType<ViewResult>(result);
        }

/*        [Fact]
        public void CustomerControllerIndex()
        {
            mockRepoCustomer.Setup(x => x.GetCustomerById(1))
                .Returns(new Customer
                {
                    Id = 1,
                    CustomerEmail = "123@123.com",
                    CustomerName = "ABC",
                    CustomerPassword = "A"
                }
                );
            var CustomerController = new CustomerController(mockRepoCustomer.Object, mockRepoCart.Object, mockMapper.Object, mockRepoLocation.Object, mockRepoOrder.Object, mockLogger.Object);
            var result = CustomerController.Index(mockMapper.Object.cast2CustomerIndexVM(mockRepoCustomer.Object.GetCustomerById(1)));
            Assert.IsType<ViewResult>(result);
        }*/

        [Fact]
        public void CustomerControllerAllCustomers()
        {
            mockRepoCustomer.Setup(x => x.GetCustomers())
                .Returns(new List<Customer>()
                {
                     new Customer
                     {
                        Id = 1,
                        CustomerEmail = "123@123.com",
                        CustomerName = "ABC",
                        CustomerPassword = "A"
                     },
                     new Customer
                     {
                        Id = 2,
                        CustomerEmail = "1234@1234.com",
                        CustomerName = "ABCD",
                        CustomerPassword = "B"
                     }
                }
                );
            var CustomerController = new CustomerController(mockRepoCustomer.Object, mockRepoCart.Object, mockMapper.Object, mockRepoLocation.Object, mockRepoOrder.Object, mockLogger.Object);
            var result = CustomerController.AllCustomers();
            var viewResult = Assert.IsType<ViewResult>(result);
            var model = Assert.IsAssignableFrom<IEnumerable<CustomerIndexVM>>(viewResult.Model);
            Assert.Equal(2, model.Count());
        }
    }
}