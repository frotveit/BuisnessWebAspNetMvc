﻿

using System.ComponentModel.DataAnnotations;

namespace BuisnessWebCore.Models
{
    public class EmployeeIdentificator
    {
        [Key]
        [Display(Name = "Employee number")]
        [Required(ErrorMessage = "Please enter employee number")]
        public int EmployeeId { get; set; }
    }
}
