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
    public class WydarzeniaController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public WydarzeniaController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: Wydarzenia
        public async Task<IActionResult> Index()
        {
            var dbKoloNaukoweERP = _context.Wydarzenia.Include(w => w.Zespol);
            return View(await dbKoloNaukoweERP.ToListAsync());
        }

        // GET: Wydarzenia/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Wydarzenia == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia
                .Include(w => w.Zespol)
                .FirstOrDefaultAsync(m => m.IdWydarzenia == id);
            if (wydarzenie == null)
            {
                return NotFound();
            }

            return View(wydarzenie);
        }

        // GET: Wydarzenia/Create
        public IActionResult Create()
        {
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa");
            return View();
        }

        // POST: Wydarzenia/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdWydarzenia,IdZespolu,Nazwa,Data,Miejsce")] Wydarzenie wydarzenie)
        {
            if (ModelState.IsValid)
            {
                _context.Add(wydarzenie);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", wydarzenie.IdZespolu);
            return View(wydarzenie);
        }

        // GET: Wydarzenia/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Wydarzenia == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia.FindAsync(id);
            if (wydarzenie == null)
            {
                return NotFound();
            }
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", wydarzenie.IdZespolu);
            return View(wydarzenie);
        }

        // POST: Wydarzenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdWydarzenia,IdZespolu,Nazwa,Data,Miejsce")] Wydarzenie wydarzenie)
        {
            if (id != wydarzenie.IdWydarzenia)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(wydarzenie);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WydarzenieExists(wydarzenie.IdWydarzenia))
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
            ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", wydarzenie.IdZespolu);
            return View(wydarzenie);
        }

        // GET: Wydarzenia/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Wydarzenia == null)
            {
                return NotFound();
            }

            var wydarzenie = await _context.Wydarzenia
                .Include(w => w.Zespol)
                .FirstOrDefaultAsync(m => m.IdWydarzenia == id);
            if (wydarzenie == null)
            {
                return NotFound();
            }

            return View(wydarzenie);
        }

        // POST: Wydarzenia/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Wydarzenia == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.Wydarzenia'  is null.");
            }
            var wydarzenie = await _context.Wydarzenia.FindAsync(id);
            if (wydarzenie != null)
            {
                _context.Wydarzenia.Remove(wydarzenie);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WydarzenieExists(int id)
        {
          return (_context.Wydarzenia?.Any(e => e.IdWydarzenia == id)).GetValueOrDefault();
        }
    }
}
