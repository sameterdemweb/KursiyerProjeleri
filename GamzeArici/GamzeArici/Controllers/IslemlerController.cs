using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using GamzeArici.Entities;
using GamzeArici.Models;

namespace GamzeArici.Controllers
{
    public class IslemlerController : Controller
    {
        private readonly GamzeAriciContext _context;

        public IslemlerController(GamzeAriciContext context)
        {
            _context = context;
        }

        // GET: Islemler
        public async Task<IActionResult> Index()
        {
            var gamzeAriciContext = _context.Islemler.Include(i => i.Kitap).Include(i => i.Okuyucu);
            return View(await gamzeAriciContext.ToListAsync());
        }

        // GET: Islemler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islemler = await _context.Islemler
                .Include(i => i.Kitap)
                .Include(i => i.Okuyucu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islemler == null)
            {
                return NotFound();
            }

            return View(islemler);
        }

        // GET: Islemler/Create
        public IActionResult Create()
        {
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "Id", "Id");
            ViewData["OkuyucuId"] = new SelectList(_context.Okuyucular, "Id", "Id");
            return View();
        }

        // POST: Islemler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KitapId,OkuyucuId,AlmaTarihi,IadeTarihi")] Islemler islemler)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(islemler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "Id", "Id", islemler.KitapId);
            ViewData["OkuyucuId"] = new SelectList(_context.Okuyucular, "Id", "Id", islemler.OkuyucuId);
            return View(islemler);
        }

        // GET: Islemler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islemler = await _context.Islemler.FindAsync(id);
            if (islemler == null)
            {
                return NotFound();
            }
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "Id", "Id", islemler.KitapId);
            ViewData["OkuyucuId"] = new SelectList(_context.Okuyucular, "Id", "Id", islemler.OkuyucuId);
            return View(islemler);
        }

        // POST: Islemler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KitapId,OkuyucuId,AlmaTarihi,IadeTarihi")] Islemler islemler)
        {
            if (id != islemler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(islemler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IslemlerExists(islemler.Id))
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
            ViewData["KitapId"] = new SelectList(_context.Kitaplar, "Id", "Id", islemler.KitapId);
            ViewData["OkuyucuId"] = new SelectList(_context.Okuyucular, "Id", "Id", islemler.OkuyucuId);
            return View(islemler);
        }

        // GET: Islemler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Islemler == null)
            {
                return NotFound();
            }

            var islemler = await _context.Islemler
                .Include(i => i.Kitap)
                .Include(i => i.Okuyucu)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (islemler == null)
            {
                return NotFound();
            }

            return View(islemler);
        }

        // POST: Islemler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Islemler == null)
            {
                return Problem("Entity set 'GamzeAriciContext.Islemler'  is null.");
            }
            var islemler = await _context.Islemler.FindAsync(id);
            if (islemler != null)
            {
                _context.Islemler.Remove(islemler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IslemlerExists(int id)
        {
          return (_context.Islemler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
