using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microgreens.Data;
using Microgreens.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Microgreens.Controllers
{
    public class SowRatesLController : Controller
    {
        private readonly ProductsDbContext _context;

        public SowRatesLController(ProductsDbContext context)
        {
            _context = context;
        }

        // GET: Visitors
        public async Task<IActionResult> Index()
        {

            var SowRatesL = await _context.SowRatesL.ToListAsync();

            return View(SowRatesL);
        }

        // GET: Visitors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var SowRatesL = await _context.SowRatesL
                .FirstOrDefaultAsync(m => m.SowRatesId == id);
            if (SowRatesL == null)
            {
                return NotFound();
            }

            return View(SowRatesL);
        }

        // GET: Visitors/Create
        public IActionResult Create()
        {
            ViewData["ProductId"] = new SelectList(_context.Products, "Id", "Id");
            return View();
        }

        // POST: Visitors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SowRatesId,SowWeight,TraysPerPack,CostPerTray, ProductsId,DateIn,DateOut")] SowRatesL sowRatesL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sowRatesL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sowRatesL);
        }

        // GET: Visitors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sowRatesL = await _context.SowRatesL.FindAsync(id);
            if (sowRatesL == null)
            {
                return NotFound();
            }
            return View(sowRatesL);
        }

        // POST: Visitors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Business,DateIn,DateOut")] Visitors SowRatesL)
        {
            if (id != SowRatesL.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(SowRatesL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SowRatesLExists(SowRatesL.Id))
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
            return View(SowRatesL);
        }

        // GET: Visitors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var visitors = await _context.SowRatesL
                .FirstOrDefaultAsync(m => m.SowRatesId == id);
            if (visitors == null)
            {
                return NotFound();
            }

            return View(visitors);
        }

        // POST: Visitors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var visitors = await _context.SowRatesL.FindAsync(id);
            _context.SowRatesL.Remove(visitors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SowRatesLExists(int id)
        {
            return _context.SowRatesL.Any(e => e.SowRatesId == id);
        }
    }
}
