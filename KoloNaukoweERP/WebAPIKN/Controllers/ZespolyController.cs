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
    public class ZespolyController : Controller
    {
        private readonly DbKoloNaukoweERP _context;

        public ZespolyController(DbKoloNaukoweERP context)
        {
            _context = context;
        }

        // GET: Zespoly
        public async Task<IActionResult> Index()
        {
              return _context.Zespoly != null ? 
                          View(await _context.Zespoly.ToListAsync()) :
                          Problem("Entity set 'DbKoloNaukoweERP.Zespoly'  is null.");
        }

        // GET: Zespoly/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Zespoly == null)
            {
                return NotFound();
            }

            var zespol = await _context.Zespoly
                .FirstOrDefaultAsync(m => m.IdZespolu == id);
            if (zespol == null)
            {
                return NotFound();
            }

            return View(zespol);
        }

        // GET: Zespoly/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Zespoly/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdZespolu,Nazwa")] Zespol zespol)
        {
            if (ModelState.IsValid)
            {
                _context.Add(zespol);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(zespol);
        }

        // GET: Zespoly/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Zespoly == null)
            {
                return NotFound();
            }

            var zespol = await _context.Zespoly.FindAsync(id);
            if (zespol == null)
            {
                return NotFound();
            }
            return View(zespol);
        }

        // POST: Zespoly/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdZespolu,Nazwa")] Zespol zespol)
        {
            if (id != zespol.IdZespolu)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(zespol);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ZespolExists(zespol.IdZespolu))
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
            return View(zespol);
        }

        // GET: Zespoly/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Zespoly == null)
            {
                return NotFound();
            }

            var zespol = await _context.Zespoly
                .FirstOrDefaultAsync(m => m.IdZespolu == id);
            if (zespol == null)
            {
                return NotFound();
            }

            return View(zespol);
        }

        // POST: Zespoly/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Zespoly == null)
            {
                return Problem("Entity set 'DbKoloNaukoweERP.Zespoly'  is null.");
            }
            var zespol = await _context.Zespoly.FindAsync(id);
            if (zespol != null)
            {
                _context.Zespoly.Remove(zespol);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ZespolExists(int id)
        {
          return (_context.Zespoly?.Any(e => e.IdZespolu == id)).GetValueOrDefault();
        }
    }
}
