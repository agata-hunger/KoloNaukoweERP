using System;
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
    public class ProjektyController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public ProjektyController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: Projekty
        public async Task<IActionResult> Index()
        {
            var dbKoloNaukoweERP = _context.Projekty.Include(p => p.Zespol);
            return View(await dbKoloNaukoweERP.ToListAsync());
        }

        // GET: Projekty/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Projekty == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekty
                .Include(p => p.Zespol)
                .FirstOrDefaultAsync(m => m.IdProjektu == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // GET: Projekty/Create
        public IActionResult Create()
        {
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa");
            return View();
        }

        // POST: Projekty/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProjektu,IdZespolu,Nazwa,TerminRealizacji,Opis")] Projekt projekt)
        {
            if (ModelState.IsValid)
            {
                _context.Add(projekt);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", projekt.IdZespolu);
            return View(projekt);
        }

        // GET: Projekty/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Projekty == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekty.FindAsync(id);
            if (projekt == null)
            {
                return NotFound();
            }
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", projekt.IdZespolu);
            return View(projekt);
        }

        // POST: Projekty/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProjektu,IdZespolu,Nazwa,TerminRealizacji,Opis")] Projekt projekt)
        {
            if (id != projekt.IdProjektu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(projekt);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProjektExists(projekt.IdProjektu))
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
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", projekt.IdZespolu);
            return View(projekt);
        }

        // GET: Projekty/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Projekty == null)
            {
                return NotFound();
            }

            var projekt = await _context.Projekty
                .Include(p => p.Zespol)
                .FirstOrDefaultAsync(m => m.IdProjektu == id);
            if (projekt == null)
            {
                return NotFound();
            }

            return View(projekt);
        }

        // POST: Projekty/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Projekty == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.Projekty'  is null.");
            }
            var projekt = await _context.Projekty.FindAsync(id);
            if (projekt != null)
            {
                _context.Projekty.Remove(projekt);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProjektExists(int id)
        {
          return (_context.Projekty?.Any(e => e.IdProjektu == id)).GetValueOrDefault();
        }
    }
}
