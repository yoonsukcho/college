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
    public class QnasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public QnasController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Qnas
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Qnas.Include(q => q.CustomerIDNavigation);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Qnas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qnas = await _context.Qnas.SingleOrDefaultAsync(m => m.qnaId == id);
            if (qnas == null)
            {
                return NotFound();
            }

            return View(qnas);
        }

        // GET: Qnas/Create
        public IActionResult Create()
        {
            ViewData["customerID"] = new SelectList(_context.Customers, "customerID", "customerID");
            return View();
        }

        // POST: Qnas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("qnaId,content,createDate,customerID,title,view")] Qnas qnas)
        {
            if (ModelState.IsValid)
            {
                _context.Add(qnas);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["customerID"] = new SelectList(_context.Customers, "customerID", "customerID", qnas.customerID);
            return View(qnas);
        }

        // GET: Qnas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qnas = await _context.Qnas.SingleOrDefaultAsync(m => m.qnaId == id);
            if (qnas == null)
            {
                return NotFound();
            }
            ViewData["customerID"] = new SelectList(_context.Customers, "customerID", "customerID", qnas.customerID);
            return View(qnas);
        }

        // POST: Qnas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("qnaId,content,createDate,customerID,title,view")] Qnas qnas)
        {
            if (id != qnas.qnaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(qnas);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!QnasExists(qnas.qnaId))
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
            ViewData["customerID"] = new SelectList(_context.Customers, "customerID", "customerID", qnas.customerID);
            return View(qnas);
        }

        // GET: Qnas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var qnas = await _context.Qnas.SingleOrDefaultAsync(m => m.qnaId == id);
            if (qnas == null)
            {
                return NotFound();
            }

            return View(qnas);
        }

        // POST: Qnas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var qnas = await _context.Qnas.SingleOrDefaultAsync(m => m.qnaId == id);
            _context.Qnas.Remove(qnas);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool QnasExists(int id)
        {
            return _context.Qnas.Any(e => e.qnaId == id);
        }
    }
}
