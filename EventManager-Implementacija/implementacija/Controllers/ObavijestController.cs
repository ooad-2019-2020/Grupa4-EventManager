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
    public class ObavijestController : Controller
    {
        private readonly EMContext _context;

        public ObavijestController(EMContext context)
        {
            _context = context;
        }

        // GET: Obavijest
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.Obavijest.Include(o => o.Korisnik).Include(o => o.VrstaObavijesti);
            return View(await eMContext.ToListAsync());
        }

        // GET: Obavijest/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest
                .Include(o => o.Korisnik)
                .Include(o => o.VrstaObavijesti)
                .FirstOrDefaultAsync(m => m.ObavijestId == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }

        // GET: Obavijest/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            ViewData["VrstaObavijestiId"] = new SelectList(_context.VrstaObavijesti, "VrstaObavijestiId", "VrstaObavijestiId");
            return View();
        }

        // POST: Obavijest/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ObavijestId,KorisnikId,tekstObavijesti,datumSlanja,VrstaObavijestiId")] Obavijest obavijest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(obavijest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", obavijest.KorisnikId);
            ViewData["VrstaObavijestiId"] = new SelectList(_context.VrstaObavijesti, "VrstaObavijestiId", "VrstaObavijestiId", obavijest.VrstaObavijestiId);
            return View(obavijest);
        }

        // GET: Obavijest/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest.FindAsync(id);
            if (obavijest == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", obavijest.KorisnikId);
            ViewData["VrstaObavijestiId"] = new SelectList(_context.VrstaObavijesti, "VrstaObavijestiId", "VrstaObavijestiId", obavijest.VrstaObavijestiId);
            return View(obavijest);
        }

        // POST: Obavijest/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ObavijestId,KorisnikId,tekstObavijesti,datumSlanja,VrstaObavijestiId")] Obavijest obavijest)
        {
            if (id != obavijest.ObavijestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(obavijest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ObavijestExists(obavijest.ObavijestId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", obavijest.KorisnikId);
            ViewData["VrstaObavijestiId"] = new SelectList(_context.VrstaObavijesti, "VrstaObavijestiId", "VrstaObavijestiId", obavijest.VrstaObavijestiId);
            return View(obavijest);
        }

        // GET: Obavijest/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var obavijest = await _context.Obavijest
                .Include(o => o.Korisnik)
                .Include(o => o.VrstaObavijesti)
                .FirstOrDefaultAsync(m => m.ObavijestId == id);
            if (obavijest == null)
            {
                return NotFound();
            }

            return View(obavijest);
        }

        // POST: Obavijest/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var obavijest = await _context.Obavijest.FindAsync(id);
            _context.Obavijest.Remove(obavijest);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ObavijestExists(int id)
        {
            return _context.Obavijest.Any(e => e.ObavijestId == id);
        }
    }
}
