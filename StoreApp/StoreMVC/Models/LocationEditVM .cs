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
    /// Model for the Edit view of my locations
    /// </summary>
    public class LocationEditVM
    {
        public int Id { get; set; }
        [DisplayName("Address")]
        [Required]
        public string Address { get; set; }
        [DisplayName("City")]
        [Required]
        public string City { get; set; }
        [DisplayName("State")]
        [Required]
        public string State { get; set; }
        [DisplayName("Zipcode")]
        [Required]
        public string Zipcode { get; set; }
    }
}
