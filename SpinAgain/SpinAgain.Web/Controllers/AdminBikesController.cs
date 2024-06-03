using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpinAgain.Web.Data;
using SpinAgain.Web.Models;

namespace SpinAgain.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminBikesController : Controller
    {
        private readonly SpinAgainDBContext _context;

        public AdminBikesController(SpinAgainDBContext context)
        {
            _context = context;
        }

        // GET: AdminBikes
        public IActionResult Index()
        {
            var bikes = _context.Bikes.ToList();
            return View(bikes);
        }

        // GET: AdminBikes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AdminBikes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Bike bike)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bike);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var bike = _context.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }

            _context.Bikes.Remove(bike);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bike = _context.Bikes.Find(id);
            if (bike == null)
            {
                return NotFound();
            }

            return View(bike);
        }

        // POST: AdminBikes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("Id,ModelName,Brand,Price")] Bike bike)
        {
            if (id != bike.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bike);
                    _context.SaveChanges();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BikeExists(bike.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(bike);
        }
        private bool BikeExists(int id)
        {
            return _context.Bikes.Any(e => e.Id == id);
        }

    }
}
