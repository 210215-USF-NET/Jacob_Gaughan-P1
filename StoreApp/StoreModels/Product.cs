using System;

namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        public decimal ProductPrice;
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public int Id { get; set; }
        public Location Location { get; set; }
        public Inventory Inventory { get; set; }
        public Cart Cart { get; set; }
    }
}