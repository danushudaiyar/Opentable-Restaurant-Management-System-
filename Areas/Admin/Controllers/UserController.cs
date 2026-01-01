using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OpenTable.Data;
using OpenTable.Models;
using System.Linq;

namespace OpenTable.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UserController : Controller
    {
        private readonly OpenTableContext _context;

        public UserController(OpenTableContext context)
        {
            _context = context;
        }

        // GET: Admin/User
        public IActionResult Index()
        {
            return View(_context.Users.ToList());
        }

        // GET: Admin/User/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/User/Create
        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                _context.Add(user);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // GET: Admin/User/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null) return NotFound();
            
            var user = _context.Users.Find(id);
            if (user == null) return NotFound();
            
            return View(user);
        }

        // POST: Admin/User/Edit/5
        [HttpPost]
        public IActionResult Edit(int id, User user)
        {
            if (id != user.Id) return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(user);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UserExists(user.Id)) return NotFound();
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        // POST: Admin/User/Delete/5
        [HttpPost]
        public IActionResult Delete(int id)
        {
            var user = _context.Users.Find(id);
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
            }
            return RedirectToAction(nameof(Index));
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}