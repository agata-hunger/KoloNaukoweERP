/*using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace WebAPI.Controllers
{
    public class CzlonkowieController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public CzlonkowieController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: Czlonkowie
        public async Task<IActionResult> Index()
        {
            var dbKoloNaukoweERP = _context.Czlonkowie.Include(c => c.PelnionaFunkcja);
            return View(await dbKoloNaukoweERP.ToListAsync());
        }

        // GET: Czlonkowie/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Czlonkowie == null)
            {
                return NotFound();
            }

            var czlonek = await _context.Czlonkowie
                .Include(c => c.PelnionaFunkcja)
                .FirstOrDefaultAsync(m => m.IdCzlonka == id);
            if (czlonek == null)
            {
                return NotFound();
            }

            return View(czlonek);
        }

        // GET: Czlonkowie/Create
        public IActionResult Create()
        {
            ViewData["IdPelnionejFunkcji"] = new SelectList(_context.PelnioneFunkcje, "IdPelnionejFunkcji", "Nazwa");
            return View();
        }

        // POST: Czlonkowie/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdCzlonka,IdPelnionejFunkcji,NrTelefonu,Mail,Nazwisko,Imie,KierunekStudiow,Wydzial,Uczelnia")] Czlonek czlonek)
        {
            if (ModelState.IsValid)
            {
                _context.Add(czlonek);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdPelnionejFunkcji"] = new SelectList(_context.PelnioneFunkcje, "IdPelnionejFunkcji", "Nazwa", czlonek.IdPelnionejFunkcji);
            return View(czlonek);
        }

        // GET: Czlonkowie/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Czlonkowie == null)
            {
                return NotFound();
            }

            var czlonek = await _context.Czlonkowie.FindAsync(id);
            if (czlonek == null)
            {
                return NotFound();
            }
            ViewData["IdPelnionejFunkcji"] = new SelectList(_context.PelnioneFunkcje, "IdPelnionejFunkcji", "Nazwa", czlonek.IdPelnionejFunkcji);
            return View(czlonek);
        }

        // POST: Czlonkowie/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdCzlonka,IdPelnionejFunkcji,NrTelefonu,Mail,Nazwisko,Imie,KierunekStudiow,Wydzial,Uczelnia")] Czlonek czlonek)
        {
            if (id != czlonek.IdCzlonka)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(czlonek);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CzlonekExists(czlonek.IdCzlonka))
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
            ViewData["IdPelnionejFunkcji"] = new SelectList(_context.PelnioneFunkcje, "IdPelnionejFunkcji", "Nazwa", czlonek.IdPelnionejFunkcji);
            return View(czlonek);
        }

        // GET: Czlonkowie/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Czlonkowie == null)
            {
                return NotFound();
            }

            var czlonek = await _context.Czlonkowie
                .Include(c => c.PelnionaFunkcja)
                .FirstOrDefaultAsync(m => m.IdCzlonka == id);
            if (czlonek == null)
            {
                return NotFound();
            }

            return View(czlonek);
        }

        // POST: Czlonkowie/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Czlonkowie == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.Czlonkowie'  is null.");
            }
            var czlonek = await _context.Czlonkowie.FindAsync(id);
            if (czlonek != null)
            {
                _context.Czlonkowie.Remove(czlonek);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CzlonekExists(int id)
        {
          return (_context.Czlonkowie?.Any(e => e.IdCzlonka == id)).GetValueOrDefault();
        }
    }
}
*/