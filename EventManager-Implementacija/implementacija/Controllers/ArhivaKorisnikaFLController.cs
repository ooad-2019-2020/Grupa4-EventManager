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
    public class ArhivaKorisnikaFLController : Controller
    {
        private readonly EMContext _context;

        public ArhivaKorisnikaFLController(EMContext context)
        {
            _context = context;
        }

        // GET: ArhivaKorisnikaFLs
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.ArhivaKorisnikaFL.Include(a => a.Korisnik).Include(a => a.TipFizickogLica);
            return View(await eMContext.ToListAsync());
        }

        // GET: ArhivaKorisnikaFLs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaFL = await _context.ArhivaKorisnikaFL
                .Include(a => a.Korisnik)
                .Include(a => a.TipFizickogLica)
                .FirstOrDefaultAsync(m => m.ArhivaKorisnikaFLId == id);
            if (arhivaKorisnikaFL == null)
            {
                return NotFound();
            }

            return View(arhivaKorisnikaFL);
        }

        // GET: ArhivaKorisnikaFLs/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["TipFizickogLicaId"] = new SelectList(_context.TipFizickogLica, "TipFizickogLicaId", "TipFizickogLicaId");
            return View();
        }

        // POST: ArhivaKorisnikaFLs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArhivaKorisnikaFLId,KorisnikId,izvrsioTransakciju,ukupnoUplatio,bioOdgovornoLice,TipFizickogLicaId,kreiraoRacun,napustioApp")] ArhivaKorisnikaFL arhivaKorisnikaFL)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arhivaKorisnikaFL);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaFL.KorisnikId);
            ViewData["TipFizickogLicaId"] = new SelectList(_context.TipFizickogLica, "TipFizickogLicaId", "TipFizickogLicaId", arhivaKorisnikaFL.TipFizickogLicaId);
            return View(arhivaKorisnikaFL);
        }

        // GET: ArhivaKorisnikaFLs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaFL = await _context.ArhivaKorisnikaFL.FindAsync(id);
            if (arhivaKorisnikaFL == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaFL.KorisnikId);
            ViewData["TipFizickogLicaId"] = new SelectList(_context.TipFizickogLica, "TipFizickogLicaId", "TipFizickogLicaId", arhivaKorisnikaFL.TipFizickogLicaId);
            return View(arhivaKorisnikaFL);
        }

        // POST: ArhivaKorisnikaFLs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArhivaKorisnikaFLId,KorisnikId,izvrsioTransakciju,ukupnoUplatio,bioOdgovornoLice,TipFizickogLicaId,kreiraoRacun,napustioApp")] ArhivaKorisnikaFL arhivaKorisnikaFL)
        {
            if (id != arhivaKorisnikaFL.ArhivaKorisnikaFLId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arhivaKorisnikaFL);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArhivaKorisnikaFLExists(arhivaKorisnikaFL.ArhivaKorisnikaFLId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaKorisnikaFL.KorisnikId);
            ViewData["TipFizickogLicaId"] = new SelectList(_context.TipFizickogLica, "TipFizickogLicaId", "TipFizickogLicaId", arhivaKorisnikaFL.TipFizickogLicaId);
            return View(arhivaKorisnikaFL);
        }

        // GET: ArhivaKorisnikaFLs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaKorisnikaFL = await _context.ArhivaKorisnikaFL
                .Include(a => a.Korisnik)
                .Include(a => a.TipFizickogLica)
                .FirstOrDefaultAsync(m => m.ArhivaKorisnikaFLId == id);
            if (arhivaKorisnikaFL == null)
            {
                return NotFound();
            }

            return View(arhivaKorisnikaFL);
        }

        // POST: ArhivaKorisnikaFLs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arhivaKorisnikaFL = await _context.ArhivaKorisnikaFL.FindAsync(id);
            _context.ArhivaKorisnikaFL.Remove(arhivaKorisnikaFL);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArhivaKorisnikaFLExists(int id)
        {
            return _context.ArhivaKorisnikaFL.Any(e => e.ArhivaKorisnikaFLId == id);
        }
    }
}
