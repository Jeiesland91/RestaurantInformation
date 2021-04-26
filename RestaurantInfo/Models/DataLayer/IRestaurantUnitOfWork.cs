namespace RestaurantInfo.Models
{
    public interface IRestaurantUnitOfWork
    {
        public IRepository<Chef> Chefs { get; }
        public IRepository<Restaurant> Restaurants { get; }

        public void Save();
    }
}
