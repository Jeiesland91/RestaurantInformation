using RestaurantInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantInfo.Controllers
{
    public class RestaurantController : Controller
    {
        private IRestaurantUnitOfWork data { get; set; }
        public RestaurantController(IRestaurantUnitOfWork unit) => data = unit;

        public RedirectToActionResult Index() => RedirectToAction("Index", "Home");

        [HttpGet]
        public ViewResult Add()
        {
            this.LoadViewBag("Add");
            return View();
        }

        [HttpGet]
        public ViewResult Edit(int id)
        {
            this.LoadViewBag("Edit");
            var r = this.GetRestaurant(id);
            return View("Add", r);
        }

        [HttpPost]
        public IActionResult Add(Restaurant r)
        {
            if (ModelState.IsValid)
            {
                if (r.RestaurantId == 0)
                    data.Restaurants.Insert(r);
                else
                    data.Restaurants.Update(r);
                data.Restaurants.Save();
                return RedirectToAction("Index", "Home");
            }
            else
            {
                string operation = (r.RestaurantId == 0) ? "Add" : "Edit";
                this.LoadViewBag(operation);
                return View();
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            var r = this.GetRestaurant(id);
            return View(r);
        }

        [HttpPost]
        public RedirectToActionResult Delete(Restaurant r)
        {
            data.Restaurants.Delete(r);
            data.Restaurants.Save();
            return RedirectToAction("Index", "Home");
        }

        // private helper methods
        private Restaurant GetRestaurant(int id)
        {
            var restaurantOptions = new QueryOptions<Restaurant>
            {
                Includes = "Chef",
                Where = r => r.RestaurantId == id
            };
            return data.Restaurants.Get(restaurantOptions);
        }

        private void LoadViewBag(string operation)
        {
           ViewBag.Chefs = data.Chefs.List(new QueryOptions<Chef>
            {
                OrderBy = t => t.LastName
            });
            ViewBag.Operation = operation;
        }
    }
}
