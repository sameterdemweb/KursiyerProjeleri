using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FerhatProje.Entities;
using FerhatProje.Models;

namespace FerhatProje.Controllers
{
    public class SalonlarController : Controller
    {
        private readonly SalonDatabaseContext _context;

        public SalonlarController(SalonDatabaseContext context)
        {
            _context = context;
        }

        // GET: Salonlar
        public async Task<IActionResult> Index()
        {
              return _context.Salonlar != null ? 
                          View(await _context.Salonlar.ToListAsync()) :
                          Problem("Entity set 'SalonDatabaseContext.Salonlar'  is null.");
        }

        // GET: Salonlar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // GET: Salonlar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Salonlar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalonAdi")] Salonlar salonlar)
        {
            if (salonlar.SalonAdi != "")
            {
                _context.Add(salonlar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salonlar);
        }

        // GET: Salonlar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlar.FindAsync(id);
            if (salonlar == null)
            {
                return NotFound();
            }
            return View(salonlar);
        }

        // POST: Salonlar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalonAdi")] Salonlar salonlar)
        {
            if (id != salonlar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(salonlar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalonlarExists(salonlar.Id))
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
            return View(salonlar);
        }

        // GET: Salonlar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Salonlar == null)
            {
                return NotFound();
            }

            var salonlar = await _context.Salonlar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (salonlar == null)
            {
                return NotFound();
            }

            return View(salonlar);
        }

        // POST: Salonlar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Salonlar == null)
            {
                return Problem("Entity set 'SalonDatabaseContext.Salonlar'  is null.");
            }
            var salonlar = await _context.Salonlar.FindAsync(id);
            if (salonlar != null)
            {
                _context.Salonlar.Remove(salonlar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalonlarExists(int id)
        {
          return (_context.Salonlar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
