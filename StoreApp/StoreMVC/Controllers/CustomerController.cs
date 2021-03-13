using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;

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
        public ActionResult Index(CustomerIndexVM currentCustomer)
        {
            ViewBag.currentCustomer = currentCustomer.CustomerEmail;
            return View(currentCustomer);
        }

        public ActionResult CustomerIndex(string email)
        {
            return RedirectToAction("Index", _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerByEmail(email)));
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
                        return RedirectToAction("Index", _mapper.cast2CustomerIndexVM(_mapper.cast2Customer(newCustomer)));
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