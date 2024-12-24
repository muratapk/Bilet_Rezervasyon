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
    public class GisesController : Controller
    {
        private readonly ApplicationDbContext _context;
        //veritabanı için yeni bir nesne oluştur _context
        public GisesController(ApplicationDbContext context)
        {
            _context = context;
            //veritabanından gelen applicationDbcontex özelliklerini context onuda var olan
            //_context yapısına atıyor
        }

        // GET: Gises
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gises.ToListAsync());
            //burada database kayıtlı Gise isimli tablodan tüm verilerini çekmek için
            //ToListAsync();  Index isimli view nesne gönderiyorum
        }

        // GET: Gises/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gise = await _context.Gises
                .FirstOrDefaultAsync(m => m.GiseId == id);
            if (gise == null)
            {
                return NotFound();
            }

            return View(gise);
        }

        // GET: Gises/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Gises/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        //httpost 
        public async Task<IActionResult> Create([Bind("GiseId,GiseAd")] Gise gise)
        {
            if (ModelState.IsValid)
            {
                _context.Add(gise);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(gise);
        }

        // GET: Gises/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
                //return notFound();
            }

            var gise = await _context.Gises.FindAsync(id);
            //veritabanı içindeki id numarası 1-3-5 hangi o satırı bul
            if (gise == null)
            {
                return NotFound();
            }
            return View(gise);
        }

        // POST: Gises/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("GiseId,GiseAd")] Gise gise)
        {
            if (id != gise.GiseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(gise);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiseExists(gise.GiseId))
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
            return View(gise);
        }

        // GET: Gises/Delete/5
        //get methodu linkle gelen veri al
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gise = await _context.Gises
                .FirstOrDefaultAsync(m => m.GiseId == id);
            if (gise == null)
            {
                return NotFound();
            }

            return View(gise);
        }

        // POST: Gises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gise = await _context.Gises.FindAsync(id);
            if (gise != null)
            {
                _context.Gises.Remove(gise);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiseExists(int id)
        {
            return _context.Gises.Any(e => e.GiseId == id);
        }
    }
}
