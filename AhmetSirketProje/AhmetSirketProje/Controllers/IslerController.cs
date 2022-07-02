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
    public class IslerController : Controller
    {
        private readonly AhmetSirketProjeContext _context;

        public IslerController(AhmetSirketProjeContext context)
        {
            _context = context;
        }

        // GET: Isler
        public async Task<IActionResult> Index()
        {
            var ahmetSirketProjeContext = _context.Isler.Include(i => i.Calisan).Include(i => i.Kategori).Include(i => i.Sirket);
            return View(await ahmetSirketProjeContext.ToListAsync());
        }

        // GET: Isler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Isler == null)
            {
                return NotFound();
            }

            var isler = await _context.Isler
                .Include(i => i.Calisan)
                .Include(i => i.Kategori)
                .Include(i => i.Sirket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isler == null)
            {
                return NotFound();
            }

            return View(isler);
        }

        // GET: Isler/Create
        public IActionResult Create()
        {
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi");
            ViewData["SirketId"] = new SelectList(_context.Sirketler, "Id", "SirketAdi");
            return View();
        }

        // POST: Isler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Saat,SirketId,Aciklama,KategoriId")] Isler isler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(isler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CalisanId"] = new SelectList(_context.Calisanlar, "Id", "AdSoyad", isler.CalisanId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", isler.KategoriId);
            ViewData["SirketId"] = new SelectList(_context.Sirketler, "Id", "SirketAdi", isler.SirketId);
            return View(isler);
        }

        // GET: Isler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Isler == null)
            {
                return NotFound();
            }

            var isler = await _context.Isler.FindAsync(id);
            if (isler == null)
            {
                return NotFound();
            }
            ViewData["CalisanId"] = new SelectList(_context.Calisanlar.Where(p=>p.KategoriId==isler.KategoriId), "Id", "AdSoyad", isler.CalisanId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", isler.KategoriId);
            ViewData["SirketId"] = new SelectList(_context.Sirketler, "Id", "SirketAdi", isler.SirketId);
            return View(isler);
        }

        // POST: Isler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Saat,SirketId,CalisanId,Aciklama,KategoriId")] Isler isler)
        {
            if (id != isler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(isler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslerExists(isler.Id))
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
            ViewData["CalisanId"] = new SelectList(_context.Calisanlar.Where(p=>p.KategoriId==isler.KategoriId), "Id", "AdSoyad", isler.CalisanId);
            ViewData["KategoriId"] = new SelectList(_context.Kategoriler, "Id", "KategoriAdi", isler.KategoriId);
            ViewData["SirketId"] = new SelectList(_context.Sirketler, "Id", "SirketAdi", isler.SirketId);
            return View(isler);
        }

        // GET: Isler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Isler == null)
            {
                return NotFound();
            }

            var isler = await _context.Isler
                .Include(i => i.Calisan)
                .Include(i => i.Kategori)
                .Include(i => i.Sirket)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (isler == null)
            {
                return NotFound();
            }

            return View(isler);
        }

        // POST: Isler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Isler == null)
            {
                return Problem("Entity set 'AhmetSirketProjeContext.Isler'  is null.");
            }
            var isler = await _context.Isler.FindAsync(id);
            if (isler != null)
            {
                _context.Isler.Remove(isler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslerExists(int id)
        {
          return (_context.Isler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
