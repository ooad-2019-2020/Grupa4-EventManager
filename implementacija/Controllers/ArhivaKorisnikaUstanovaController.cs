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
    public class ArhivaKorisnikaUstanovaController : Controller
    {
        private readonly EMContext _context;

        public ArhivaKorisnikaUstanovaController(EMContext context)
        {
            _context = context;
        }

        // GET: ArhivaKorisnikaUstanova
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.ArhivaKorisnikaUstanova.Include(a => a.Korisnik);
            return View(await eMContext.ToListAsync());
        }

        // GET: ArhivaKorisnikaUstanova/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaUstanova = await _context.ArhivaKorisnikaUstanova
                .Include(a => a.Korisnik)
                .FirstOrDefaultAsync(m => m.ArhivaKorisnikaUstanovaId == id);
            if (arhivaKorisnikaUstanova == null)
            {
                return NotFound();
            }

            return View(arhivaKorisnikaUstanova);
        }

        // GET: ArhivaKorisnikaUstanova/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: ArhivaKorisnikaUstanova/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArhivaKorisnikaUstanovaId,KorisnikId,imaoUplata,kreiraoRacun,napustioSistem")] ArhivaKorisnikaUstanova arhivaKorisnikaUstanova)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arhivaKorisnikaUstanova);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaUstanova.KorisnikId);
            return View(arhivaKorisnikaUstanova);
        }

        // GET: ArhivaKorisnikaUstanova/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaUstanova = await _context.ArhivaKorisnikaUstanova.FindAsync(id);
            if (arhivaKorisnikaUstanova == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaUstanova.KorisnikId);
            return View(arhivaKorisnikaUstanova);
        }

        // POST: ArhivaKorisnikaUstanova/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArhivaKorisnikaUstanovaId,KorisnikId,imaoUplata,kreiraoRacun,napustioSistem")] ArhivaKorisnikaUstanova arhivaKorisnikaUstanova)
        {
            if (id != arhivaKorisnikaUstanova.ArhivaKorisnikaUstanovaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arhivaKorisnikaUstanova);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArhivaKorisnikaUstanovaExists(arhivaKorisnikaUstanova.ArhivaKorisnikaUstanovaId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaUstanova.KorisnikId);
            return View(arhivaKorisnikaUstanova);
        }

        // GET: ArhivaKorisnikaUstanova/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaUstanova = await _context.ArhivaKorisnikaUstanova
                .Include(a => a.Korisnik)
                .FirstOrDefaultAsync(m => m.ArhivaKorisnikaUstanovaId == id);
            if (arhivaKorisnikaUstanova == null)
            {
                return NotFound();
            }

            return View(arhivaKorisnikaUstanova);
        }

        // POST: ArhivaKorisnikaUstanova/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arhivaKorisnikaUstanova = await _context.ArhivaKorisnikaUstanova.FindAsync(id);
            _context.ArhivaKorisnikaUstanova.Remove(arhivaKorisnikaUstanova);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArhivaKorisnikaUstanovaExists(int id)
        {
            return _context.ArhivaKorisnikaUstanova.Any(e => e.ArhivaKorisnikaUstanovaId == id);
        }
    }
}
