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
    public class SefersController : Controller
    {
        private readonly ApplicationDbContext _context;

        public SefersController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Sefers
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Sefers.Include(s => s.Acenta);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Sefers/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers
                .Include(s => s.Acenta)
                .FirstOrDefaultAsync(m => m.SeferId == id);
            if (sefer == null)
            {
                return NotFound();
            }

            return View(sefer);
        }

        // GET: Sefers/Create
        public IActionResult Create()
        {
            ViewData["AcentaId"] = new SelectList(_context.Acenta, "AcentaId", "AcentaId");
            return View();
        }

        // POST: Sefers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SeferId,AcentaId,SeferAdi,SeferKodu,Gidis,Donus,Ucreti,Saati")] Sefer sefer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sefer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["AcentaId"] = new SelectList(_context.Acenta, "AcentaId", "AcentaId", sefer.AcentaId);
            return View(sefer);
        }

        // GET: Sefers/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers.FindAsync(id);
            if (sefer == null)
            {
                return NotFound();
            }
            ViewData["AcentaId"] = new SelectList(_context.Acenta, "AcentaId", "AcentaId", sefer.AcentaId);
            return View(sefer);
        }

        // POST: Sefers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SeferId,AcentaId,SeferAdi,SeferKodu,Gidis,Donus,Ucreti,Saati")] Sefer sefer)
        {
            if (id != sefer.SeferId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sefer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SeferExists(sefer.SeferId))
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
            ViewData["AcentaId"] = new SelectList(_context.Acenta, "AcentaId", "AcentaId", sefer.AcentaId);
            return View(sefer);
        }

        // GET: Sefers/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sefer = await _context.Sefers
                .Include(s => s.Acenta)
                .FirstOrDefaultAsync(m => m.SeferId == id);
            if (sefer == null)
            {
                return NotFound();
            }

            return View(sefer);
        }

        // POST: Sefers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sefer = await _context.Sefers.FindAsync(id);
            if (sefer != null)
            {
                _context.Sefers.Remove(sefer);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SeferExists(int id)
        {
            return _context.Sefers.Any(e => e.SeferId == id);
        }
    }
}
