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
    public class BranchsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BranchsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Branchs
        public async Task<IActionResult> Index()
        {
            return View(await _context.Branchs.ToListAsync());
        }

        // GET: Branchs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchs = await _context.Branchs.SingleOrDefaultAsync(m => m.branchID == id);
            if (branchs == null)
            {
                return NotFound();
            }

            return View(branchs);
        }

        // GET: Branchs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Branchs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("branchID,branchName,custAddress,custCity,custPhone,custState,custZip")] Branchs branchs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(branchs);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(branchs);
        }

        // GET: Branchs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchs = await _context.Branchs.SingleOrDefaultAsync(m => m.branchID == id);
            if (branchs == null)
            {
                return NotFound();
            }
            return View(branchs);
        }

        // POST: Branchs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("branchID,branchName,custAddress,custCity,custPhone,custState,custZip")] Branchs branchs)
        {
            if (id != branchs.branchID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(branchs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BranchsExists(branchs.branchID))
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
            return View(branchs);
        }

        // GET: Branchs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var branchs = await _context.Branchs.SingleOrDefaultAsync(m => m.branchID == id);
            if (branchs == null)
            {
                return NotFound();
            }

            return View(branchs);
        }

        // POST: Branchs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var branchs = await _context.Branchs.SingleOrDefaultAsync(m => m.branchID == id);
            _context.Branchs.Remove(branchs);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool BranchsExists(int id)
        {
            return _context.Branchs.Any(e => e.branchID == id);
        }
    }
}
