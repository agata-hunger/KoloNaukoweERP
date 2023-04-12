using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;

namespace WebAPIKN.Controllers
{
    public class SprzetyController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public SprzetyController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: Sprzety
        public async Task<IActionResult> Index()
        {
            var dbKoloNaukoweERP = _context.Sprzety.Include(s => s.Czlonek).Include(s => s.Zespol);
            return View(await dbKoloNaukoweERP.ToListAsync());
        }

        // GET: Sprzety/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Sprzety == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety
                .Include(s => s.Czlonek)
                .Include(s => s.Zespol)
                .FirstOrDefaultAsync(m => m.IdSprzetu == id);
            if (sprzet == null)
            {
                return NotFound();
            }

            return View(sprzet);
        }

        // GET: Sprzety/Create
        public IActionResult Create()
        {
            ViewData["IdCzlonka"] = new SelectList(_context.Czlonkowie, "IdCzlonka", "Imie");
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa");
            return View();
        }

        // POST: Sprzety/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdSprzetu,IdCzlonka,IdZespolu,Nazwa,Opis,CzyDostepny")] Sprzet sprzet)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sprzet);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdCzlonka"] = new SelectList(_context.Czlonkowie, "IdCzlonka", "Imie", sprzet.IdCzlonka);
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", sprzet.IdZespolu);
            return View(sprzet);
        }

        // GET: Sprzety/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Sprzety == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety.FindAsync(id);
            if (sprzet == null)
            {
                return NotFound();
            }
            ViewData["IdCzlonka"] = new SelectList(_context.Czlonkowie, "IdCzlonka", "Imie", sprzet.IdCzlonka);
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", sprzet.IdZespolu);
            return View(sprzet);
        }

        // POST: Sprzety/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdSprzetu,IdCzlonka,IdZespolu,Nazwa,Opis,CzyDostepny")] Sprzet sprzet)
        {
            if (id != sprzet.IdSprzetu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sprzet);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SprzetExists(sprzet.IdSprzetu))
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
            ViewData["IdCzlonka"] = new SelectList(_context.Czlonkowie, "IdCzlonka", "Imie", sprzet.IdCzlonka);
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", sprzet.IdZespolu);
            return View(sprzet);
        }

        // GET: Sprzety/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Sprzety == null)
            {
                return NotFound();
            }

            var sprzet = await _context.Sprzety
                .Include(s => s.Czlonek)
                .Include(s => s.Zespol)
                .FirstOrDefaultAsync(m => m.IdSprzetu == id);
            if (sprzet == null)
            {
                return NotFound();
            }

            return View(sprzet);
        }

        // POST: Sprzety/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Sprzety == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.Sprzety'  is null.");
            }
            var sprzet = await _context.Sprzety.FindAsync(id);
            if (sprzet != null)
            {
                _context.Sprzety.Remove(sprzet);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SprzetExists(int id)
        {
          return (_context.Sprzety?.Any(e => e.IdSprzetu == id)).GetValueOrDefault();
        }
    }
}
