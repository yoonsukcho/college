using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebUI.Data;
using WebUI.Models;
using Microsoft.AspNetCore.Http;

namespace WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: Products
        public async Task<IActionResult> Index()
        {
            return View(await _context.Products.ToListAsync());
        }

        // GET: Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.SingleOrDefaultAsync(m => m.productID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // GET: Products/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("productID,productImage,productName,productPrice")] Products products)
        {
            if (ModelState.IsValid)
            {
                _context.Add(products);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(products);
        }

        // GET: Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.SingleOrDefaultAsync(m => m.productID == id);
            if (products == null)
            {
                return NotFound();
            }
            return View(products);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("productID,productImage,productName,productPrice")] Products products)
        {
            if (id != products.productID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(products);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductsExists(products.productID))
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
            return View(products);
        }

        // GET: Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var products = await _context.Products.SingleOrDefaultAsync(m => m.productID == id);
            if (products == null)
            {
                return NotFound();
            }

            return View(products);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var products = await _context.Products.SingleOrDefaultAsync(m => m.productID == id);
            _context.Products.Remove(products);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ProductsExists(int id)
        {
            return _context.Products.Any(e => e.productID == id);
        }

        public async Task<IActionResult> AddBasket(int id)
        {
            HttpContext.Session.SetString("Basket" + DateTime.Now.ToString(), id.ToString());
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ViewBasket()
        {
            var baskets = new List<Basket>();
            foreach(string key in HttpContext.Session.Keys)
            {
                if (key.StartsWith("Basket"))
                {
                    Basket bk = new Basket();
                    string itemID = HttpContext.Session.GetString(key);
                    bk.productID = Int32.Parse(itemID);
                    if (HttpContext.Session.GetString("CustomerID") == null)
                        bk.customerID = 0;
                    else
                        bk.customerID = Int32.Parse(HttpContext.Session.GetString("CustomerID"));
                    baskets.Add(bk);
                }
            }
            return View(baskets);
        }


        public async Task<IActionResult> DeleteBasket(int id)
        {
            var baskets = new List<Basket>();
            foreach (string key in HttpContext.Session.Keys)
            {
                if (key.StartsWith("Basket"))
                {
                    string itemID = HttpContext.Session.GetString(key);
                    if (id == Int32.Parse(itemID))
                    {
                        HttpContext.Session.Remove(key);
                        break;
                    }
                }
            }
            foreach (string key in HttpContext.Session.Keys)
            {
                if (key.StartsWith("Basket"))
                {
                    string itemID = HttpContext.Session.GetString(key);
                    Basket bk = new Basket();
                    bk.productID = Int32.Parse(itemID);
                    baskets.Add(bk);
                }
            }
            return View("ViewBasket", baskets);
        }

    }
}
