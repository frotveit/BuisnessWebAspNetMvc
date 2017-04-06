

using System.ComponentModel.DataAnnotations;

namespace BuisnessWeb.Models
{
    public class Employee
    {
        [Key]
        [Display(Name ="Employee number")]
        [Required(ErrorMessage = "Please enter employee number")]        
        public int EmployeeId { get; set; }

        [Required(ErrorMessage ="Please enter name")]
        [StringLength(50)]
        public string Name { get; set; }

        [DataType(DataType.PhoneNumber)]
        public int Phone { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [StringLength(250)]
        public string Address { get; set; }

        [StringLength(20)]
        public string SocialSecurityNumber { get; set; }

        public int PaymentInformationId { get; set; }
        public PaymentInformation PaymentInformation { get; set; }

    }
}
