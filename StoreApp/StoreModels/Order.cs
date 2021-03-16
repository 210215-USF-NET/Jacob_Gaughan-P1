using System;
using System.Collections.Generic;

namespace StoreModels
{
    /// <summary>
    /// This class should contain all the fields and properties that define a customer order.
    /// </summary>
    public class Order
    {
        private List<int> productIds;
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public int LocationId { get; set; }
        public Location Location { get; set; }

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

        public decimal Total { get; set; }
        public DateTime Date { get; set; }
        public int Id { get; set; }
    }
}