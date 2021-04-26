using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantInfo.Models
{
    internal class ChefConfig : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> entity)
        {
            entity.HasData(
                new Chef { ChefId = 1, FirstName = "John", LastName = "Montgomery" },
                new Chef { ChefId = 2, FirstName = "Hannah", LastName = "Smith" },
                new Chef { ChefId = 3, FirstName = "Jackson", LastName = "Brown" },
                new Chef { ChefId = 4, FirstName = "Wilson", LastName = "Thomas" },
                new Chef { ChefId = 5, FirstName = "Kelly", LastName = "Hughes" }
            );
        }
    }
}
