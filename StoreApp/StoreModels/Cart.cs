using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This data structure models a product and its quantity. The quantity was separated from the product as it could vary from orders and locations.
    /// </summary>
    public class Cart
    {
        private List<int> productIds;
        private List<int> productQuantities;
        public int CustomerId { get; set; }
        public int LocationId { get; set; }
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public Location Location { get; set; }
        public ICollection<Product> Products { get; set; }

        public List<int> ProductIds
        {
            get { return productIds; }
            set
            {
                if (value == null)
                {
                    value = new List<int>();
                }
                productIds = value;
            }
        }

        public List<int> ProductQuantities
        {
            get { return productQuantities; }
            set
            {
                if (value == null)
                {
                    value = new List<int>();
                }
                productQuantities = value;
            }
        }
    }
}