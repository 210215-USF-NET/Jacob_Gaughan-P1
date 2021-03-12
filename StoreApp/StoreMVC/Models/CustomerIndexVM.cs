using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

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
        [DisplayName("Password")]
        public string CustomerPassword { get; set; }
    }
}
