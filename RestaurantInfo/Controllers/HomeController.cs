using RestaurantInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantInfo.Controllers
{
    public class HomeController : Controller
    {
        private IRepository<Restaurant> data { get; set; }
        public HomeController(IRepository<Restaurant> rep) => data = rep;

        public ViewResult Index(int id)
        {
            // options for Classes query
            var restaurantOptions = new QueryOptions<Restaurant>
            {
                Includes = "Chef"
            };
           

            return View(data.List(restaurantOptions));
        }
    }
}
