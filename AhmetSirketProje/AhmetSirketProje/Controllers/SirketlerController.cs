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
    public class SirketlerController : Controller
    {
        private readonly AhmetSirketProjeContext _context;

        public SirketlerController(AhmetSirketProjeContext context)
        {
            _context = context;
        }

        // GET: Sirketler
        public async Task<IActionResult> Index()
        {
              return _context.Sirketler != null ? 
                          View(await _context.Sirketler.ToListAsync()) :
                          Problem("Entity set 'AhmetSirketProjeContext.Sirketler'  is null.");
        }

        // GET: Sirketler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sirketler == null)
            {
                return NotFound();
            }

            var sirketler = await _context.Sirketler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sirketler == null)
            {
                return NotFound();
            }

            return View(sirketler);
        }

        // GET: Sirketler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sirketler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,SirketAdi,Logo")] Sirketler sirketler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sirketler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sirketler);
        }

        // GET: Sirketler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sirketler == null)
            {
                return NotFound();
            }

            var sirketler = await _context.Sirketler.FindAsync(id);
            if (sirketler == null)
            {
                return NotFound();
            }
            return View(sirketler);
        }

        // POST: Sirketler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,SirketAdi,Logo")] Sirketler sirketler)
        {
            if (id != sirketler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sirketler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SirketlerExists(sirketler.Id))
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
            return View(sirketler);
        }

        // GET: Sirketler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sirketler == null)
            {
                return NotFound();
            }

            var sirketler = await _context.Sirketler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (sirketler == null)
            {
                return NotFound();
            }

            return View(sirketler);
        }

        // POST: Sirketler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sirketler == null)
            {
                return Problem("Entity set 'AhmetSirketProjeContext.Sirketler'  is null.");
            }
            var sirketler = await _context.Sirketler.FindAsync(id);
            if (sirketler != null)
            {
                _context.Sirketler.Remove(sirketler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SirketlerExists(int id)
        {
          return (_context.Sirketler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
