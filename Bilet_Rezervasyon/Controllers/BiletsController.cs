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
    public class BiletsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public BiletsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Bilets
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Bilets.Include(b => b.Personel).Include(b => b.Sefer);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Bilets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets
                .Include(b => b.Personel)
                .Include(b => b.Sefer)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // GET: Bilets/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "AdSoyad");
            ViewData["PersonelId"] = new SelectList(_context.Personel, "PersonelId", "AdSoyad");
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferAdi");
            return View();
        }

        // POST: Bilets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BiletId,MusteriId,SeferId,PersonelId,BTarih,BSaati,PNR,Koltuk,BSayi,Gecer_Sure,BiletDurum")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bilet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PersonelId"] = new SelectList(_context.Personel, "PersonelId", "PersonelId", bilet.PersonelId);
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", bilet.SeferId);
            return View(bilet);
        }

        // GET: Bilets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets.FindAsync(id);
            if (bilet == null)
            {
                return NotFound();
            }
            ViewData["PersonelId"] = new SelectList(_context.Personel, "PersonelId", "PersonelId", bilet.PersonelId);
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", bilet.SeferId);
            return View(bilet);
        }

        // POST: Bilets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BiletId,MusteriId,SeferId,PersonelId,BTarih,BSaati,PNR,Koltuk,BSayi,Gecer_Sure,BiletDurum")] Bilet bilet)
        {
            if (id != bilet.BiletId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bilet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BiletExists(bilet.BiletId))
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
            ViewData["PersonelId"] = new SelectList(_context.Personel, "PersonelId", "PersonelId", bilet.PersonelId);
            ViewData["SeferId"] = new SelectList(_context.Sefers, "SeferId", "SeferId", bilet.SeferId);
            return View(bilet);
        }

        // GET: Bilets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bilet = await _context.Bilets
                .Include(b => b.Personel)
                .Include(b => b.Sefer)
                .FirstOrDefaultAsync(m => m.BiletId == id);
            if (bilet == null)
            {
                return NotFound();
            }

            return View(bilet);
        }

        // POST: Bilets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bilet = await _context.Bilets.FindAsync(id);
            if (bilet != null)
            {
                _context.Bilets.Remove(bilet);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BiletExists(int id)
        {
            return _context.Bilets.Any(e => e.BiletId == id);
        }
    }
}
