using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AlisverisFurkanOzden.Entities;
using AlisverisFurkanOzden.Models;

namespace AlisverisFurkanOzden.Controllers
{
    public class SiparislerController : Controller
    {
        private readonly AlisverisFurkanOzdenDbContext _context;

        public SiparislerController(AlisverisFurkanOzdenDbContext context)
        {
            _context = context;
        }

        // GET: Siparisler
        public async Task<IActionResult> Index()
        {
            var alisverisFurkanOzdenDbContext = _context.Siparisler.Include(s => s.Kullanici).Include(s => s.Urun).Include(s=>s.Kullanici.KullaniciAdresleri);
            return View(await alisverisFurkanOzdenDbContext.ToListAsync());
        }

        // GET: Siparisler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler
                .Include(s => s.Kullanici)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // GET: Siparisler/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi");
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi");
            return View();
        }

        // POST: Siparisler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KullaniciId,UrunId,SiparisTarihi")] Siparisler siparisler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(siparisler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", siparisler.KullaniciId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", siparisler.UrunId);
            return View(siparisler);
        }

        // GET: Siparisler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler.FindAsync(id);
            if (siparisler == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", siparisler.KullaniciId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", siparisler.UrunId);
            return View(siparisler);
        }

        // POST: Siparisler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KullaniciId,UrunId,SiparisTarihi")] Siparisler siparisler)
        {
            if (id != siparisler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(siparisler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SiparislerExists(siparisler.Id))
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
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", siparisler.KullaniciId);
            ViewData["UrunId"] = new SelectList(_context.Urunler, "Id", "UrunAdi", siparisler.UrunId);
            return View(siparisler);
        }

        // GET: Siparisler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Siparisler == null)
            {
                return NotFound();
            }

            var siparisler = await _context.Siparisler
                .Include(s => s.Kullanici)
                .Include(s => s.Urun)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (siparisler == null)
            {
                return NotFound();
            }

            return View(siparisler);
        }

        // POST: Siparisler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Siparisler == null)
            {
                return Problem("Entity set 'AlisverisFurkanOzdenDbContext.Siparisler'  is null.");
            }
            var siparisler = await _context.Siparisler.FindAsync(id);
            if (siparisler != null)
            {
                _context.Siparisler.Remove(siparisler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SiparislerExists(int id)
        {
          return (_context.Siparisler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
