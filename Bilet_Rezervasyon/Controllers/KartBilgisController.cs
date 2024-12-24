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
    public class KartBilgisController : Controller
    {
        private readonly ApplicationDbContext _context;

        public KartBilgisController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: KartBilgis
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.KartBilgi.Include(k => k.Musteri);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: KartBilgis/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartBilgi = await _context.KartBilgi
                .Include(k => k.Musteri)
                .FirstOrDefaultAsync(m => m.KartId == id);
            if (kartBilgi == null)
            {
                return NotFound();
            }

            return View(kartBilgi);
        }

        // GET: KartBilgis/Create
        public IActionResult Create()
        {
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId");
            return View();
        }

        // POST: KartBilgis/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KartId,MusteriId,KartNo,KartSahibi,SonTarih,Cvc")] KartBilgi kartBilgi)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kartBilgi);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", kartBilgi.MusteriId);
            return View(kartBilgi);
        }

        // GET: KartBilgis/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartBilgi = await _context.KartBilgi.FindAsync(id);
            if (kartBilgi == null)
            {
                return NotFound();
            }
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", kartBilgi.MusteriId);
            return View(kartBilgi);
        }

        // POST: KartBilgis/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KartId,MusteriId,KartNo,KartSahibi,SonTarih,Cvc")] KartBilgi kartBilgi)
        {
            if (id != kartBilgi.KartId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kartBilgi);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KartBilgiExists(kartBilgi.KartId))
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
            ViewData["MusteriId"] = new SelectList(_context.Musteri, "MusteriId", "MusteriId", kartBilgi.MusteriId);
            return View(kartBilgi);
        }

        // GET: KartBilgis/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var kartBilgi = await _context.KartBilgi
                .Include(k => k.Musteri)
                .FirstOrDefaultAsync(m => m.KartId == id);
            if (kartBilgi == null)
            {
                return NotFound();
            }

            return View(kartBilgi);
        }

        // POST: KartBilgis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var kartBilgi = await _context.KartBilgi.FindAsync(id);
            if (kartBilgi != null)
            {
                _context.KartBilgi.Remove(kartBilgi);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KartBilgiExists(int id)
        {
            return _context.KartBilgi.Any(e => e.KartId == id);
        }
    }
}
