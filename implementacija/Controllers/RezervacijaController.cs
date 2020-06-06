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
    public class RezervacijaController : Controller
    {
        private readonly EMContext _context;

        public RezervacijaController(EMContext context)
        {
            _context = context;
        }

        // GET: Rezervacija
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Rezervacija.Include(r => r.Dogadjaj).Include(r => r.Ustanova).Include(r => r.VrstaKarte);
            return View(await eMContext.ToListAsync());
        }

        // GET: Rezervacija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Dogadjaj)
                .Include(r => r.Ustanova)
                .Include(r => r.VrstaKarte)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // GET: Rezervacija/Create
        public IActionResult Create()
        {
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId");
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId");
            ViewData["VrstaKarteId"] = new SelectList(_context.VrstaKarte, "VrstaKarteId", "VrstaKarteId");
            return View();
        }

        // POST: Rezervacija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RezervacijaId,osobaRezervacija,UstanovaId,DogadjajId,VrstaKarteId,cijena,brojRezervisanihMjesta,datumRezervacije,ukupnoZaUplatu,datumDogadjaja")] Rezervacija rezervacija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(rezervacija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", rezervacija.DogadjajId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", rezervacija.UstanovaId);
            ViewData["VrstaKarteId"] = new SelectList(_context.VrstaKarte, "VrstaKarteId", "VrstaKarteId", rezervacija.VrstaKarteId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija.FindAsync(id);
            if (rezervacija == null)
            {
                return NotFound();
            }
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", rezervacija.DogadjajId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", rezervacija.UstanovaId);
            ViewData["VrstaKarteId"] = new SelectList(_context.VrstaKarte, "VrstaKarteId", "VrstaKarteId", rezervacija.VrstaKarteId);
            return View(rezervacija);
        }

        // POST: Rezervacija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RezervacijaId,osobaRezervacija,UstanovaId,DogadjajId,VrstaKarteId,cijena,brojRezervisanihMjesta,datumRezervacije,ukupnoZaUplatu,datumDogadjaja")] Rezervacija rezervacija)
        {
            if (id != rezervacija.RezervacijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(rezervacija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RezervacijaExists(rezervacija.RezervacijaId))
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
            ViewData["DogadjajId"] = new SelectList(_context.Dogadjaj, "DogadjajId", "DogadjajId", rezervacija.DogadjajId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", rezervacija.UstanovaId);
            ViewData["VrstaKarteId"] = new SelectList(_context.VrstaKarte, "VrstaKarteId", "VrstaKarteId", rezervacija.VrstaKarteId);
            return View(rezervacija);
        }

        // GET: Rezervacija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var rezervacija = await _context.Rezervacija
                .Include(r => r.Dogadjaj)
                .Include(r => r.Ustanova)
                .Include(r => r.VrstaKarte)
                .FirstOrDefaultAsync(m => m.RezervacijaId == id);
            if (rezervacija == null)
            {
                return NotFound();
            }

            return View(rezervacija);
        }

        // POST: Rezervacija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var rezervacija = await _context.Rezervacija.FindAsync(id);
            _context.Rezervacija.Remove(rezervacija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RezervacijaExists(int id)
        {
            return _context.Rezervacija.Any(e => e.RezervacijaId == id);
        }
    }
}
