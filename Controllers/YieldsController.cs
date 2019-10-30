using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microgreens.Data;
using Microgreens.Models;

namespace Microgreens.Controllers
{
    public class YieldsController : Controller
    {
        private readonly ProductsDbContext _context;

        public YieldsController(ProductsDbContext context)
        {
            _context = context;
        }

        // GET: Yields
        public async Task<IActionResult> Index()
        {
            var productsDbContext = _context.Yields.Include(y => y.Product);
            return View(await productsDbContext.ToListAsync());
        }

        // GET: Yields/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yields = await _context.Yields
                .Include(y => y.Product)
                .FirstOrDefaultAsync(m => m.YieldId == id);
            if (yields == null)
            {
                return NotFound();
            }

            return View(yields);
        }

        // GET: Yields/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Yields/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("YieldId,Yield,ProductsId")] Yields yields)
        {
            if (ModelState.IsValid)
            {
                _context.Add(yields);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", yields.ProductsId);
            return View(yields);
        }

        // GET: Yields/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yields = await _context.Yields.FindAsync(id);
            if (yields == null)
            {
                return NotFound();
            }
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", yields.ProductsId);
            return View(yields);
        }

        // POST: Yields/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("YieldId,Yield,ProductsId")] Yields yields)
        {
            if (id != yields.YieldId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(yields);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!YieldsExists(yields.YieldId))
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
            ViewData["ProductsId"] = new SelectList(_context.Products, "Id", "Id", yields.ProductsId);
            return View(yields);
        }

        // GET: Yields/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var yields = await _context.Yields
                .Include(y => y.Product)
                .FirstOrDefaultAsync(m => m.YieldId == id);
            if (yields == null)
            {
                return NotFound();
            }

            return View(yields);
        }

        // POST: Yields/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var yields = await _context.Yields.FindAsync(id);
            _context.Yields.Remove(yields);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool YieldsExists(int id)
        {
            return _context.Yields.Any(e => e.YieldId == id);
        }
    }
}
