using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Create/Read view of my Managers
    /// </summary>
    public class ManagerCRVM
    {
        public int Id { get; set; }

        [DisplayName("Name")]
        [Required]
        public string ManagerName { get; set; }

        [DisplayName("Email")]
        [Required]
        [DataType(DataType.EmailAddress)]
        public string ManagerEmail { get; set; }

        [DisplayName("Password")]
        [Required]
        [DataType(DataType.Password)]
        public string ManagerPassword { get; set; }
    }
}