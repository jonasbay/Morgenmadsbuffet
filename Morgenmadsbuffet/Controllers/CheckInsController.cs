using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Controllers
{
    public class CheckInsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CheckInsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: CheckIns
        [Authorize("IsRestaurant")]
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.CheckIns.Include(c => c.BreakfastBookingsModels);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: CheckIns/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInsModel = await _context.CheckIns
                .Include(c => c.BreakfastBookingsModels)
                .FirstOrDefaultAsync(m => m.CheckInsModelId == id);
            if (checkInsModel == null)
            {
                return NotFound();
            }

            return View(checkInsModel);
        }

        // GET: CheckIns/Create
        public IActionResult Create()
        {
            ViewData["RoomId"] = new SelectList(_context.BreakfastBookings, "RoomId", "RoomId");
            ViewData["Date"] = new SelectList(_context.BreakfastBookings, "Date", "Date");
            return View();
        }

        // POST: CheckIns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CheckInsModelId,RoomId,Date,AdultCount,ChildCount")] CheckInsModel checkInsModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(checkInsModel);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["RoomId"] = new SelectList(_context.BreakfastBookings, "RoomId", checkInsModel.RoomId.ToString());
            ViewData["Date"] = new SelectList(_context.BreakfastBookings, "Date", checkInsModel.Date);
            return View(checkInsModel);
        }

        // GET: CheckIns/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInsModel = await _context.CheckIns.FindAsync(id);
            if (checkInsModel == null)
            {
                return NotFound();
            }
            ViewData["RoomId"] = new SelectList(_context.BreakfastBookings, "RoomId", "Date", checkInsModel.RoomId);
            return View(checkInsModel);
        }

        // POST: CheckIns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CheckInsModelId,RoomId,Date,AdultCount,ChildCount")] CheckInsModel checkInsModel)
        {
            if (id != checkInsModel.CheckInsModelId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(checkInsModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CheckInsModelExists(checkInsModel.CheckInsModelId))
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
            ViewData["RoomId"] = new SelectList(_context.BreakfastBookings, "RoomId", "Date", checkInsModel.RoomId);
            return View(checkInsModel);
        }

        // GET: CheckIns/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var checkInsModel = await _context.CheckIns
                .Include(c => c.BreakfastBookingsModels)
                .FirstOrDefaultAsync(m => m.CheckInsModelId == id);
            if (checkInsModel == null)
            {
                return NotFound();
            }

            return View(checkInsModel);
        }

        // POST: CheckIns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var checkInsModel = await _context.CheckIns.FindAsync(id);
            _context.CheckIns.Remove(checkInsModel);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CheckInsModelExists(int id)
        {
            return _context.CheckIns.Any(e => e.CheckInsModelId == id);
        }
    }
}
