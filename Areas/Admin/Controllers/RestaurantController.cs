using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTable.Areas.Admin.ViewModels;
using OpenTable.Models;
using OpenTable.Data; 
using System.Linq;

namespace OpenTable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RestaurantController : Controller
    {
        private readonly OpenTableContext _context;

        public RestaurantController(OpenTableContext context)
        {
            _context = context;
        }

        // GET: Admin/Restaurant
        public IActionResult Index()
        {
            var model = new AdminRestaurantViewModel
            {
                Restaurants = _context.Restaurants
                    .Include(r => r.Metropolis)
                    .OrderBy(r => r.Name)
                    .ToList(),
                Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Filter(string[] filter)
        {
            var model = new AdminRestaurantViewModel
            {
                SelectedMetropolis = filter.Length > 0 ? filter[0] : "all",
                SelectedPriceRange = filter.Length > 1 ? filter[1] : "all",
                SelectedCuisine = filter.Length > 2 ? filter[2] : "all",
                Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList()
            };

            // Build query with filters
            IQueryable<Restaurant> query = _context.Restaurants.Include(r => r.Metropolis);

            if (model.SelectedMetropolis != "all")
                query = query.Where(r => r.MetropolisId == int.Parse(model.SelectedMetropolis));

            if (model.SelectedPriceRange != "all")
                query = query.Where(r => r.PriceRange == model.SelectedPriceRange);

            if (model.SelectedCuisine != "all")
                query = query.Where(r => r.CuisineStyle == model.SelectedCuisine);

            model.Restaurants = query.OrderBy(r => r.Name).ToList();

            return View("Index", model);
        }

        // GET: Admin/Restaurant/Add
        public IActionResult Add()
        {
            var model = new AdminRestaurantViewModel
            {
                Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList(),
                CurrentRestaurant = new Restaurant()
            };
            return View(model);
        }

        [HttpPost]
        public IActionResult Add(AdminRestaurantViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Restaurants.Add(model.CurrentRestaurant);
                _context.SaveChanges();
                TempData["Message"] = $"{model.CurrentRestaurant.Name} added successfully";
                return RedirectToAction(nameof(Index));
            }

            // If we got this far, something failed; redisplay form
            model.Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList();
            return View(model);
        }

        // Similar implementations for Edit and Delete actions
        // ...
    }
}