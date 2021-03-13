using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Edit view of my Managers
    /// </summary>
    public class ProductEditVM
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