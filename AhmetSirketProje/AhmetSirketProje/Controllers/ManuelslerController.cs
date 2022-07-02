using AhmetSirketProje.Entities;
using AhmetSirketProje.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AhmetSirketProje.Controllers
{
    public class ManuelslerController : Controller
    {
        private readonly AhmetSirketProjeContext _context;

        public ManuelslerController(AhmetSirketProjeContext context)
        {
            _context = context;
        }
        
        public IActionResult Index()
        {
            List<Isler> isler = _context.Isler.Include(i=>i.Kategori).Include(i=>i.Calisan).Include(i=>i.Sirket).OrderBy(i=>i.Kategori.KategoriAdi).Take(3).ToList();
            return View(isler);
        }
    }
}
