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
    public class OkuyucularController : Controller
    {
        private readonly GamzeAriciContext _context;

        public OkuyucularController(GamzeAriciContext context)
        {
            _context = context;
        }

        // GET: Okuyucular
        public async Task<IActionResult> Index()
        {
              return _context.Okuyucular != null ? 
                          View(await _context.Okuyucular.ToListAsync()) :
                          Problem("Entity set 'GamzeAriciContext.Okuyucular'  is null.");
        }

        // GET: Okuyucular/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Okuyucular == null)
            {
                return NotFound();
            }

            var okuyucular = await _context.Okuyucular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (okuyucular == null)
            {
                return NotFound();
            }

            return View(okuyucular);
        }

        // GET: Okuyucular/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Okuyucular/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AdiSoyadi,Adres")] Okuyucular okuyucular)
        {
            if (!ModelState.IsValid)
            {
                _context.Add(okuyucular);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(okuyucular);
        }

        // GET: Okuyucular/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Okuyucular == null)
            {
                return NotFound();
            }

            var okuyucular = await _context.Okuyucular.FindAsync(id);
            if (okuyucular == null)
            {
                return NotFound();
            }
            return View(okuyucular);
        }

        // POST: Okuyucular/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AdiSoyadi,Adres")] Okuyucular okuyucular)
        {
            if (id != okuyucular.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(okuyucular);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OkuyucularExists(okuyucular.Id))
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
            return View(okuyucular);
        }

        // GET: Okuyucular/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Okuyucular == null)
            {
                return NotFound();
            }

            var okuyucular = await _context.Okuyucular
                .FirstOrDefaultAsync(m => m.Id == id);
            if (okuyucular == null)
            {
                return NotFound();
            }

            return View(okuyucular);
        }

        // POST: Okuyucular/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Okuyucular == null)
            {
                return Problem("Entity set 'GamzeAriciContext.Okuyucular'  is null.");
            }
            var okuyucular = await _context.Okuyucular.FindAsync(id);
            if (okuyucular != null)
            {
                _context.Okuyucular.Remove(okuyucular);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OkuyucularExists(int id)
        {
          return (_context.Okuyucular?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
