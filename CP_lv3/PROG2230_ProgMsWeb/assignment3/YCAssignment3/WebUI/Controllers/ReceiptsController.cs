using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;

namespace WebUI.Controllers
{
    public class ReceiptsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReceiptsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Receipts
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Receipts.Include(r => r.OrderIDNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Receipts/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipts = await _context.Receipts.SingleOrDefaultAsync(m => m.receiptID == id);
            if (receipts == null)
            {
                return NotFound();
            }

            return View(receipts);
        }

        // GET: Receipts/Create
        public IActionResult Create()
        {
            ViewData["orderID"] = new SelectList(_context.Orders, "orderID", "orderID");
            return View();
        }

        // POST: Receipts/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("receiptID,orderID,paymentDate,paymentMethod")] Receipts receipts)
        {
            if (ModelState.IsValid)
            {
                _context.Add(receipts);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["orderID"] = new SelectList(_context.Orders, "orderID", "orderID", receipts.orderID);
            return View(receipts);
        }

        // GET: Receipts/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipts = await _context.Receipts.SingleOrDefaultAsync(m => m.receiptID == id);
            if (receipts == null)
            {
                return NotFound();
            }
            ViewData["orderID"] = new SelectList(_context.Orders, "orderID", "orderID", receipts.orderID);
            return View(receipts);
        }

        // POST: Receipts/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("receiptID,orderID,paymentDate,paymentMethod")] Receipts receipts)
        {
            if (id != receipts.receiptID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(receipts);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReceiptsExists(receipts.receiptID))
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
            ViewData["orderID"] = new SelectList(_context.Orders, "orderID", "orderID", receipts.orderID);
            return View(receipts);
        }

        // GET: Receipts/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var receipts = await _context.Receipts.SingleOrDefaultAsync(m => m.receiptID == id);
            if (receipts == null)
            {
                return NotFound();
            }

            return View(receipts);
        }

        // POST: Receipts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var receipts = await _context.Receipts.SingleOrDefaultAsync(m => m.receiptID == id);
            _context.Receipts.Remove(receipts);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ReceiptsExists(int id)
        {
            return _context.Receipts.Any(e => e.receiptID == id);
        }
    }
}
