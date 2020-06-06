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
    public class TransakcijaController : Controller
    {
        private readonly EMContext _context;

        public TransakcijaController(EMContext context)
        {
            _context = context;
        }

        // GET: Transakcija
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Transakcija.Include(t => t.Korisnik).Include(t => t.NacinPlacanja);
            return View(await eMContext.ToListAsync());
        }

        // GET: Transakcija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija
                .Include(t => t.Korisnik)
                .Include(t => t.NacinPlacanja)
                .FirstOrDefaultAsync(m => m.TransakcijaId == id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        // GET: Transakcija/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanja, "NacinPlacanjaId", "NacinPlacanjaId");
            return View();
        }

        // POST: Transakcija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TransakcijaId,KorisnikId,ukupnoZaUplatu,NacinPlacanjaId")] Transakcija transakcija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(transakcija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", transakcija.KorisnikId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanja, "NacinPlacanjaId", "NacinPlacanjaId", transakcija.NacinPlacanjaId);
            return View(transakcija);
        }

        // GET: Transakcija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija.FindAsync(id);
            if (transakcija == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", transakcija.KorisnikId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanja, "NacinPlacanjaId", "NacinPlacanjaId", transakcija.NacinPlacanjaId);
            return View(transakcija);
        }

        // POST: Transakcija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TransakcijaId,KorisnikId,ukupnoZaUplatu,NacinPlacanjaId")] Transakcija transakcija)
        {
            if (id != transakcija.TransakcijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(transakcija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransakcijaExists(transakcija.TransakcijaId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", transakcija.KorisnikId);
            ViewData["NacinPlacanjaId"] = new SelectList(_context.NacinPlacanja, "NacinPlacanjaId", "NacinPlacanjaId", transakcija.NacinPlacanjaId);
            return View(transakcija);
        }

        // GET: Transakcija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var transakcija = await _context.Transakcija
                .Include(t => t.Korisnik)
                .Include(t => t.NacinPlacanja)
                .FirstOrDefaultAsync(m => m.TransakcijaId == id);
            if (transakcija == null)
            {
                return NotFound();
            }

            return View(transakcija);
        }

        // POST: Transakcija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var transakcija = await _context.Transakcija.FindAsync(id);
            _context.Transakcija.Remove(transakcija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TransakcijaExists(int id)
        {
            return _context.Transakcija.Any(e => e.TransakcijaId == id);
        }
    }
}
