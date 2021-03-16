using Microsoft.AspNetCore.Mvc;
using StoreBL;
using StoreModels;
using StoreMVC.Models;
using System;
using System.Collections.Generic;
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
        private IOrderBL _orderBL;
        private IMapper _mapper;

        public LocationController(ICustomerBL customerBL, ILocationBL locationBL, IMapper mapper, IProductBL productBL, ICartBL cartBL, IOrderBL orderBL)
        {
            _cartBL = cartBL;
            _locationBL = locationBL;
            _productBL = productBL;
            _orderBL = orderBL;
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

        public ActionResult PrevOrders(int locId)
        {
            List<OrderIndexVM> OrderList = new List<OrderIndexVM>();

            foreach (var item in _orderBL.GetOrders().Select(order => _mapper.cast2OrderIndexVM(order)).ToList())
            {
                if (item.LocationId == locId)
                {
                    OrderList.Add(item);
                }
            }
            Tuple<List<OrderIndexVM>, LocationIndexVM> locOrderTuple = new Tuple<List<OrderIndexVM>, LocationIndexVM>(
                OrderList,
                _mapper.cast2LocationIndexVM(_locationBL.GetLocationById(locId)));
            return View(locOrderTuple);
        }

        public ActionResult ManagerProductView(int locId)
        {
            List<ProductIndexVM> ProductList = _productBL.GetProductsAtLocation(locId).Select(product => _mapper.cast2ProductIndexVM(product)).ToList();
            Tuple<LocationIndexVM, List<ProductIndexVM>> locProdsTuple = new Tuple<LocationIndexVM, List<ProductIndexVM>>(
                _mapper.cast2LocationIndexVM(_locationBL.GetLocationById(locId)),
                ProductList);
            return View(locProdsTuple);
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

        // GET: Locations/ProductEdit/5
        public ActionResult ProductEdit(int prodId)
        {
            return View(_mapper.cast2ProductEditVM(_productBL.GetProductById(prodId)));
        }

        // POST: Locations/ProductEdit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(ProductEditVM product2Bupdated)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _productBL.UpdateProduct(_mapper.cast2Product(product2Bupdated));
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
            Tuple<LocationIndexVM, CustomerIndexVM, ProductIndexVM, CartCRVM> tuple = new Tuple<LocationIndexVM, CustomerIndexVM, ProductIndexVM, CartCRVM>(
                _mapper.cast2LocationIndexVM(_locationBL.GetLocationById(locId)),
                _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(custId)),
                _mapper.cast2ProductIndexVM(_productBL.GetProductById(prodId)),
                _mapper.cast2CartCRVM(_cartBL.GetCartById(custId, locId)));
            return View(tuple);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CartMenu(int updatedQuantity, int productId, int locationId, int customerId)
        {
            Tuple<LocationIndexVM, CustomerIndexVM, ProductIndexVM, CartCRVM> tuple = new Tuple<LocationIndexVM, CustomerIndexVM, ProductIndexVM, CartCRVM>(
              _mapper.cast2LocationIndexVM(_locationBL.GetLocationById(locationId)),
              _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(customerId)),
              _mapper.cast2ProductIndexVM(_productBL.GetProductById(productId)),
              _mapper.cast2CartCRVM(_cartBL.GetCartById(customerId, locationId)));
            if (ModelState.IsValid)
            {
                try
                {
                    if (updatedQuantity > _productBL.GetProductById(productId).Quantity)
                    {
                        ViewBag.ErrorMessage = "Out of Stock!";
                        return View(tuple);
                    }
                    else if (updatedQuantity <= 0)
                    {
                        ViewBag.ErrorMessage = $"You want to buy {updatedQuantity}? That doesn't make sense.";
                        return View(tuple);
                    }
                    Cart UpdatedCart = _cartBL.GetCartById(customerId, locationId);
                    UpdatedCart.ProductIds.Add(productId);
                    UpdatedCart.ProductQuantities.Add(updatedQuantity);
                    _cartBL.AddToCart(UpdatedCart);
                    return RedirectToAction("Shop", new { custId = customerId, locId = locationId });
                }
                catch
                {
                    ViewBag.ErrorMessage = "Please enter the required fields!";
                    return View(tuple);
                }
            }
            ViewBag.ErrorMessage = "Please enter the required fields!";
            return View(tuple);
        }

        public ActionResult Checkout(int cartId)
        {
            List<ProductIndexVM> ProductList = new List<ProductIndexVM>();
            foreach (var item in _cartBL.GetCartByCartId(cartId).ProductIds)
            {
                ProductList.Add(_mapper.cast2ProductIndexVM(_productBL.GetProductById(item)));
            }

            Tuple<LocationIndexVM, CustomerIndexVM, CartCRVM, List<ProductIndexVM>> tuple = new Tuple<LocationIndexVM, CustomerIndexVM, CartCRVM, List<ProductIndexVM>>(
                _mapper.cast2LocationIndexVM(_locationBL.GetLocationById(_cartBL.GetCartByCartId(cartId).LocationId)),
                _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(_cartBL.GetCartByCartId(cartId).CustomerId)),
                _mapper.cast2CartCRVM(_cartBL.GetCartByCartId(cartId)),
                ProductList);

            decimal CartTotal = 0.00m;

            for (int j = 0; j < _cartBL.GetCartByCartId(cartId).ProductIds.Count; j++)
            {
                for (int h = 0; h < _cartBL.GetCartByCartId(cartId).ProductQuantities[j]; h++)
                {
                    CartTotal += _productBL.GetProductPrice(_cartBL.GetCartByCartId(cartId).ProductIds[j]);
                }
            }

            ViewBag.Total = CartTotal;

            return View(tuple);
        }

        public ActionResult PlaceOrder(int cartId, decimal total, List<ProductIndexVM> products)
        {
            DateTime now = DateTime.Now;
            Order newOrder = new Order();
            newOrder.CustomerId = _cartBL.GetCartByCartId(cartId).CustomerId;
            newOrder.LocationId = _cartBL.GetCartByCartId(cartId).LocationId;
            newOrder.Total = total;
            newOrder.Date = now;
            foreach (var item in products)
            {
                newOrder.ProductIds.Add(item.Id);
            }
            _orderBL.AddOrder(newOrder);
            int i = 0;
            foreach (var item in _cartBL.GetCartByCartId(cartId).ProductIds)
            {
                Product updateProduct = _productBL.GetProductById(item);
                updateProduct.Quantity = _productBL.GetProductById(item).Quantity - _cartBL.GetCartByCartId(cartId).ProductQuantities[i];
                _productBL.UpdateProduct(updateProduct);
                i++;
            }
            Cart UpdatedCart = _cartBL.GetCartByCartId(cartId);
            UpdatedCart.ProductIds.Clear();
            UpdatedCart.ProductQuantities.Clear();
            _cartBL.AddToCart(UpdatedCart);

            return RedirectToAction("Index", "Customer", _mapper.cast2CustomerIndexVM(_customerBL.GetCustomerById(_cartBL.GetCartByCartId(cartId).CustomerId)));
        }
    }
}