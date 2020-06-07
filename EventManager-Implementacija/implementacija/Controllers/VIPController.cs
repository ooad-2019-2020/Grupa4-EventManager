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
    public class VIPController : Controller
    {
        private readonly EMContext _context;

        public VIPController(EMContext context)
        {
            _context = context;
        }

        // GET: VIP
        public async Task<IActionResult> Index()
        {
            var eMContext = _context.VIP.Include(v => v.Korisnik);
            return View(await eMContext.ToListAsync());
        }

        // GET: VIP/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIP
                .Include(v => v.Korisnik)
                .FirstOrDefaultAsync(m => m.VIPId == id);
            if (vIP == null)
            {
                return NotFound();
            }

            return View(vIP);
        }

        // GET: VIP/Create
        public IActionResult Create()
        {
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId");
            return View();
        }

        // POST: VIP/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VIPId,KorisnikId,ime,prezime,brojKartice,datumRodjenja,tipFizickogLica,stanjeRacuna,odgovornoLice,uplatioClanarinu,iznosClanarine,trajanjeClanarine,username,password,adresa,email")] VIP vIP)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vIP);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", vIP.KorisnikId);
            return View(vIP);
        }

        // GET: VIP/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIP.FindAsync(id);
            if (vIP == null)
            {
                return NotFound();
            }
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", vIP.KorisnikId);
            return View(vIP);
        }

        // POST: VIP/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VIPId,KorisnikId,ime,prezime,brojKartice,datumRodjenja,tipFizickogLica,stanjeRacuna,odgovornoLice,uplatioClanarinu,iznosClanarine,trajanjeClanarine,username,password,adresa,email")] VIP vIP)
        {
            if (id != vIP.VIPId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vIP);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VIPExists(vIP.VIPId))
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
            ViewData["KorisnikId"] = new SelectList(_context.Korisnik, "KorisnikId", "KorisnikId", vIP.KorisnikId);
            return View(vIP);
        }

        // GET: VIP/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vIP = await _context.VIP
                .Include(v => v.Korisnik)
                .FirstOrDefaultAsync(m => m.VIPId == id);
            if (vIP == null)
            {
                return NotFound();
            }

            return View(vIP);
        }

        // POST: VIP/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var vIP = await _context.VIP.FindAsync(id);
            _context.VIP.Remove(vIP);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VIPExists(int id)
        {
            return _context.VIP.Any(e => e.VIPId == id);
        }
    }
}
