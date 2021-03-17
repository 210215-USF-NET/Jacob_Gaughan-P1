using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using StoreBL;
using StoreModels;
using StoreMVC.Models;

namespace StoreMVC.Controllers
{
    public class ManagerController : Controller
    {
        private IManagerBL _managerBL;
        private IMapper _mapper;
        private readonly ILogger<HomeController> _logger;

        public ManagerController(IManagerBL managerBL, IMapper mapper, ILogger<HomeController> logger)
        {
            _managerBL = managerBL;
            _mapper = mapper;
            _logger = logger;
        }

        // GET: ManagerController
        public ActionResult Index(ManagerIndexVM currentManager)
        {
            ViewBag.currentManager = currentManager.ManagerEmail;
            return View(currentManager);
        }

        public ActionResult ManagerIndex(string email)
        {
            return RedirectToAction("Index", _mapper.cast2ManagerIndexVM(_managerBL.GetManagerByEmail(email)));
        }

        public ActionResult Details(string email)
        {
            return View(_mapper.cast2ManagerCRVM(_managerBL.GetManagerByEmail(email)));
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(Manager manager2Check)
        {
            if (ModelState.IsValid)
            {
                Manager manager = _managerBL.CheckManagerLoginInfo(manager2Check.ManagerEmail, manager2Check.ManagerPassword);
                if (manager != null)
                {
                    _logger.LogInformation($"Manager Logged in:  Account Email: {manager2Check.ManagerEmail}");
                    return RedirectToAction("Index", _mapper.cast2ManagerIndexVM(_managerBL.GetManagerByEmail(manager2Check.ManagerEmail)));
                }
                else
                {
                    ViewBag.ErrorMessage = "Incorrect Email or Password!";
                    return View();
                }
            }
            return View();
        }

        // GET: ManagerController/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: ManagerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ManagerCRVM newManager)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (_managerBL.GetManagerByEmail(newManager.ManagerEmail) == null)
                    {
                        Manager createdManager = _mapper.cast2Manager(newManager);
                        _managerBL.AddManager(_mapper.cast2Manager(newManager));
                        return RedirectToAction("Index", _mapper.cast2ManagerIndexVM(_mapper.cast2Manager(newManager)));
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

        // GET: ManagerController/Edit/5
        public ActionResult Edit(string email)
        {
            return View(_mapper.cast2ManagerEditVM(_managerBL.GetManagerByEmail(email)));
        }

        // POST: ManagerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ManagerEditVM manager2Edit)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _managerBL.UpdateManager(_mapper.cast2Manager(manager2Edit));
                    return RedirectToAction("ToDetails", manager2Edit.ManagerEmail);
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: ManagerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: ManagerController/Delete/5
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