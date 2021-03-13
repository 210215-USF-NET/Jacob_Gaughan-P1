using System.ComponentModel;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the index view of my locations
    /// </summary>
    public class LocationIndexVM
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