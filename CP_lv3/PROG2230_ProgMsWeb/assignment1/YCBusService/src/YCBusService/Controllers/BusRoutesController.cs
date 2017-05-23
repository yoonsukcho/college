using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using YCBusService.Models;

namespace YCBusService.Controllers
{
    public class BusRoutesController : Controller
    {
        private readonly YCBusServiceContext _context;
		
		/// <summary>
        /// Constructor of BusRoutesController class
        /// </summary>
        public BusRoutesController(YCBusServiceContext context)
        {
            _context = context;    
        }
		
		/// <summary>
        /// Select the list of BusRoute table
        /// </summary>
        // GET: BusRoutes
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusRoute.ToListAsync());
        }
		
		/// <summary>
        /// Select a record which is given PK
        /// </summary>
        // GET: BusRoutes/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.BusRouteCode == id);
            if (busRoute == null)
            {
                return NotFound();
            }

            return View(busRoute);
        }
		
		/// <summary>
        /// Return a BusRoute Model with empty data  
        /// </summary>
        // GET: BusRoutes/Create
        public IActionResult Create()
        {
            return View();
        }
		
		/// <summary>
        /// Insert an input record to the database which is using in the context class
        /// </summary>
        // POST: BusRoutes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusRouteCode,RouteName")] BusRoute busRoute)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busRoute);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(busRoute);
        }
		
		/// <summary>
        /// Check if the input record is existing before update
        /// </summary>
        // GET: BusRoutes/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.BusRouteCode == id);
            if (busRoute == null)
            {
                return NotFound();
            }
            return View(busRoute);
        }
		
		/// <summary>
        /// Update the record using given PK and BusRoute information
        /// </summary>
        // POST: BusRoutes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("BusRouteCode,RouteName")] BusRoute busRoute)
        {
            if (id != busRoute.BusRouteCode)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busRoute);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusRouteExists(busRoute.BusRouteCode))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(busRoute);
        }
		
		/// <summary>
        /// Check if the input record is existing before delete
        /// </summary>
        // GET: BusRoutes/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.BusRouteCode == id);
            if (busRoute == null)
            {
                return NotFound();
            }

            return View(busRoute);
        }

		/// <summary>
        /// Delete a record using an input PK
        /// </summary>
        // POST: BusRoutes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var busRoute = await _context.BusRoute.SingleOrDefaultAsync(m => m.BusRouteCode == id);
            _context.BusRoute.Remove(busRoute);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
		
		/// <summary>
        /// Check the existence of the selected record
        /// </summary>
        private bool BusRouteExists(string id)
        {
            return _context.BusRoute.Any(e => e.BusRouteCode == id);
        }
    }
}
