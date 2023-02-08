using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryPRojectFull.Shared.Domains
{
    public class Customer : BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does notmeet length requirements")]
        public string Name { get; set; }
        [Required]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"(6|8|9)\d{7}",ErrorMessage ="Please enter a valid phone number")]
        public string Contact { get; set; }
        [StringLength(100, MinimumLength = 5, ErrorMessage = "Address does not meet length requirements")]
        public string Address { get; set; }
        [Required]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public int PaymentId { get; set; }
        public virtual Payment Payment { get; set; }
        public virtual List<Orders> Orders { get; set; }

    }
}