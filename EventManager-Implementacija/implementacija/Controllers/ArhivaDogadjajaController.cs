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
    public class ArhivaDogadjajaController : Controller
    {
        private readonly EMContext _context;

        public ArhivaDogadjajaController(EMContext context)
        {
            _context = context;
        }

        // GET: ArhivaDogadjaja
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.ArhivaDogadjaja.Include(a => a.Korisnik).Include(a => a.Ustanova);
            return View(await eMContext.ToListAsync());
        }

        // GET: ArhivaDogadjaja/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaDogadjaja = await _context.ArhivaDogadjaja
                .Include(a => a.Korisnik)
                .Include(a => a.Ustanova)
                .FirstOrDefaultAsync(m => m.ArhivaDogadjajaId == id);
            if (arhivaDogadjaja == null)
            {
                return NotFound();
            }

            return View(arhivaDogadjaja);
        }

        // GET: ArhivaDogadjaja/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId");
            return View();
        }

        // POST: ArhivaDogadjaja/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ArhivaDogadjajaId,KorisnikId,UstanovaId,cijenaRezervacije,popust,iznosPopusta,DogadjajId")] ArhivaDogadjaja arhivaDogadjaja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(arhivaDogadjaja);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaDogadjaja.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", arhivaDogadjaja.UstanovaId);
            return View(arhivaDogadjaja);
        }

        // GET: ArhivaDogadjaja/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaDogadjaja = await _context.ArhivaDogadjaja.FindAsync(id);
            if (arhivaDogadjaja == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaDogadjaja.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", arhivaDogadjaja.UstanovaId);
            return View(arhivaDogadjaja);
        }

        // POST: ArhivaDogadjaja/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ArhivaDogadjajaId,KorisnikId,UstanovaId,cijenaRezervacije,popust,iznosPopusta,DogadjajId")] ArhivaDogadjaja arhivaDogadjaja)
        {
            if (id != arhivaDogadjaja.ArhivaDogadjajaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(arhivaDogadjaja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArhivaDogadjajaExists(arhivaDogadjaja.ArhivaDogadjajaId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", arhivaDogadjaja.KorisnikId);
            ViewData["UstanovaId"] = new SelectList(_context.Ustanova, "UstanovaId", "UstanovaId", arhivaDogadjaja.UstanovaId);
            return View(arhivaDogadjaja);
        }

        // GET: ArhivaDogadjaja/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var arhivaDogadjaja = await _context.ArhivaDogadjaja
                .Include(a => a.Korisnik)
                .Include(a => a.Ustanova)
                .FirstOrDefaultAsync(m => m.ArhivaDogadjajaId == id);
            if (arhivaDogadjaja == null)
            {
                return NotFound();
            }

            return View(arhivaDogadjaja);
        }

        // POST: ArhivaDogadjaja/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var arhivaDogadjaja = await _context.ArhivaDogadjaja.FindAsync(id);
            _context.ArhivaDogadjaja.Remove(arhivaDogadjaja);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ArhivaDogadjajaExists(int id)
        {
            return _context.ArhivaDogadjaja.Any(e => e.ArhivaDogadjajaId == id);
        }
    }
}
