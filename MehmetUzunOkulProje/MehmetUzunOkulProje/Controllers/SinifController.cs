using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MehmetUzunOkulProje.Entities;
using MehmetUzunOkulProje.Models;

namespace MehmetUzunOkulProje.Controllers
{
    public class SinifController : Controller
    {
        private readonly DbMehmetUzunContext _context;

        public SinifController(DbMehmetUzunContext context)
        {
            _context = context;
        }

        // GET: Sinif
        public async Task<IActionResult> Index()
        {
            var dbMehmetUzunContext = _context.Sinif.Include(s => s.Bolum);
            return View(await dbMehmetUzunContext.ToListAsync());
        }

        // GET: Sinif/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sinif == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinif
                .Include(s => s.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // GET: Sinif/Create
        public IActionResult Create()
        {
            ViewData["BolumId"] = new SelectList(_context.Bolum, "Id", "BolumAdi");
            return View();
        }

        // POST: Sinif/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SinifAdi,BolumId")] Sinif sinif)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sinif);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BolumId"] = new SelectList(_context.Bolum, "Id", "BolumAdi", sinif.BolumId);
            return View(sinif);
        }

        // GET: Sinif/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sinif == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinif.FindAsync(id);
            if (sinif == null)
            {
                return NotFound();
            }
            ViewData["BolumId"] = new SelectList(_context.Bolum, "Id", "BolumAdi", sinif.BolumId);
            return View(sinif);
        }

        // POST: Sinif/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SinifAdi,BolumId")] Sinif sinif)
        {
            if (id != sinif.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sinif);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SinifExists(sinif.Id))
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
            ViewData["BolumId"] = new SelectList(_context.Bolum, "Id", "BolumAdi", sinif.BolumId);
            return View(sinif);
        }

        // GET: Sinif/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sinif == null)
            {
                return NotFound();
            }

            var sinif = await _context.Sinif
                .Include(s => s.Bolum)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sinif == null)
            {
                return NotFound();
            }

            return View(sinif);
        }

        // POST: Sinif/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sinif == null)
            {
                return Problem("Entity set 'DbMehmetUzunContext.Sinif'  is null.");
            }
            var sinif = await _context.Sinif.FindAsync(id);
            if (sinif != null)
            {
                _context.Sinif.Remove(sinif);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SinifExists(int id)
        {
          return (_context.Sinif?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
