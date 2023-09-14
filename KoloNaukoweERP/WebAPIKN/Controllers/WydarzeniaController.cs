using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DAL;
using DAL.Entities;
using BLL;
using BLL.Services.Koordynator;
using BLL.Services.Sekretarz;
using BLL.Models;

namespace WebAPI.Controllers
{
    public class WydarzeniaController : Controller
    {
        private readonly ISekretarzServices sekretarzService;

        public WydarzeniaController(ISekretarzServices sekretarzService)
        {
            this.sekretarzService = sekretarzService;
        }

        // GET: Wydarzenia
        [HttpGet]
        public ActionResult<List<WydarzenieDTO>> Get()
        {
            return View("Index",sekretarzService.GetEvents());
        }
        //GET: Wydarzenie 
        public ActionResult<WydarzenieDTO> Get([FromRoute] int id)
        {
            var wydarzenie = sekretarzService.GetEvent(id);
            if (id == null || wydarzenie == null) //sprawdzenie istnienia ID
            {
                return NotFound();
            }
            return View(sekretarzService.GetEvent(id));
        }
        [HttpGet("wydarzenie/Create")]
        public ActionResult Create(int id)
        {
            ViewBag.WydarzenieId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Create(WydarzenieDTO wydarzenie)
        {
            if (!ModelState.IsValid)
                return View("Create", wydarzenie);
            var zespol = sekretarzService.GetTeam(wydarzenie.IdZespolu);
            //sekretarzService.AddWydarzenie(wydarzenie);
            return RedirectToAction(nameof(Index));     //prawdopodobieństwo błędu!
        }


        // GET: Wydarzenia/Edit/5
        //public async Task<IActionResult> Edit(int? id)
        //{
        //    if (id == null || _context.Wydarzenia == null)
        //    {
        //        return NotFound();
        //    }

        //    var wydarzenie = await _context.Wydarzenia.FindAsync(id);
        //    if (wydarzenie == null)
        //    {
        //        return NotFound();
        //    }
        //    ViewData["IdZespolu"] = new SelectList(_context.Zespoly, "IdZespolu", "Nazwa", wydarzenie.IdZespolu);
        //    return View(wydarzenie);
        //}

        // POST: Wydarzenia/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*[HttpPost]
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
        }*/

        // GET: Wydarzenia/Delete/5
        [HttpGet]
        public ActionResult Delete (string nazwaWydarzenia)
        {
            //sekretarzService.RemoveWydarzenie(nazwaWydarzenia);
            return View();
        }
        [HttpPost]
        public ActionResult Delete(WydarzenieDTO wydarzenie)
        {
            if (!ModelState.IsValid)
                return View("Delete", wydarzenie);
            //sekretarzService.RemoveWydarzenie(wydarzenie.Nazwa);
            return RedirectToAction(nameof(Index));     //prawdopodobieństwo błędu!
        }

        //private bool WydarzenieExists(int id)
        //{

        //  return (_context.Wydarzenia?.Any(e => e.IdWydarzenia == id)).GetValueOrDefault();

        //}
    }
}
