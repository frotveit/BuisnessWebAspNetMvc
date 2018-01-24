

using System;
using System.ComponentModel.DataAnnotations;

namespace BuisnessWebCore.Models
{
    public class HourRegistration
    {
        [Required(ErrorMessage = "Please enter employee id")]
        public int EmployeeId { get; set; }

        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Please enter date")]
        public DateTime Date { get; set ; }

        public int Hours { get; set; }
    }
}
