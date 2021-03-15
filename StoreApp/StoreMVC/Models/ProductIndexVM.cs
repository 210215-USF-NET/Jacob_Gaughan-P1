using System.ComponentModel;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the index view of my managers
    /// </summary>
    public class ProductIndexVM
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        [DisplayName("Name")]
        public string ProductName { get; set; }

        [DisplayName("Price")]
        public decimal ProductPrice { get; set; }

        [DisplayName("Quantity")]
        public int Quantity { get; set; }
    }
}