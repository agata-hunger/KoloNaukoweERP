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
    public class PelnioneFunkcjeController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public PelnioneFunkcjeController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: PelnioneFunkcje
        public async Task<IActionResult> Index()
        {
              return _context.PelnioneFunkcje != null ? 
                          View(await _context.PelnioneFunkcje.ToListAsync()) :
                          Problem("Entity set 'DbKoloNaukoweERP.PelnioneFunkcje'  is null.");
        }

        // GET: PelnioneFunkcje/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.PelnioneFunkcje == null)
            {
                return NotFound();
            }

            var pelnionaFunkcja = await _context.PelnioneFunkcje
                .FirstOrDefaultAsync(m => m.IdPelnionejFunkcji == id);
            if (pelnionaFunkcja == null)
            {
                return NotFound();
            }

            return View(pelnionaFunkcja);
        }

        // GET: PelnioneFunkcje/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: PelnioneFunkcje/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdPelnionejFunkcji,Nazwa")] PelnionaFunkcja pelnionaFunkcja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pelnionaFunkcja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pelnionaFunkcja);
        }

        // GET: PelnioneFunkcje/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.PelnioneFunkcje == null)
            {
                return NotFound();
            }

            var pelnionaFunkcja = await _context.PelnioneFunkcje.FindAsync(id);
            if (pelnionaFunkcja == null)
            {
                return NotFound();
            }
            return View(pelnionaFunkcja);
        }

        // POST: PelnioneFunkcje/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdPelnionejFunkcji,Nazwa")] PelnionaFunkcja pelnionaFunkcja)
        {
            if (id != pelnionaFunkcja.IdPelnionejFunkcji)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pelnionaFunkcja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PelnionaFunkcjaExists(pelnionaFunkcja.IdPelnionejFunkcji))
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
            return View(pelnionaFunkcja);
        }

        // GET: PelnioneFunkcje/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.PelnioneFunkcje == null)
            {
                return NotFound();
            }

            var pelnionaFunkcja = await _context.PelnioneFunkcje
                .FirstOrDefaultAsync(m => m.IdPelnionejFunkcji == id);
            if (pelnionaFunkcja == null)
            {
                return NotFound();
            }

            return View(pelnionaFunkcja);
        }

        // POST: PelnioneFunkcje/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.PelnioneFunkcje == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.PelnioneFunkcje'  is null.");
            }
            var pelnionaFunkcja = await _context.PelnioneFunkcje.FindAsync(id);
            if (pelnionaFunkcja != null)
            {
                _context.PelnioneFunkcje.Remove(pelnionaFunkcja);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PelnionaFunkcjaExists(int id)
        {
          return (_context.PelnioneFunkcje?.Any(e => e.IdPelnionejFunkcji == id)).GetValueOrDefault();
        }
    }
}
