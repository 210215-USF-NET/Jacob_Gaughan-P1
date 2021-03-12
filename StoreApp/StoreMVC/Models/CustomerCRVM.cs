using StoreDL;
using StoreModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Create/Read view of my customers 
    /// </summary>
    public class CustomerCRVM
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required]
        public string CustomerName { get; set; }
        [DisplayName("Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }
        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
    }
}
