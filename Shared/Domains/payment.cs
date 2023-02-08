using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace FoodDeliveryPRojectFull.Shared.Domains
{
    public class Payment:BaseDomainModel,IValidatableObject
    {
        [Required]
        [StringLength(4, MinimumLength = 3, ErrorMessage = "SVC Only contains 3-4 Number")]
         public string Svc { get; set; }
       
        [Required]
        [DataType(DataType.CreditCard)]
        public string CardNo { get; set; }
        public DateTime Expire { get; set; } = DateTime.Now;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if(Expire<DateTime.Today)
            {
                yield return new ValidationResult("Expiry Date cannot be before Today",new[] { "Expire" });
            }

        }
    }
}