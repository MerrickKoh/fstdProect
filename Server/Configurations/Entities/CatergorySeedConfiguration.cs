using FoodDeliveryPRojectFull.Shared.Domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FoodDeliveryPRojectFull.Server.Configurations.Entities
{
    public class CatergorySeedConfiguration : IEntityTypeConfiguration<Catergory>
    {
        public void Configure(EntityTypeBuilder<Catergory> builder)
        {
            builder.HasData(
                new Catergory
                {
                    Id = 1,
                    Name = "Sushi",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Catergory
                {
                    Id = 2,
                    Name = "Ramen",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Catergory
                {
                    Id = 3,
                    Name = "Curry",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Catergory
                {
                    Id = 4,
                    Name = "Bento",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Catergory
                {
                    Id = 5,
                    Name = "Soup",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                },
                new Catergory
                {
                    Id = 6,
                    Name = "Drinks",
                    DateCreated = DateTime.Now,
                    DateUpdated = DateTime.Now,
                    CreatedBy = "System",
                    UpdatedBy = "System"
                }
                );
                    
        }
    }
}

