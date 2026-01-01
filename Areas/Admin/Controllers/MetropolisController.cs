using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTable.Areas.Admin.ViewModels;
using OpenTable.Data;
using OpenTable.Models;
using System.Linq;

namespace OpenTable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MetropolisController : Controller
    {
        private readonly OpenTableContext _context;

        public MetropolisController(OpenTableContext context)
        {
            _context = context;
        }

        // GET: Admin/Metropolis
        public IActionResult Index()
        {
            var model = new AdminMetropolisViewModel
            {
                Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList(),
                CurrentView = "List" // Changed from Action to CurrentView
            };
            return View(model);
        }

        // GET: Admin/Metropolis/Create
        public IActionResult Create()
        {
            return View(new AdminMetropolisViewModel 
            {
                CurrentView = "Create",
                Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList()
            });
        }

        // POST: Admin/Metropolis/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AdminMetropolisViewModel model)
        {
            if (ModelState.IsValid)
            {
                _context.Metropolises.Add(model.CurrentMetropolis);
                _context.SaveChanges();
                TempData["Message"] = $"{model.CurrentMetropolis.Name} added successfully";
                return RedirectToAction(nameof(Index));
            }

            model.Metropolises = _context.Metropolises.OrderBy(m => m.Name).ToList();
            model.CurrentView = "Create"; // Changed from Action to CurrentView
            return View("Index", model);
        }

        // Similar implementations for Edit and Delete...
    }
}