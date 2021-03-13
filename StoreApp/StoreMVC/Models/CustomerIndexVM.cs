using System.ComponentModel;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the index view of my customers
    /// </summary>
    public class CustomerIndexVM
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [DisplayName("Email")]
        public string CustomerEmail { get; set; }
    }
}