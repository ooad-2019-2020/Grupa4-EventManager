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
    public class KomentarController : Controller
    {
        private readonly EMContext _context;

        public KomentarController(EMContext context)
        {
            _context = context;
        }

        // GET: Komentars
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Recenzija.Include(k => k.Dogadjaj).Include(k => k.Korisnik);
            return View(await eMContext.ToListAsync());
        }

        // GET: Komentars/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentar = await _context.Recenzija
                .Include(k => k.Dogadjaj)
                .Include(k => k.Korisnik)
                .FirstOrDefaultAsync(m => m.KomentarId == id);
            if (komentar == null)
            {
                return NotFound();
            }

            return View(komentar);
        }

        // GET: Komentars/Create
        public IActionResult Create()
        {
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId");
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: Komentars/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("KomentarId,recenzija,brojZvjezdica,KorisnikId,datumOstavljanja,DogadjajId,neprimjerenKomentar")] Komentar komentar)
        {
            if (ModelState.IsValid)
            {
                _context.Add(komentar);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", komentar.DogadjajId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", komentar.KorisnikId);
            return View(komentar);
        }

        // GET: Komentars/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentar = await _context.Recenzija.FindAsync(id);
            if (komentar == null)
            {
                return NotFound();
            }
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", komentar.DogadjajId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", komentar.KorisnikId);
            return View(komentar);
        }

        // POST: Komentars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("KomentarId,recenzija,brojZvjezdica,KorisnikId,datumOstavljanja,DogadjajId,neprimjerenKomentar")] Komentar komentar)
        {
            if (id != komentar.KomentarId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(komentar);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KomentarExists(komentar.KomentarId))
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
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", komentar.DogadjajId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", komentar.KorisnikId);
            return View(komentar);
        }

        // GET: Komentars/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var komentar = await _context.Recenzija
                .Include(k => k.Dogadjaj)
                .Include(k => k.Korisnik)
                .FirstOrDefaultAsync(m => m.KomentarId == id);
            if (komentar == null)
            {
                return NotFound();
            }

            return View(komentar);
        }

        // POST: Komentars/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var komentar = await _context.Recenzija.FindAsync(id);
            _context.Recenzija.Remove(komentar);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KomentarExists(int id)
        {
            return _context.Recenzija.Any(e => e.KomentarId == id);
        }
    }
}
