using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreMVC.Models;
using System.Dynamic;
using System.Linq;

namespace StoreMVC.Controllers
{
    public class LocationController : Controller
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private IInventoryBL _inventoryBL;
        private IProductBL _productBL;
        private IMapper _mapper;

        public LocationController(ICustomerBL customerBL, ILocationBL locationBL, IMapper mapper, IProductBL productBL, IInventoryBL inventoryBL)
        {
            _locationBL = locationBL;
            _productBL = productBL;
            _inventoryBL = inventoryBL;
            _customerBL = customerBL;
            _mapper = mapper;
        }

        // GET: LocationController
        public ActionResult Index()
        {
            return View(_locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult CustomerIndex(string email)
        {
            ViewBag.currentCustomerEmail = email;
            return View(_locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult Shop(int locId)
        {
            dynamic locProdInv = new ExpandoObject();
            locProdInv.Location = _locationBL.GetLocationById(locId);
            locProdInv.Products = _productBL.GetProductsAtLocation(locId);
            locProdInv.Inventories = _inventoryBL.GetInventoriesAtLocation(locId);
            return View(locProdInv);
        }

        public ActionResult Details(int Id)
        {
            return View(_mapper.cast2LocationCRVM(_locationBL.GetLocationById(Id)));
        }

        // GET: Locations/Create
        public ActionResult Create()
        {
            return View("Create");
        }

        // POST: Location/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LocationCRVM newLocation)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _locationBL.AddLocation(_mapper.cast2Location(newLocation));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int Id)
        {
            return View(_mapper.cast2LocationEditVM(_locationBL.GetLocationById(Id)));
        }

        // POST: Locations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(LocationEditVM location2Bupdated)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _locationBL.UpdateLocation(_mapper.cast2Location(location2Bupdated));
                    return RedirectToAction(nameof(Index));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(int Id)
        {
            _locationBL.DeleteLocation(_locationBL.GetLocationById(Id));
            return RedirectToAction(nameof(Index));
        }
    }
}