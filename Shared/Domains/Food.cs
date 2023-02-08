using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodDeliveryPRojectFull.Shared.Domains
{
    public class Food:BaseDomainModel
    {
        [Required]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "Name does not meet length requirements")]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public int EventsId { get; set; }
        public virtual Events Events { get; set; }
        [Required]
        public int CatergoryId { get; set; }
        public virtual Catergory Catergory { get; set; }
        [Required]
        public string ImgUrl { get; set; }

    }
}
