using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Morgenmadsbuffet.Data;
using Morgenmadsbuffet.Models;

namespace Morgenmadsbuffet.Controllers
{
    public class KitchenController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KitchenController(ApplicationDbContext context)
        {
            _context = context; //Dependency injection
        }

        // GET: Kitchen
        public async Task<IActionResult> Index(string date)
        {
            var qBreakfast = await _context.BreakfastBookings.Where(b => b.Date == date).ToListAsync();

            return View(qBreakfast);
        }
    }
}