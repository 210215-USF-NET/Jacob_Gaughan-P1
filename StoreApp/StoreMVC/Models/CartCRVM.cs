using System.Collections.Generic;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Create/Read view of my customers
    /// </summary>
    public class CartCRVM
    {
        private List<int> productIds;
        private List<int> productQuantities;
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public int LocationId { get; set; }

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