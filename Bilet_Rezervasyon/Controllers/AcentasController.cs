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
    public class AcentasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AcentasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Acentas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Acenta.ToListAsync());
        }

        // GET: Acentas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acenta = await _context.Acenta
                .FirstOrDefaultAsync(m => m.AcentaId == id);
            if (acenta == null)
            {
                return NotFound();
            }

            return View(acenta);
        }

        // GET: Acentas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Acentas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AcentaId,AcentaAd,Telefon,Adres,Mail,Kurulus_Tarihi")] Acenta acenta)
        {
            if (ModelState.IsValid)
            {
                _context.Add(acenta);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(acenta);
        }

        // GET: Acentas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acenta = await _context.Acenta.FindAsync(id);
            if (acenta == null)
            {
                return NotFound();
            }
            return View(acenta);
        }

        // POST: Acentas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("AcentaId,AcentaAd,Telefon,Adres,Mail,Kurulus_Tarihi")] Acenta acenta)
        {
            if (id != acenta.AcentaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(acenta);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AcentaExists(acenta.AcentaId))
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
            return View(acenta);
        }

        // GET: Acentas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var acenta = await _context.Acenta
                .FirstOrDefaultAsync(m => m.AcentaId == id);
            if (acenta == null)
            {
                return NotFound();
            }

            return View(acenta);
        }

        // POST: Acentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var acenta = await _context.Acenta.FindAsync(id);
            if (acenta != null)
            {
                _context.Acenta.Remove(acenta);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AcentaExists(int id)
        {
            return _context.Acenta.Any(e => e.AcentaId == id);
        }
    }
}
