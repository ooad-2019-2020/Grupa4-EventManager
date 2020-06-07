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
    public class UstanovaController : Controller
    {
        private readonly EMContext _context;

        public UstanovaController(EMContext context)
        {
            _context = context;
        }

        // GET: Ustanova
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ustanova.ToListAsync());
        }

        // GET: Ustanova/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustanova = await _context.Ustanova
                .FirstOrDefaultAsync(m => m.UstanovaId == id);
            if (ustanova == null)
            {
                return NotFound();
            }

            return View(ustanova);
        }

        // GET: Ustanova/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Ustanova/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UstanovaId,KorisnikId,brojRacunaUBanci,brojTelefona,stanjeUplata,odgovornoLiceId,username,password,adresa,email")] Ustanova ustanova)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ustanova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ustanova);
        }

        // GET: Ustanova/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustanova = await _context.Ustanova.FindAsync(id);
            if (ustanova == null)
            {
                return NotFound();
            }
            return View(ustanova);
        }

        // POST: Ustanova/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("UstanovaId,KorisnikId,brojRacunaUBanci,brojTelefona,stanjeUplata,odgovornoLiceId,username,password,adresa,email")] Ustanova ustanova)
        {
            if (id != ustanova.UstanovaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ustanova);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!UstanovaExists(ustanova.UstanovaId))
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
            return View(ustanova);
        }

        // GET: Ustanova/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ustanova = await _context.Ustanova
                .FirstOrDefaultAsync(m => m.UstanovaId == id);
            if (ustanova == null)
            {
                return NotFound();
            }

            return View(ustanova);
        }

        // POST: Ustanova/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ustanova = await _context.Ustanova.FindAsync(id);
            _context.Ustanova.Remove(ustanova);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UstanovaExists(int id)
        {
            return _context.Ustanova.Any(e => e.UstanovaId == id);
        }
    }
}
