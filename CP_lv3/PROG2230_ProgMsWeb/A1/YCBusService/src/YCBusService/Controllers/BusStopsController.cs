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
    public class BusStopsController : Controller
    {
        private readonly YCBusServiceContext _context;

		/// <summary>
        /// Constructor of BusStopsController class
        /// </summary>
        public BusStopsController(YCBusServiceContext context)
        {
            _context = context;    
        }

		/// <summary>
        /// Select the list of BusStop Table
        /// </summary>
        // GET: BusStops
        public async Task<IActionResult> Index()
        {
            return View(await _context.BusStop.ToListAsync());
        }

		/// <summary>
        /// Select a record which is given PK
        /// </summary>
        // GET: BusStops/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busStop = await _context.BusStop.SingleOrDefaultAsync(m => m.BusStopNumber == id);
            if (busStop == null)
            {
                return NotFound();
            }

            return View(busStop);
        }

		/// <summary>
        /// Return a BusStop Model with empty data 
        /// </summary>
        // GET: BusStops/Create
        public IActionResult Create()
        {
            return View();
        }

		/// <summary>
        /// Insert an input record to the database which is using in the context class
        /// </summary>
        // POST: BusStops/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusStopNumber,GoingDowntown,Location,LocationHash")] BusStop busStop)
        {
            if (ModelState.IsValid)
            {
                _context.Add(busStop);

                busStop.LocationHash = GetHashFromLocation(busStop.Location);

                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(busStop);
        }

		/// <summary>
        /// Check if the input record is existing before update
        /// </summary>
        // GET: BusStops/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busStop = await _context.BusStop.SingleOrDefaultAsync(m => m.BusStopNumber == id);

            busStop.LocationHash = GetHashFromLocation(busStop.Location);

            if (busStop == null)
            {
                return NotFound();
            }
            return View(busStop);
        }

		/// <summary>
        /// Update the record using given PK and BusStop information
        /// </summary>
        // POST: BusStops/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BusStopNumber,GoingDowntown,Location,LocationHash")] BusStop busStop)
        {
            if (id != busStop.BusStopNumber)
            {
                return NotFound();
            }

            busStop.LocationHash = GetHashFromLocation(busStop.Location);

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(busStop);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BusStopExists(busStop.BusStopNumber))
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
            return View(busStop);
        }

		/// <summary>
        /// Check if the input record is existing before delete
        /// </summary>
        // GET: BusStops/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var busStop = await _context.BusStop.SingleOrDefaultAsync(m => m.BusStopNumber == id);
            if (busStop == null)
            {
                return NotFound();
            }

            return View(busStop);
        }

		/// <summary>
        /// Delete a record using an input PK
        /// </summary>
        // POST: BusStops/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var busStop = await _context.BusStop.SingleOrDefaultAsync(m => m.BusStopNumber == id);
            _context.BusStop.Remove(busStop);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

		/// <summary>
        /// Check the existence of the selected record
        /// </summary>
        private bool BusStopExists(int id)
        {
            return _context.BusStop.Any(e => e.BusStopNumber == id);
        }

		/// <summary>
        /// Get the location hash code using the byte values of location string
        /// </summary>
        private Int32 GetHashFromLocation(string locationString)
        {
            Int32 returnValue = 0;
            byte[] byteArray = System.Text.Encoding.UTF8.GetBytes(locationString);
            foreach (byte byteValue in byteArray)
            {
                returnValue += byteValue;
            }
            return returnValue;
        }
    }
}
