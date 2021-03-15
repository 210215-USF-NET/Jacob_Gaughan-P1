using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System.Dynamic;
using System.Linq;

namespace StoreMVC.Controllers
{
    public class LocationController : Controller
    {
        private ICustomerBL _customerBL;
        private ILocationBL _locationBL;
        private ICartBL _cartBL;
        private IProductBL _productBL;
        private IMapper _mapper;

        public LocationController(ICustomerBL customerBL, ILocationBL locationBL, IMapper mapper, IProductBL productBL, ICartBL cartBL)
        {
            _cartBL = cartBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _customerBL = customerBL;
            _mapper = mapper;
        }

        // GET: LocationController
        public ActionResult Index()
        {
            return View(_locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult CustomerIndex(int custId)
        {
            ViewBag.CustomerId = custId;
            return View(_locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult ManagerIndex()
        {
            return View(_locationBL.GetLocations().Select(location => _mapper.cast2LocationIndexVM(location)).ToList());
        }

        public ActionResult Shop(int locId, int custId)
        {
            dynamic locProdCust = new ExpandoObject();
            locProdCust.Customer = _customerBL.GetCustomerById(custId);
            locProdCust.Location = _locationBL.GetLocationById(locId);
            locProdCust.Products = _productBL.GetProductsAtLocation(locId);
            locProdCust.Cart = _cartBL.GetCartById(custId, locId);

            ViewBag.CustomerId = custId;
            ViewBag.LocationId = locId;

            return View(locProdCust);
        }

        public ActionResult ManagerProductView(int locId)
        {
            dynamic locProdInv = new ExpandoObject();
            locProdInv.Location = _locationBL.GetLocationById(locId);
            locProdInv.Products = _productBL.GetProductsAtLocation(locId);
            return View(locProdInv);
        }

        public ActionResult CreateProduct(int locId)
        {
            ViewBag.LocId = locId;
            @ViewBag.ErrorMessage = "Please enter the corrent information.";
            return View("CreateProduct");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateProduct(ProductCRVM newProduct)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productBL.AddProduct(_mapper.cast2Product(newProduct));
                    return RedirectToAction("ManagerIndex");
                }
                catch
                {
                    return View();
                }
            }
            return View();
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
                    return RedirectToAction(nameof(ManagerIndex));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        // GET: Locations/Edit/5
        public ActionResult Edit(int locId)
        {
            return View(_mapper.cast2LocationEditVM(_locationBL.GetLocationById(locId)));
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
                    return RedirectToAction(nameof(ManagerIndex));
                }
                catch
                {
                    return View();
                }
            }
            return View();
        }

        public ActionResult Delete(int locId)
        {
            return View(_mapper.cast2LocationEditVM(_locationBL.GetLocationById(locId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(LocationEditVM location2Bdeleted)
        {
            _locationBL.DeleteLocation(_mapper.cast2Location(location2Bdeleted));
            return RedirectToAction(nameof(ManagerIndex));
        }

        public ActionResult CartMenu(int custId, int locId, int prodId)
        {
            @ViewBag.Location = $"{_locationBL.GetLocationById(locId).Address} {_locationBL.GetLocationById(locId).City}, {_locationBL.GetLocationById(locId).State} ({_locationBL.GetLocationById(locId).Zipcode})";
            @ViewBag.LocationId = locId;
            @ViewBag.CustomerName = _customerBL.GetCustomerById(custId).CustomerName;
            @ViewBag.CustomerId = custId;
            @ViewBag.ProductId = prodId;
            @ViewBag.ProductName = _productBL.GetProductById(prodId).ProductName;
            @ViewBag.ProductAvailable = _productBL.GetProductById(prodId).Quantity;
            return View(_mapper.cast2CartCRVM(_cartBL.GetCartById(custId, locId)));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CartMenu(CartCRVM currentCart)
        {
            @ViewBag.Location = $"{_locationBL.GetLocationById(currentCart.LocationId).Address} {_locationBL.GetLocationById(currentCart.LocationId).City}, {_locationBL.GetLocationById(currentCart.LocationId).State} ({_locationBL.GetLocationById(currentCart.LocationId).Zipcode})";
            @ViewBag.LocationId = currentCart.LocationId;
            @ViewBag.ProductId = currentCart.TempProdId;
            @ViewBag.CustomerId = currentCart.CustomerId;
            @ViewBag.CustomerName = _customerBL.GetCustomerById(currentCart.CustomerId).CustomerName;
            @ViewBag.ProductName = _productBL.GetProductById(currentCart.TempProdId).ProductName;
            @ViewBag.ProductAvailable = _productBL.GetProductById(currentCart.TempProdId).Quantity;
            if (ModelState.IsValid)
            {
                try
                {
                    if (currentCart.TempQuantity > _productBL.GetProductById(currentCart.TempProdId).Quantity)
                    {
                        ViewBag.ErrorMessage = "Out of Stock!";
                        return View();
                    }
                    else if (currentCart.TempQuantity == 0)
                    {
                        ViewBag.ErrorMessage = "x + 0 = x!";
                        return View();
                    }
                    currentCart.ProductIds.Add(currentCart.TempProdId);
                    currentCart.ProductQuantities.Add(currentCart.TempQuantity);
                    _cartBL.AddToCart(_mapper.cast2Cart(currentCart));
                    return RedirectToAction("Shop", new { custId = currentCart.CustomerId, locId = currentCart.LocationId });
                }
                catch
                {
                    ViewBag.ErrorMessage = "Please enter the required fields!";
                    return View();
                }
            }
            ViewBag.ErrorMessage = "Please enter the required fields!";
            return View();
        }

        public ActionResult ViewCart()
        {
            return View();
        }
    }
}