using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a store location.
    /// </summary>
    public class Location
    {
        public string Address { get; set; }
        public string City { get; set; }
        public int Id { get; set; }
        public string State { get; set; }
        public string Zipcode { get; set; }
        public ICollection<Order> Orders { get; set; }
        public ICollection<Product> Products { get; set; }
        public ICollection<Cart> Carts { get; set; }
    }
}