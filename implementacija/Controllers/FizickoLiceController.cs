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
    public class FizickoLiceController : Controller
    {
        private readonly EMContext _context;

        public FizickoLiceController(EMContext context)
        {
            _context = context;
        }

        // GET: FizickoLice
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.FizickoLice.Include(f => f.Korisnik);
            return View(await eMContext.ToListAsync());
        }

        // GET: FizickoLice/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fizickoLice = await _context.FizickoLice
                .Include(f => f.Korisnik)
                .FirstOrDefaultAsync(m => m.FizickoLiceId == id);
            if (fizickoLice == null)
            {
                return NotFound();
            }

            return View(fizickoLice);
        }

        // GET: FizickoLice/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: FizickoLice/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("FizickoLiceId,KorisnikId,ime,prezime,brojKartice,datumRodjenja,tipFizickogLica,VIP,stanjeRacuna,odgovornoLice")] FizickoLice fizickoLice)
        {
            if (ModelState.IsValid)
            {
                _context.Add(fizickoLice);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", fizickoLice.KorisnikId);
            return View(fizickoLice);
        }

        // GET: FizickoLice/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fizickoLice = await _context.FizickoLice.FindAsync(id);
            if (fizickoLice == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", fizickoLice.KorisnikId);
            return View(fizickoLice);
        }

        // POST: FizickoLice/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("FizickoLiceId,KorisnikId,ime,prezime,brojKartice,datumRodjenja,tipFizickogLica,VIP,stanjeRacuna,odgovornoLice")] FizickoLice fizickoLice)
        {
            if (id != fizickoLice.FizickoLiceId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(fizickoLice);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FizickoLiceExists(fizickoLice.FizickoLiceId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", fizickoLice.KorisnikId);
            return View(fizickoLice);
        }

        // GET: FizickoLice/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fizickoLice = await _context.FizickoLice
                .Include(f => f.Korisnik)
                .FirstOrDefaultAsync(m => m.FizickoLiceId == id);
            if (fizickoLice == null)
            {
                return NotFound();
            }

            return View(fizickoLice);
        }

        // POST: FizickoLice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var fizickoLice = await _context.FizickoLice.FindAsync(id);
            _context.FizickoLice.Remove(fizickoLice);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FizickoLiceExists(int id)
        {
            return _context.FizickoLice.Any(e => e.FizickoLiceId == id);
        }
    }
}
