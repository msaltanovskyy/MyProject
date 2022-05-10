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
using AutoStop.ViewModels;

namespace AutoStop.Controllers
{
    public class TravelsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TravelsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Travels
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Travels
                .Include(t => t.Car).OrderBy(c => c.Car.Model)
                .Include(t => t.PointArrive).OrderBy(p => p.PointArrive.PointName)
                .Include(t => t.PointSend).OrderBy(p => p.PointSend.PointName).Where(a => a.AvailableSeats != 0);
            return View(await applicationDbContext.ToListAsync());
        }

        [HttpGet]
        public async Task<IActionResult> MyTravels()
        {
            var mytravels = await _context.Travels.Where(a => a.CreaterId == HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value)
                .Include(t => t.Car).OrderBy(c => c.Car.Model)
                .Include(t => t.PointArrive).OrderBy(p => p.PointArrive.PointName)
                .Include(t => t.PointSend).OrderBy(p => p.PointSend.PointName)
                .ToListAsync();
            return View(mytravels);
        }

        [HttpPost("Travels/MyTravelsDelete/{id}")]
        public async Task<ActionResult> MyTravelsDelete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels.FindAsync(id);
            _context.Travels.Remove(travels);
            _context.SaveChanges();
            return Json(_context.Categories.ToList());

        }


        public async Task <IActionResult> Reservation(int ?id)
        {
            ViewBag.TravelId = id;
            ViewBag.AccountId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            return View();
        }
        [HttpPost("/Travels/Reservation/{id}")]
        public async Task<IActionResult> Reservation(int id,BusyPlaces busy)
        {

            _context.BusyPlaces.Add(busy);
            //Изменить коло-во мест отнимая бронированые места от свободных
            if (busy.BusyPlace != null)
            {
                var travel = _context.Travels.Find(id);
                travel.AvailableSeats -= busy.BusyPlace;
                _context.Entry(travel).Property("AvailableSeats").IsModified = true;
                await _context.SaveChangesAsync();
            }
            else
            {
                return NotFound();
            }
            return RedirectToAction("Index");
        }

        public IActionResult ReservationList()
        {
            var list = _context.BusyPlaces
                .Include(t => t.Traverl).OrderBy(t => t.Traverl.Number)
                .ToList();
            return View(list);  
        }

        // GET: Travels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels
                .Include(t => t.Car).OrderBy(c => c.Car.Model)
                .Include(t => t.PointArrive).OrderBy(p => p.PointArrive.PointName)
                .Include(t => t.PointSend).OrderBy(p => p.PointSend.PointName)
                .FirstOrDefaultAsync(m => m.Number == id);

            List<Comments> comments = await _context.Comments.Select(c => new Comments
            {
                Id = c.Id,
                AccountsId = c.AccountsId,
                TravelsId = c.TravelsId,
                Comment = c.Comment

            }).Where(t => t.TravelsId == id).ToListAsync();

            DetailsTravelViewModel details = new DetailsTravelViewModel
            {
                travels = travels,
                comments = comments,
            };

            if (travels == null)
            {
                return NotFound();
            }

            return View(details);
        }

        // GET: Travels/Create
        public IActionResult Create()
        {
            ViewData["CarId"] = new SelectList(_context.Cars, "id", "Model");
            ViewData["CreaterId"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["PointArriveId"] = new SelectList(_context.PointArrives, "Id", "PointName");
            ViewData["PointSendId"] = new SelectList(_context.PointSends, "Id", "PointName");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Number,TimeCreate,TimeSend,TimeArrive,AvailableSeats,Cost,Status,CarId,PointSendId,PointArriveId,CreaterId")] Travels travels)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(travels);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "id", "Model", travels.CarId);
            ViewData["CreaterId"] = User.FindFirstValue(ClaimTypes.NameIdentifier);
            ViewData["PointArriveId"] = new SelectList(_context.PointArrives, "Id", "PointName", travels.PointArriveId);
            ViewData["PointSendId"] = new SelectList(_context.PointSends, "Id", "PointName", travels.PointSendId);
            return View(travels);
        }

        // GET: Travels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var travels = await _context.Travels.FindAsync(id);
            if (travels == null)
            {
                return NotFound();
            }
            ViewData["CarId"] = new SelectList(_context.Cars, "id", "Discription", travels.CarId);
            ViewData["CreaterId"] = new SelectList(_context.Accounts, "Id", "Id", travels.CreaterId);
            ViewData["PointArriveId"] = new SelectList(_context.PointArrives, "Id", "PointName", travels.PointArriveId);
            ViewData["PointSendId"] = new SelectList(_context.PointSends, "Id", "PointName", travels.PointSendId);
            return View(travels);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Number,TimeCreate,TimeSend,TimeArrive,AvailableSeats,Cost,Status,CarId,PointSendId,PointArriveId,CreaterId")] Travels travels)
        {
            if (id != travels.Number)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(travels);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TravelsExists(travels.Number))
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
            ViewData["CarId"] = new SelectList(_context.Cars, "id", "Discription", travels.CarId);
            ViewData["CreaterId"] = new SelectList(_context.Accounts, "Id", "Id", travels.CreaterId);
            ViewData["PointArriveId"] = new SelectList(_context.PointArrives, "Id", "PointName", travels.PointArriveId);
            ViewData["PointSendId"] = new SelectList(_context.PointSends, "Id", "PointName", travels.PointSendId);
            return View(travels);
        }

        // GET: Travels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var travels = await _context.Travels
                .Include(t => t.Car)
                .Include(t => t.Creater)
                .Include(t => t.PointArrive)
                .Include(t => t.PointSend)
                .FirstOrDefaultAsync(m => m.Number == id);
            if (travels == null)
            {
                return NotFound();
            }

            return View(travels);
        }

        // POST: Travels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var travels = await _context.Travels.FindAsync(id);
            _context.Travels.Remove(travels);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TravelsExists(int id)
        {
            return _context.Travels.Any(e => e.Number == id);
        }
    }
}
