using RestaurantInfo.Models;
using Microsoft.AspNetCore.Mvc;

namespace RestaurantInfo.Controllers
{
    public class ChefController : Controller
    {
        private IRepository<Chef> chefs { get; set; }
        public ChefController(IRepository<Chef> rep) => chefs = rep;

        public ViewResult Index()
        {
            var options = new QueryOptions<Chef>
            {
                OrderBy = t => t.LastName
            };
            return View(chefs.List(options));
        }

        [HttpGet]
        public ViewResult Add() => View();

        [HttpPost]
        public IActionResult Add(Chef chef)
        {
            if (ModelState.IsValid)
            {
                chefs.Insert(chef);
                chefs.Save();
                return RedirectToAction("Index");
            }
            else
            {
                return View(chef);
            }
        }

        [HttpGet]
        public ViewResult Delete(int id)
        {
            return View(chefs.Get(id));
        }

        [HttpPost]
        public RedirectToActionResult Delete(Chef chef)
        {
            chefs.Delete(chef);
            chefs.Save();
            return RedirectToAction("Index");
        }
    }
}
