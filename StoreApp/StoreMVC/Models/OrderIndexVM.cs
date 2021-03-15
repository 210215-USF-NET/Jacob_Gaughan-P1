using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the index view of my managers
    /// </summary>
    public class OrderIndexVM
    {
        private List<int> productIds;

        public int Id { get; set; }

        public int CustomerId { get; set; }

        [DisplayName("Location ID")]
        public int LocationId { get; set; }

        [DisplayName("Date")]
        public DateTime Date { get; set; }

        [DisplayName("Total")]
        public decimal Total { get; set; }

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
    }
}