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
    public class FilmlerController : Controller
    {
        private readonly SalonDatabaseContext _context;

        public FilmlerController(SalonDatabaseContext context)
        {
            _context = context;
        }

        // GET: Filmler
        public async Task<IActionResult> Index()
        {
            var salonDatabaseContext = _context.Filmler.Include(f => f.Salon);
            return View(await salonDatabaseContext.ToListAsync());
        }

        // GET: Filmler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Filmler == null)
            {
                return NotFound();
            }

            var filmler = await _context.Filmler
                .Include(f => f.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmler == null)
            {
                return NotFound();
            }

            return View(filmler);
        }

        // GET: Filmler/Create
        public IActionResult Create()
        {
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "SalonAdi");
            return View();
        }

        // POST: Filmler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SalonId,FilmAdi,FilmKonusu,Yonetmeni")] Filmler filmler)
        {
            if (filmler.FilmAdi != "")
            {
                _context.Add(filmler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "SalonAdi", filmler.SalonId);
            return View(filmler);
        }

        // GET: Filmler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Filmler == null)
            {
                return NotFound();
            }

            var filmler = await _context.Filmler.FindAsync(id);
            if (filmler == null)
            {
                return NotFound();
            }
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "SalonAdi", filmler.SalonId);
            return View(filmler);
        }

        // POST: Filmler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SalonId,FilmAdi,FilmKonusu,Yonetmeni")] Filmler filmler)
        {
            if (id != filmler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(filmler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FilmlerExists(filmler.Id))
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
            ViewData["SalonId"] = new SelectList(_context.Salonlar, "Id", "SalonAdi", filmler.SalonId);
            return View(filmler);
        }

        // GET: Filmler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Filmler == null)
            {
                return NotFound();
            }

            var filmler = await _context.Filmler
                .Include(f => f.Salon)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (filmler == null)
            {
                return NotFound();
            }

            return View(filmler);
        }

        // POST: Filmler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Filmler == null)
            {
                return Problem("Entity set 'SalonDatabaseContext.Filmler'  is null.");
            }
            var filmler = await _context.Filmler.FindAsync(id);
            if (filmler != null)
            {
                _context.Filmler.Remove(filmler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FilmlerExists(int id)
        {
          return (_context.Filmler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
