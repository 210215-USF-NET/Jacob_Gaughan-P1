using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private ICartBL _cartBL;
        private IOrderBL _orderBL;
        private IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public CustomerController(ICustomerBL customerBL, ICartBL cartBL, IMapper mapper, ILocationBL locationBL, IOrderBL orderBL, ILogger<HomeController> logger)
        {
            _logger = logger;
            _locationBL = locationBL;
            _cartBL = cartBL;
            _customerBL = customerBL;
            _orderBL = orderBL;
            _mapper = mapper;
        }

        // GET: CustomerController
        public ActionResult Index(CustomerIndexVM currentCustomer)
        {
            ViewBag.CustomerId = currentCustomer.Id;
            return View(currentCustomer);
        }

        public ActionResult CustomerIndex(int custId)
        {
            return RedirectToAction("Index", _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(custId)));
        }

        public ActionResult PrevOrders(int custId)
        {
            List<LocationIndexVM> LocationList = _locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList();
            List<OrderIndexVM> OrderList = new List<OrderIndexVM>();

            foreach (var item in _orderBL.GetOrders().Select(order => _mapper.cast2OrderIndexVM(order)).ToList())
            {
                if (item.CustomerId == custId)
                {
                    OrderList.Add(item);
                }
            }
            Tuple<CustomerIndexVM, List<OrderIndexVM>, List<LocationIndexVM>> custOrderTuple = new Tuple<CustomerIndexVM, List<OrderIndexVM>, List<LocationIndexVM>>(
                _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(custId)),
                OrderList,
                LocationList
                );
            return View(custOrderTuple);
        }

        public ActionResult Details(string email)
        {
            return View(_mapper.cast2CustomerCRVM(_customerBL.GetCustomerByEmail(email)));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Customer customer2Check)
        {
            if (ModelState.IsValid)
            {
                Customer customer = _customerBL.CheckCustomerLoginInfo(customer2Check.CustomerEmail, customer2Check.CustomerPassword);
                if (customer != null)
                {
                    int custId = _customerBL.GetCustomerByEmail(customer2Check.CustomerEmail).Id;
                    //create carts for each location
                    foreach (var item in _locationBL.GetLocations())
                    {
                        if (_cartBL.GetCartById(custId, item.Id) == null)
                        {
                            Cart newCart = new Cart();
                            newCart.CustomerId = custId;
                            newCart.LocationId = item.Id;
                            newCart.ProductIds = new List<int>();
                            newCart.ProductQuantities = new List<int>();
                            _cartBL.AddCart(newCart);
                        }
                    }
                    _logger.LogInformation($"User Logged in: Email: {_customerBL.GetCustomerById(custId).CustomerEmail} ID: {custId}");
                    return RedirectToAction("Index", _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerByEmail(customer2Check.CustomerEmail)));
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Email or Password!";
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerCRVM newCustomer)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_customerBL.GetCustomerByEmail(newCustomer.CustomerEmail) == null)
                    {
                        Customer createdCustomer = _mapper.cast2Customer(newCustomer);
                        _customerBL.AddCustomer(_mapper.cast2Customer(newCustomer));
                        int custId = _customerBL.GetCustomerByEmail(newCustomer.CustomerEmail).Id;
                        //create carts for each location
                        foreach (var item in _locationBL.GetLocations())
                        {
                            Cart newCart = new Cart();
                            newCart.CustomerId = _customerBL.GetCustomerByEmail(newCustomer.CustomerEmail).Id;
                            newCart.LocationId = item.Id;
                            newCart.ProductIds = new List<int>();
                            newCart.ProductQuantities = new List<int>();
                            _cartBL.AddCart(newCart);
                        }
                        _logger.LogInformation($"New User Created: Email: {_customerBL.GetCustomerById(custId).CustomerEmail} ID: {custId}");
                        return RedirectToAction("Index", _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(custId)));
                    }
                    else
                    {
                        ViewBag.ErrorMessage = "An account already exists with this email!";
                        return View();
                    }
                }
                catch
                {
                    ViewBag.ErrorMessage = "Please enter the required fields!";
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(string email)
        {
            return View(_mapper.cast2CustomerEditVM(_customerBL.GetCustomerByEmail(email)));
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerEditVM customer2Edit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _customerBL.UpdateCustomer(_mapper.cast2Customer(customer2Edit));
                    return RedirectToAction("ToDetails", customer2Edit.CustomerEmail);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}