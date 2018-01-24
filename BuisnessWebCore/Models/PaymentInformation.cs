

using System.ComponentModel.DataAnnotations;

namespace BuisnessWebCore.Models
{
    public class PaymentInformation
    {
        [Key]
        public int Id { get; set; }        

        public PaymentModel PaymentModel { get; set; }

        public PaymentFrequency PaymentFrequency { get; set; }

        [StringLength(20)]
        public string BankAccount { get; set; }
    }
}
