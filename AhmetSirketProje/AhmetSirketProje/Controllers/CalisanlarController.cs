using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AhmetSirketProje.Entities;
using AhmetSirketProje.Models;

namespace AhmetSirketProje.Controllers
{
    public class CalisanlarController : Controller
    {
        private readonly AhmetSirketProjeContext _context;

        public CalisanlarController(AhmetSirketProjeContext context)
        {
            _context = context;
        }

        // GET: Calisanlar
        public async Task<IActionResult> Index()
        {
            var ahmetSirketProjeContext = _context.Calisanlar.Include(c => c.Kategori);
            return View(await ahmetSirketProjeContext.ToListAsync());
        }

        // GET: Calisanlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisanlar = await _context.Calisanlar
                .Include(c => c.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            return View(calisanlar);
        }

        // GET: Calisanlar/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Calisanlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdSoyad,SaatlikUcret,KategoriId")] Calisanlar calisanlar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(calisanlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", calisanlar.KategoriId);
            return View(calisanlar);
        }

        // GET: Calisanlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisanlar = await _context.Calisanlar.FindAsync(id);
            if (calisanlar == null)
            {
                return NotFound();
            }
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", calisanlar.KategoriId);
            return View(calisanlar);
        }

        // POST: Calisanlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdSoyad,SaatlikUcret,KategoriId")] Calisanlar calisanlar)
        {
            if (id != calisanlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(calisanlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CalisanlarExists(calisanlar.Id))
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
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", calisanlar.KategoriId);
            return View(calisanlar);
        }

        // GET: Calisanlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Calisanlar == null)
            {
                return NotFound();
            }

            var calisanlar = await _context.Calisanlar
                .Include(c => c.Kategori)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (calisanlar == null)
            {
                return NotFound();
            }

            return View(calisanlar);
        }

        // POST: Calisanlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Calisanlar == null)
            {
                return Problem("Entity set 'AhmetSirketProjeContext.Calisanlar'  is null.");
            }
            var calisanlar = await _context.Calisanlar.FindAsync(id);
            if (calisanlar != null)
            {
                _context.Calisanlar.Remove(calisanlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CalisanlarExists(int id)
        {
          return (_context.Calisanlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
