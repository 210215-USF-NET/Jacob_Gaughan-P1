﻿using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace StoreMVC.Models
{
    /// <summary>
    /// Model for the Edit view of my customers
    /// </summary>
    public class CustomerEditVM
    {
        public int Id { get; set; }

        [Required]
        [DisplayName("Name")]
        public string CustomerName { get; set; }

        [Required]
        [DisplayName("Email")]
        [DataType(DataType.EmailAddress)]
        public string CustomerEmail { get; set; }

        [Required]
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string CustomerPassword { get; set; }
    }
}