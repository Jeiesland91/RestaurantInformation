using Microsoft.EntityFrameworkCore;

namespace RestaurantInfo.Models
{
    public class RestaurantContext : DbContext
    {
        public RestaurantContext(DbContextOptions<RestaurantContext> options)
            : base(options)
        { }

        public DbSet<Chef> Chefs { get; set; }
        public DbSet<Restaurant> Restaurants { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ChefConfig());
            modelBuilder.ApplyConfiguration(new RestaurantConfig());
        }
    }
}
