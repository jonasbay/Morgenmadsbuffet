using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Controllers
{
    public class BreakfastBookingsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BreakfastBookingsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: BreakfastBookings
        public async Task<IActionResult> Index()
        {
            return View(await _context.BreakfastBookings.ToListAsync());
        }

        // GET: BreakfastBookings/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastBookingsModel = await _context.BreakfastBookings
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (breakfastBookingsModel == null)
            {
                return NotFound();
            }

            return View(breakfastBookingsModel);
        }

        // GET: BreakfastBookings/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BreakfastBookings/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoomId,Date,AdultCount,ChildCount")] BreakfastBookingsModel breakfastBookingsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(breakfastBookingsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(breakfastBookingsModel);
        }

        // GET: BreakfastBookings/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastBookingsModel = await _context.BreakfastBookings.FindAsync(id);
            if (breakfastBookingsModel == null)
            {
                return NotFound();
            }
            return View(breakfastBookingsModel);
        }

        // POST: BreakfastBookings/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoomId,Date,AdultCount,ChildCount")] BreakfastBookingsModel breakfastBookingsModel)
        {
            if (id != breakfastBookingsModel.RoomId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(breakfastBookingsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BreakfastBookingsModelExists(breakfastBookingsModel.RoomId))
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
            return View(breakfastBookingsModel);
        }

        // GET: BreakfastBookings/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var breakfastBookingsModel = await _context.BreakfastBookings
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (breakfastBookingsModel == null)
            {
                return NotFound();
            }

            return View(breakfastBookingsModel);
        }

        // POST: BreakfastBookings/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var breakfastBookingsModel = await _context.BreakfastBookings.FindAsync(id);
            _context.BreakfastBookings.Remove(breakfastBookingsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BreakfastBookingsModelExists(int id)
        {
            return _context.BreakfastBookings.Any(e => e.RoomId == id);
        }
    }
}
