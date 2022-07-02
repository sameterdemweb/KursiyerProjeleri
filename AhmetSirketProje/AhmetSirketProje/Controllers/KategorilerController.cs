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
    public class KategorilerController : Controller
    {
        private readonly AhmetSirketProjeContext _context;

        public KategorilerController(AhmetSirketProjeContext context)
        {
            _context = context;
        }

        // GET: Kategoriler
        public async Task<IActionResult> Index()
        {
              return _context.Kategoriler != null ? 
                          View(await _context.Kategoriler.ToListAsync()) :
                          Problem("Entity set 'AhmetSirketProjeContext.Kategoriler'  is null.");
        }

        // GET: Kategoriler/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Kategoriler == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoriler == null)
            {
                return NotFound();
            }

            return View(kategoriler);
        }

        // GET: Kategoriler/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Kategoriler/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,KategoriAdi")] Kategoriler kategoriler)
        {
            if (ModelState.IsValid)
            {
                _context.Add(kategoriler);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(kategoriler);
        }

        // GET: Kategoriler/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Kategoriler == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.Kategoriler.FindAsync(id);
            if (kategoriler == null)
            {
                return NotFound();
            }
            return View(kategoriler);
        }

        // POST: Kategoriler/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,KategoriAdi")] Kategoriler kategoriler)
        {
            if (id != kategoriler.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(kategoriler);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KategorilerExists(kategoriler.Id))
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
            return View(kategoriler);
        }

        // GET: Kategoriler/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Kategoriler == null)
            {
                return NotFound();
            }

            var kategoriler = await _context.Kategoriler
                .FirstOrDefaultAsync(m => m.Id == id);
            if (kategoriler == null)
            {
                return NotFound();
            }

            return View(kategoriler);
        }

        // POST: Kategoriler/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Kategoriler == null)
            {
                return Problem("Entity set 'AhmetSirketProjeContext.Kategoriler'  is null.");
            }
            var kategoriler = await _context.Kategoriler.FindAsync(id);
            if (kategoriler != null)
            {
                _context.Kategoriler.Remove(kategoriler);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KategorilerExists(int id)
        {
          return (_context.Kategoriler?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
