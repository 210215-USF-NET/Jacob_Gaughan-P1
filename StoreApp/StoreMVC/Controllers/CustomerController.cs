using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Controllers
{
    public class CustomerController : Controller
    {
        private ICustomerBL _customerBL;
        private IMapper _mapper;
        public CustomerController(ICustomerBL customerBL, IMapper mapper)
        {
            _customerBL = customerBL;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            return View();
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(string email)
        {
            return View(_mapper.cast2CustomerCRVM(_customerBL.GetCustomerByEmail(email)));
        }

        public ActionResult Login()
        {
            return View("Login");
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AttemptLogin(Customer customer2Check)
        {
            if(ModelState.IsValid)
            {
                Customer customer = _customerBL.CheckCustomerLoginInfo(customer2Check.CustomerEmail, customer2Check.CustomerPassword);
                if (customer == null)
                {
                    return View();
                }
                else
                {
                    return View(_mapper.cast2CustomerCRVM(_customerBL.GetCustomerByEmail(customer2Check.CustomerEmail)));
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
                    _customerBL.AddCustomer(_mapper.cast2Customer(newCustomer));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
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
