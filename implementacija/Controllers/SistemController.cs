using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using implementacija.Models;

namespace implementacija.Controllers
{
    public class SistemController : Controller
    {
        private readonly EMContext _context;

        public SistemController(EMContext context)
        {
            _context = context;
        }

        // GET: Sistem
        public async Task<IActionResult> Index()
        {
            return View(await _context.Sistem.ToListAsync());
        }

        // GET: Sistem/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem
                .FirstOrDefaultAsync(m => m.SistemId == id);
            if (sistem == null)
            {
                return NotFound();
            }

            return View(sistem);
        }

        // GET: Sistem/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Sistem/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SistemId,KorisnikId")] Sistem sistem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sistem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(sistem);
        }

        // GET: Sistem/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem.FindAsync(id);
            if (sistem == null)
            {
                return NotFound();
            }
            return View(sistem);
        }

        // POST: Sistem/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SistemId,KorisnikId")] Sistem sistem)
        {
            if (id != sistem.SistemId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sistem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SistemExists(sistem.SistemId))
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
            return View(sistem);
        }

        // GET: Sistem/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sistem = await _context.Sistem
                .FirstOrDefaultAsync(m => m.SistemId == id);
            if (sistem == null)
            {
                return NotFound();
            }

            return View(sistem);
        }

        // POST: Sistem/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sistem = await _context.Sistem.FindAsync(id);
            _context.Sistem.Remove(sistem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SistemExists(int id)
        {
            return _context.Sistem.Any(e => e.SistemId == id);
        }
    }
}
