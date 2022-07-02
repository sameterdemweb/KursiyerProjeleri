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
    public class BolumController : Controller
    {
        private readonly DbMehmetUzunContext _context;

        public BolumController(DbMehmetUzunContext context)
        {
            _context = context;
        }

        // GET: Bolum
        public async Task<IActionResult> Index()
        {
              return _context.Bolum != null ? 
                          View(await _context.Bolum.ToListAsync()) :
                          Problem("Entity set 'DbMehmetUzunContext.Bolum'  is null.");
        }

        // GET: Bolum/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Bolum == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // GET: Bolum/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Bolum/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,BolumAdi")] Bolum bolum)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bolum);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bolum);
        }

        // GET: Bolum/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Bolum == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolum.FindAsync(id);
            if (bolum == null)
            {
                return NotFound();
            }
            return View(bolum);
        }

        // POST: Bolum/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,BolumAdi")] Bolum bolum)
        {
            if (id != bolum.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bolum);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BolumExists(bolum.Id))
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
            return View(bolum);
        }

        // GET: Bolum/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Bolum == null)
            {
                return NotFound();
            }

            var bolum = await _context.Bolum
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bolum == null)
            {
                return NotFound();
            }

            return View(bolum);
        }

        // POST: Bolum/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Bolum == null)
            {
                return Problem("Entity set 'DbMehmetUzunContext.Bolum'  is null.");
            }
            var bolum = await _context.Bolum.FindAsync(id);
            if (bolum != null)
            {
                _context.Bolum.Remove(bolum);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BolumExists(int id)
        {
          return (_context.Bolum?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
