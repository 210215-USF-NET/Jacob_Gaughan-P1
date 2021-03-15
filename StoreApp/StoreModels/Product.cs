namespace StoreModels
{
    //This class should contain all necessary fields to define a product.
    public class Product
    {
        public decimal ProductPrice { get; set; }
        public string ProductName { get; set; }
        public int Id { get; set; }
        public int LocationId { get; set; }
        public int Quantity { get; set; }
        public Location Location { get; set; }
    }
}