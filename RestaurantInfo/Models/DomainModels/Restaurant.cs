using System.ComponentModel.DataAnnotations;

namespace RestaurantInfo.Models
{
    public class Restaurant
    {
        public int RestaurantId { get; set; }                    // PK

        [StringLength(200, ErrorMessage = "Name may not exceed 200 characters.")]
        [Required(ErrorMessage = "Please enter the restaurant name.")]
        public string Name { get; set; }

        [StringLength(50, ErrorMessage = "Name may not exceed 50 characters.")]
        [Required(ErrorMessage = "Please enter cuisine of restaurant.")]
        public string Cuisine { get; set; }

        public int ChefId { get; set; }                  // Foreign key property
        public Chef Chef { get; set; }                // Navigation property
    }
}
