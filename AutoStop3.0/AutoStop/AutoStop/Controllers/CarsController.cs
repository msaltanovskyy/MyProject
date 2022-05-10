#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AutoStop.Data;
using AutoStop.Models;
using System.Security.Claims;

namespace AutoStop.Controllers
{
    public class CarsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CarsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Cars;
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> MyCar()
        {
            var mycar = await _context.Cars.Where(a => a.DriverId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value).ToListAsync();
            return View(mycar);
        }

        // GET: Cars/Details/5
        [HttpGet("Cars/Details/{id}")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FirstOrDefaultAsync(m => m.id == id); 
                //.Include(c => c.Drivers)
                //.FirstOrDefaultAsync(m => m.id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // GET: Cars/Create
        public IActionResult Create()
        {
            ViewBag.DriverId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }

        // POST: Cars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("id,NumberCar,Model,Discription,Chair,DriverId","Driver")] Cars cars)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(cars);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DriverId"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View(cars);
        }

        // GET: Cars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars.FindAsync(id);
            if (cars == null)
            {
                return NotFound();
            }
            ViewData["DriverId"] = new SelectList(_context.Accounts, "Id", "Id", cars.DriverId);
            return View(cars);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("id,NumberCar,Model,Discription,Chair,DriverId,FavoriteLisetId")] Cars cars)
        {
            if (id != cars.id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cars);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CarsExists(cars.id))
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
            ViewData["DriverId"] = new SelectList(_context.Accounts, "Id", "Id", cars.DriverId);
            return View(cars);
        }

        // GET: Cars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cars = await _context.Cars
                .Include(c => c.Drivers)
                .FirstOrDefaultAsync(m => m.id == id);
            if (cars == null)
            {
                return NotFound();
            }

            return View(cars);
        }

        // POST: Cars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cars = await _context.Cars.FindAsync(id);
            _context.Cars.Remove(cars);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CarsExists(int id)
        {
            return _context.Cars.Any(e => e.id == id);
        }

        [HttpGet("Cars/CategoryAdd/{CarsId}")]
        public IActionResult CategoryAdd(int CarsId)
        {
            ViewBag.CarId = CarsId;
            var categories = _context.Categories.ToList();
            ViewBag.Category = new SelectList(categories, "Id", "Name");
            return View();
        }
        
        [HttpPost("Cars/CategoryAdd/{CarsId}")]
        public IActionResult CategoryAdd(int CarsId, CarCategories categories)
        {
            _context.Cars.Find(CarsId);
            _context.CarCategories.Add(categories);
            _context.SaveChanges();

            return View();
        }
    }
}
