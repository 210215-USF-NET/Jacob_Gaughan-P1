using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Edit view of my Managers
    /// </summary>
    public class ManagerEditVM
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string ManagerName { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string ManagerEmail { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string ManagerPassword { get; set; }
    }
}