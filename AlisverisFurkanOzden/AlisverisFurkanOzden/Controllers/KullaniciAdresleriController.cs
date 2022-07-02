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
    public class KullaniciAdresleriController : Controller
    {
        private readonly AlisverisFurkanOzdenDbContext _context;

        public KullaniciAdresleriController(AlisverisFurkanOzdenDbContext context)
        {
            _context = context;
        }

        // GET: KullaniciAdresleri
        public async Task<IActionResult> Index()
        {
            var alisverisFurkanOzdenDbContext = _context.KullaniciAdresleri.Include(k => k.Kullanici);
            return View(await alisverisFurkanOzdenDbContext.ToListAsync());
        }

        // GET: KullaniciAdresleri/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KullaniciAdresleri == null)
            {
                return NotFound();
            }

            var kullaniciAdresleri = await _context.KullaniciAdresleri
                .Include(k => k.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciAdresleri == null)
            {
                return NotFound();
            }

            return View(kullaniciAdresleri);
        }

        // GET: KullaniciAdresleri/Create
        public IActionResult Create()
        {
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi");
            return View();
        }

        // POST: KullaniciAdresleri/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdresBasligi,AdresAciklama,KullaniciId")] KullaniciAdresleri kullaniciAdresleri)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullaniciAdresleri);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", kullaniciAdresleri.KullaniciId);
            return View(kullaniciAdresleri);
        }

        // GET: KullaniciAdresleri/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KullaniciAdresleri == null)
            {
                return NotFound();
            }

            var kullaniciAdresleri = await _context.KullaniciAdresleri.FindAsync(id);
            if (kullaniciAdresleri == null)
            {
                return NotFound();
            }
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", kullaniciAdresleri.KullaniciId);
            return View(kullaniciAdresleri);
        }

        // POST: KullaniciAdresleri/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdresBasligi,AdresAciklama,KullaniciId")] KullaniciAdresleri kullaniciAdresleri)
        {
            if (id != kullaniciAdresleri.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullaniciAdresleri);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullaniciAdresleriExists(kullaniciAdresleri.Id))
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
            ViewData["KullaniciId"] = new SelectList(_context.Kullanicilar, "Id", "AdiSoyadi", kullaniciAdresleri.KullaniciId);
            return View(kullaniciAdresleri);
        }

        // GET: KullaniciAdresleri/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KullaniciAdresleri == null)
            {
                return NotFound();
            }

            var kullaniciAdresleri = await _context.KullaniciAdresleri
                .Include(k => k.Kullanici)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullaniciAdresleri == null)
            {
                return NotFound();
            }

            return View(kullaniciAdresleri);
        }

        // POST: KullaniciAdresleri/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KullaniciAdresleri == null)
            {
                return Problem("Entity set 'AlisverisFurkanOzdenDbContext.KullaniciAdresleri'  is null.");
            }
            var kullaniciAdresleri = await _context.KullaniciAdresleri.FindAsync(id);
            if (kullaniciAdresleri != null)
            {
                _context.KullaniciAdresleri.Remove(kullaniciAdresleri);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullaniciAdresleriExists(int id)
        {
          return (_context.KullaniciAdresleri?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
