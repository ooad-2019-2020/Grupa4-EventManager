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
    public class RegistracijaController : Controller
    {
        private readonly EMContext _context;

        public RegistracijaController(EMContext context)
        {
            _context = context;
        }

        // GET: Registracija
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Registracija.Include(r => r.FizickoLice).Include(r => r.Korisnik).Include(r => r.Ustanova).Include(r => r.VIP);
            return View(await eMContext.ToListAsync());
        }

        // GET: Registracija/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registracija = await _context.Registracija
                .Include(r => r.FizickoLice)
                .Include(r => r.Korisnik)
                .Include(r => r.Ustanova)
                .Include(r => r.VIP)
                .FirstOrDefaultAsync(m => m.RegistracijaId == id);
            if (registracija == null)
            {
                return NotFound();
            }

            return View(registracija);
        }

        // GET: Registracija/Create
        public IActionResult Create()
        {
            ViewData["FizickoLiceId"] = new SelectList(_context.FizickoLice, "FizickoLiceId", "FizickoLiceId");
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId");
            ViewData["VIPId"] = new SelectList(_context.VIP, "VIPId", "VIPId");
            return View();
        }

        // POST: Registracija/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RegistracijaId,KorisnikId,FizickoLiceId,VIPId,UstanovaId")] Registracija registracija)
        {
            if (ModelState.IsValid)
            {
                _context.Add(registracija);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FizickoLiceId"] = new SelectList(_context.FizickoLice, "FizickoLiceId", "FizickoLiceId", registracija.FizickoLiceId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", registracija.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", registracija.UstanovaId);
            ViewData["VIPId"] = new SelectList(_context.VIP, "VIPId", "VIPId", registracija.VIPId);
            return View(registracija);
        }

        // GET: Registracija/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registracija = await _context.Registracija.FindAsync(id);
            if (registracija == null)
            {
                return NotFound();
            }
            ViewData["FizickoLiceId"] = new SelectList(_context.FizickoLice, "FizickoLiceId", "FizickoLiceId", registracija.FizickoLiceId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", registracija.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", registracija.UstanovaId);
            ViewData["VIPId"] = new SelectList(_context.VIP, "VIPId", "VIPId", registracija.VIPId);
            return View(registracija);
        }

        // POST: Registracija/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RegistracijaId,KorisnikId,FizickoLiceId,VIPId,UstanovaId")] Registracija registracija)
        {
            if (id != registracija.RegistracijaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(registracija);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistracijaExists(registracija.RegistracijaId))
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
            ViewData["FizickoLiceId"] = new SelectList(_context.FizickoLice, "FizickoLiceId", "FizickoLiceId", registracija.FizickoLiceId);
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", registracija.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", registracija.UstanovaId);
            ViewData["VIPId"] = new SelectList(_context.VIP, "VIPId", "VIPId", registracija.VIPId);
            return View(registracija);
        }

        // GET: Registracija/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registracija = await _context.Registracija
                .Include(r => r.FizickoLice)
                .Include(r => r.Korisnik)
                .Include(r => r.Ustanova)
                .Include(r => r.VIP)
                .FirstOrDefaultAsync(m => m.RegistracijaId == id);
            if (registracija == null)
            {
                return NotFound();
            }

            return View(registracija);
        }

        // POST: Registracija/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var registracija = await _context.Registracija.FindAsync(id);
            _context.Registracija.Remove(registracija);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RegistracijaExists(int id)
        {
            return _context.Registracija.Any(e => e.RegistracijaId == id);
        }
    }
}
