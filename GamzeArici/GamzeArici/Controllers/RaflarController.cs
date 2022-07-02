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
    public class RaflarController : Controller
    {
        private readonly GamzeAriciContext _context;

        public RaflarController(GamzeAriciContext context)
        {
            _context = context;
        }

        // GET: Raflar
        public async Task<IActionResult> Index()
        {
              return _context.Raflar != null ? 
                          View(await _context.Raflar.ToListAsync()) :
                          Problem("Entity set 'GamzeAriciContext.Raflar'  is null.");
        }

        // GET: Raflar/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Raflar == null)
            {
                return NotFound();
            }

            var raflar = await _context.Raflar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raflar == null)
            {
                return NotFound();
            }

            return View(raflar);
        }

        // GET: Raflar/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Raflar/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RafAdi")] Raflar raflar)
        {
            if (raflar.RafAdi!="")
            {
                _context.Add(raflar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(raflar);
        }

        // GET: Raflar/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Raflar == null)
            {
                return NotFound();
            }

            var raflar = await _context.Raflar.FindAsync(id);
            if (raflar == null)
            {
                return NotFound();
            }
            return View(raflar);
        }

        // POST: Raflar/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RafAdi")] Raflar raflar)
        {
            if (id != raflar.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(raflar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RaflarExists(raflar.Id))
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
            return View(raflar);
        }

        // GET: Raflar/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Raflar == null)
            {
                return NotFound();
            }

            var raflar = await _context.Raflar
                .FirstOrDefaultAsync(m => m.Id == id);
            if (raflar == null)
            {
                return NotFound();
            }

            return View(raflar);
        }

        // POST: Raflar/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Raflar == null)
            {
                return Problem("Entity set 'GamzeAriciContext.Raflar'  is null.");
            }
            var raflar = await _context.Raflar.FindAsync(id);
            if (raflar != null)
            {
                _context.Raflar.Remove(raflar);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RaflarExists(int id)
        {
          return (_context.Raflar?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
