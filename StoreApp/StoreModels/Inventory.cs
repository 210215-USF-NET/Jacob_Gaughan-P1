using System;
using System.Text.RegularExpressions;
namespace StoreModels
{

    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.  
    /// </summary>
    public class Inventory
    {
        private int quantity;
        public int ProductId { get; set; }
        public Product Product;
        public int LocationId { get; set; }
        public Location Location;
        public int Id { get; set; }
        public int Quantity { get; set; }
    }
}