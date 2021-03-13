using System.ComponentModel;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the index view of my managers
    /// </summary>
    public class ManagerIndexVM
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        public string ManagerName { get; set; }

        [DisplayName("Email")]
        public string ManagerEmail { get; set; }
    }
}