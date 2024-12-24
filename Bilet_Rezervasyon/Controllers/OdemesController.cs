using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Bilet_Rezervasyon.Context;
using Bilet_Rezervasyon.Models;

namespace Bilet_Rezervasyon.Controllers
{
    public class OdemesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public OdemesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Odemes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Odeme.Include(o => o.Bilet).Include(o => o.Musteri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Odemes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odeme
                .Include(o => o.Bilet)
                .Include(o => o.Musteri)
                .FirstOrDefaultAsync(m => m.OdemeId == id);
            if (odeme == null)
            {
                return NotFound();
            }

            return View(odeme);
        }

        // GET: Odemes/Create
        public IActionResult Create()
        {
            ViewData["BiletId"] = new SelectList(_context.Bilets, "BiletId", "BiletId");
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId");
            return View();
        }

        // POST: Odemes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("OdemeId,MusteriId,BiletId")] Odeme odeme)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odeme);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BiletId"] = new SelectList(_context.Bilets, "BiletId", "BiletId", odeme.BiletId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", odeme.MusteriId);
            return View(odeme);
        }

        // GET: Odemes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odeme.FindAsync(id);
            if (odeme == null)
            {
                return NotFound();
            }
            ViewData["BiletId"] = new SelectList(_context.Bilets, "BiletId", "BiletId", odeme.BiletId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", odeme.MusteriId);
            return View(odeme);
        }

        // POST: Odemes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int? id, [Bind("OdemeId,MusteriId,BiletId")] Odeme odeme)
        {
            if (id != odeme.OdemeId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odeme);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdemeExists(odeme.OdemeId))
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
            ViewData["BiletId"] = new SelectList(_context.Bilets, "BiletId", "BiletId", odeme.BiletId);
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", odeme.MusteriId);
            return View(odeme);
        }

        // GET: Odemes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odeme = await _context.Odeme
                .Include(o => o.Bilet)
                .Include(o => o.Musteri)
                .FirstOrDefaultAsync(m => m.OdemeId == id);
            if (odeme == null)
            {
                return NotFound();
            }

            return View(odeme);
        }

        // POST: Odemes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int? id)
        {
            var odeme = await _context.Odeme.FindAsync(id);
            if (odeme != null)
            {
                _context.Odeme.Remove(odeme);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OdemeExists(int? id)
        {
            return _context.Odeme.Any(e => e.OdemeId == id);
        }
    }
}
