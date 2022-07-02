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
    public class UrunlerController : Controller
    {
        private readonly AlisverisFurkanOzdenDbContext _context;

        public UrunlerController(AlisverisFurkanOzdenDbContext context)
        {
            _context = context;
        }

        // GET: Urunler
        public async Task<IActionResult> Index()
        {
              return _context.Urunler != null ? 
                          View(await _context.Urunler.ToListAsync()) :
                          Problem("Entity set 'AlisverisFurkanOzdenDbContext.Urunler'  is null.");
        }

        // GET: Urunler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // GET: Urunler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Urunler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,UrunAdi,Fiyat")] Urunler urunler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(urunler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(urunler);
        }

        // GET: Urunler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler.FindAsync(id);
            if (urunler == null)
            {
                return NotFound();
            }
            return View(urunler);
        }

        // POST: Urunler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,UrunAdi,Fiyat")] Urunler urunler)
        {
            if (id != urunler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(urunler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UrunlerExists(urunler.Id))
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
            return View(urunler);
        }

        // GET: Urunler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Urunler == null)
            {
                return NotFound();
            }

            var urunler = await _context.Urunler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (urunler == null)
            {
                return NotFound();
            }

            return View(urunler);
        }

        // POST: Urunler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Urunler == null)
            {
                return Problem("Entity set 'AlisverisFurkanOzdenDbContext.Urunler'  is null.");
            }
            var urunler = await _context.Urunler.FindAsync(id);
            if (urunler != null)
            {
                _context.Urunler.Remove(urunler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UrunlerExists(int id)
        {
          return (_context.Urunler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
