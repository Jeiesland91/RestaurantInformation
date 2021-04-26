using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestaurantInfo.Models
{
    public class RestaurantUnitOfWork : IRestaurantUnitOfWork
    {
        private RestaurantContext context { get; set; }
        public RestaurantUnitOfWork(RestaurantContext ctx) => context = ctx;


        private IRepository<Chef> chefData;
        public IRepository<Chef> Chefs
        {
            get
            {
                if (chefData == null)
                    chefData = new Repository<Chef>(context);
                return chefData;
            }
        }

        private IRepository<Restaurant> restaurantData;
        public IRepository<Restaurant> Restaurants
        {
            get
            {
                if (restaurantData == null)
                    restaurantData = new Repository<Restaurant>(context);
                return restaurantData;
            }
        }

        public void Save() => context.SaveChanges();
    }
}
