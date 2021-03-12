using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Cart
    {
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}