using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FoodDeliveryPRojectFull.Shared.Domains
{
    public class Orders : BaseDomainModel,IValidatableObject
    {
        [Required]
        public DateTime OrderTime { get; set; } = DateTime.Now;
        [Required]
        public int FoodId { get; set; }
        public virtual List<Food> Foods { get; set; }
        public Food Food { get; set; }
        [Required]
        public int CustomerId { get; set; }
        public virtual Customer Customer{ get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            //throw new NotImplementedException();
            if (OrderTime < DateTime.Today)
            {
                yield return new ValidationResult("Sorry we don't have a time machine to deliver to the time you selected.", new[] { "OrderTime" });
            }
        }
    }
}