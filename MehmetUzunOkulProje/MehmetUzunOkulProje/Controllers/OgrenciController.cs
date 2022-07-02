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
    public class OgrenciController : Controller
    {
        private readonly DbMehmetUzunContext _context;

        public OgrenciController(DbMehmetUzunContext context)
        {
            _context = context;
        }

        // GET: Ogrenci
        public async Task<IActionResult> Index()
        {
            var dbMehmetUzunContext = _context.Ogrenci.Include(o=>o.Sinif).Include(b=>b.Sinif.Bolum);
            return View(await dbMehmetUzunContext.ToListAsync());
        }

        // GET: Ogrenci/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci
                .Include(o => o.Sinif)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // GET: Ogrenci/Create
        public IActionResult Create()
        {
            ViewData["SinifId"] = new SelectList(_context.Sinif, "Id", "SinifAdi");
            return View();
        }

        // POST: Ogrenci/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Adi,Soyadi,Telefon,SinifId")] Ogrenci ogrenci)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ogrenci);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["SinifId"] = new SelectList(_context.Sinif, "Id", "SinifAdi", ogrenci.SinifId);
            return View(ogrenci);
        }

        // GET: Ogrenci/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci.FindAsync(id);
            if (ogrenci == null)
            {
                return NotFound();
            }
            ViewData["SinifId"] = new SelectList(_context.Sinif, "Id", "SinifAdi", ogrenci.SinifId);
            return View(ogrenci);
        }

        // POST: Ogrenci/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Adi,Soyadi,Telefon,SinifId")] Ogrenci ogrenci)
        {
            if (id != ogrenci.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ogrenci);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OgrenciExists(ogrenci.Id))
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
            ViewData["SinifId"] = new SelectList(_context.Sinif, "Id", "SinifAdi", ogrenci.SinifId);
            return View(ogrenci);
        }

        // GET: Ogrenci/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Ogrenci == null)
            {
                return NotFound();
            }

            var ogrenci = await _context.Ogrenci
                .Include(o => o.Sinif)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (ogrenci == null)
            {
                return NotFound();
            }

            return View(ogrenci);
        }

        // POST: Ogrenci/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Ogrenci == null)
            {
                return Problem("Entity set 'DbMehmetUzunContext.Ogrenci'  is null.");
            }
            var ogrenci = await _context.Ogrenci.FindAsync(id);
            if (ogrenci != null)
            {
                _context.Ogrenci.Remove(ogrenci);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OgrenciExists(int id)
        {
          return (_context.Ogrenci?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
