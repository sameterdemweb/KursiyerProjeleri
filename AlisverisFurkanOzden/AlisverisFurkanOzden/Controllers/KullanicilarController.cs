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
    public class KullanicilarController : Controller
    {
        private readonly AlisverisFurkanOzdenDbContext _context;

        public KullanicilarController(AlisverisFurkanOzdenDbContext context)
        {
            _context = context;
        }

        // GET: Kullanicilar
        public async Task<IActionResult> Index()
        {
              return _context.Kullanicilar != null ? 
                          View(await _context.Kullanicilar.ToListAsync()) :
                          Problem("Entity set 'AlisverisFurkanOzdenDbContext.Kullanicilar'  is null.");
        }

        // GET: Kullanicilar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // GET: Kullanicilar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kullanicilar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdiSoyadi,Yas,TelefonNumarasi,Mail")] Kullanicilar kullanicilar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kullanicilar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kullanicilar);
        }

        // GET: Kullanicilar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar.FindAsync(id);
            if (kullanicilar == null)
            {
                return NotFound();
            }
            return View(kullanicilar);
        }

        // POST: Kullanicilar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdiSoyadi,Yas,TelefonNumarasi,Mail")] Kullanicilar kullanicilar)
        {
            if (id != kullanicilar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kullanicilar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KullanicilarExists(kullanicilar.Id))
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
            return View(kullanicilar);
        }

        // GET: Kullanicilar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kullanicilar == null)
            {
                return NotFound();
            }

            var kullanicilar = await _context.Kullanicilar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kullanicilar == null)
            {
                return NotFound();
            }

            return View(kullanicilar);
        }

        // POST: Kullanicilar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kullanicilar == null)
            {
                return Problem("Entity set 'AlisverisFurkanOzdenDbContext.Kullanicilar'  is null.");
            }
            var kullanicilar = await _context.Kullanicilar.FindAsync(id);
            if (kullanicilar != null)
            {
                _context.Kullanicilar.Remove(kullanicilar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KullanicilarExists(int id)
        {
          return (_context.Kullanicilar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
