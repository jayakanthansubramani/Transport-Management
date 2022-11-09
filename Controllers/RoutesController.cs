using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportManagement.Models;
using Route = TransportManagement.Models.Route;

namespace TransportManagement.Controllers
{
    public class RoutesController : Controller
    {
        private readonly TransportManagementContext _context;

        public RoutesController(TransportManagementContext context)
        {
            _context = context;
        }

        // GET: Routes
        public async Task<IActionResult> Index()
        {
            var transportManagementContext = _context.Routes.Include(r => r.VehicleNoNavigation);
            return View(await transportManagementContext.ToListAsync());
        }

        // GET: Routes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.VehicleNoNavigation)
                .FirstOrDefaultAsync(m => m.RoutetId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // GET: Routes/Create
        public IActionResult Create()
        {
            ViewData["VehicleNo"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId");
            return View();
        }

        // POST: Routes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RoutetId,RouteNo,Stop1,Stop2,VehicleNo")] Route route)
        {
            //if (ModelState.IsValid)
            //{
            //    _context.Add(route);
            //    await _context.SaveChangesAsync();
            //    return RedirectToAction(nameof(Index));
            //}
            _context.Add(route);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            ViewData["VehicleNo"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", route.VehicleNo);
            return View(route);
        }

        // GET: Routes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var route = await _context.Routes.FindAsync(id);
            if (route == null)
            {
                return NotFound();
            }
            ViewData["VehicleNo"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", route.VehicleNo);
            return View(route);
        }

        // POST: Routes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RoutetId,RouteNo,Stop1,Stop2,VehicleNo")] Route route)
        {
            if (id != route.RoutetId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(route);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RouteExists(route.RoutetId))
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
            ViewData["VehicleNo"] = new SelectList(_context.Vehicles, "VehicleId", "VehicleId", route.VehicleNo);
            return View(route);
        }

        // GET: Routes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Routes == null)
            {
                return NotFound();
            }

            var route = await _context.Routes
                .Include(r => r.VehicleNoNavigation)
                .FirstOrDefaultAsync(m => m.RoutetId == id);
            if (route == null)
            {
                return NotFound();
            }

            return View(route);
        }

        // POST: Routes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Routes == null)
            {
                return Problem("Entity set 'TransportManagementContext.Routes'  is null.");
            }
            var route = await _context.Routes.FindAsync(id);
            if (route != null)
            {
                _context.Routes.Remove(route);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RouteExists(int id)
        {
          return _context.Routes.Any(e => e.RoutetId == id);
        }
    }
}
