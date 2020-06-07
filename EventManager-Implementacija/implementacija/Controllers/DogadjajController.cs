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
    public class DogadjajController : Controller
    {
        private readonly EMContext _context;

        public DogadjajController(EMContext context)
        {
            _context = context;
        }

        // GET: Dogadjaj
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Dogadjaj.Include(d => d.Korisnik).Include(d => d.Ustanova);
            return View(await eMContext.ToListAsync());
        }

        // GET: Dogadjaj/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj
                .Include(d => d.Korisnik)
                .Include(d => d.Ustanova)
                .FirstOrDefaultAsync(m => m.DogadjajId == id);
            if (dogadjaj == null)
            {
                return NotFound();
            }

            return View(dogadjaj);
        }

        // GET: Dogadjaj/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId");
            return View();
        }

        // POST: Dogadjaj/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DogadjajId,UstanovaId,KorisnikId,kapacitet,cijena,datumDogadjaja,trenutniKapacitet")] Dogadjaj dogadjaj)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dogadjaj);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", dogadjaj.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", dogadjaj.UstanovaId);
            return View(dogadjaj);
        }

        // GET: Dogadjaj/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj.FindAsync(id);
            if (dogadjaj == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", dogadjaj.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", dogadjaj.UstanovaId);
            return View(dogadjaj);
        }

        // POST: Dogadjaj/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DogadjajId,UstanovaId,KorisnikId,kapacitet,cijena,datumDogadjaja,trenutniKapacitet")] Dogadjaj dogadjaj)
        {
            if (id != dogadjaj.DogadjajId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dogadjaj);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DogadjajExists(dogadjaj.DogadjajId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", dogadjaj.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", dogadjaj.UstanovaId);
            return View(dogadjaj);
        }

        // GET: Dogadjaj/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dogadjaj = await _context.Dogadjaj
                .Include(d => d.Korisnik)
                .Include(d => d.Ustanova)
                .FirstOrDefaultAsync(m => m.DogadjajId == id);
            if (dogadjaj == null)
            {
                return NotFound();
            }

            return View(dogadjaj);
        }

        // POST: Dogadjaj/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dogadjaj = await _context.Dogadjaj.FindAsync(id);
            _context.Dogadjaj.Remove(dogadjaj);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DogadjajExists(int id)
        {
            return _context.Dogadjaj.Any(e => e.DogadjajId == id);
        }
    }
}
