using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace RestaurantInfo.Models
{
    internal class RestaurantConfig : IEntityTypeConfiguration<Restaurant>
    {
        public void Configure(EntityTypeBuilder<Restaurant> entity)
        {
            entity.HasOne(r => r.Chef)
                .WithMany(r => r.Restaurants)
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasData(
                new Restaurant { RestaurantId = 1, Name = "Mastro's", Cuisine = "Steakhouse", ChefId = 1 },
                new Restaurant { RestaurantId = 2, Name = "True Food Kitchen", Cuisine = "Healthy", ChefId = 1 },
                new Restaurant { RestaurantId = 3, Name = "Oceans Grill", Cuisine = "Seafood", ChefId = 4 },
                new Restaurant { RestaurantId = 4, Name = "SOL Mexican Grill", Cuisine = "Mexican", ChefId = 4 },
                new Restaurant { RestaurantId = 5, Name = "Habanero's", Cuisine = "Mexican", ChefId = 2 },
                new Restaurant { RestaurantId = 6, Name = "Sushi Roku", Cuisine = "Sushi", ChefId = 2 },
                new Restaurant { RestaurantId = 7, Name = "Sakana Sushi & Grill", Cuisine = "Sushi", ChefId = 5},
                new Restaurant { RestaurantId = 8, Name = "Roka Akor", Cuisine = "Japanese", ChefId = 5},
                new Restaurant { RestaurantId = 9, Name = "White Chocolate Grill", Cuisine = "American", ChefId = 3 },
                new Restaurant { RestaurantId = 10, Name = "Tommy Bahamas Grill", Cuisine = "American", ChefId = 3}
            );
        }
    }
}
