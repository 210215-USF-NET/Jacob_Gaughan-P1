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
    /// Model for the index view of my customers 
    /// </summary>
    public class LocationEditVM
    {
        public int Id { get; set; }
        [DisplayName("Address")]
        public string Address { get; set; }
        [DisplayName("City")]
        public string City { get; set; }
        [DisplayName("State")]
        public string State { get; set; }
        [DisplayName("Zipcode")]
        public string Zipcode { get; set; }
    }
}
