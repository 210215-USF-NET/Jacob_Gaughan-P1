using StoreModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Create/Read view of my customers
    /// </summary>
    public class ProductCRVM
    {
        public int Id { get; set; }
        public int LocationId { get; set; }

        [DisplayName("Name")]
        [Required]
        public string ProductName { get; set; }

        [DisplayName("Price")]
        [Required]
        public decimal ProductPrice { get; set; }

        [DisplayName("Quantity")]
        [Required]
        public int Quantity { get; set; }
    }
}