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
    public class TipFizickogLicaController : Controller
    {
        private readonly EMContext _context;

        public TipFizickogLicaController(EMContext context)
        {
            _context = context;
        }

        // GET: TipFizickogLica
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipFizickogLica.ToListAsync());
        }

        // GET: TipFizickogLica/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipFizickogLica = await _context.TipFizickogLica
                .FirstOrDefaultAsync(m => m.TipFizickogLicaId == id);
            if (tipFizickogLica == null)
            {
                return NotFound();
            }

            return View(tipFizickogLica);
        }

        // GET: TipFizickogLica/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipFizickogLica/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipFizickogLicaId,popust")] TipFizickogLica tipFizickogLica)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipFizickogLica);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipFizickogLica);
        }

        // GET: TipFizickogLica/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipFizickogLica = await _context.TipFizickogLica.FindAsync(id);
            if (tipFizickogLica == null)
            {
                return NotFound();
            }
            return View(tipFizickogLica);
        }

        // POST: TipFizickogLica/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipFizickogLicaId,popust")] TipFizickogLica tipFizickogLica)
        {
            if (id != tipFizickogLica.TipFizickogLicaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipFizickogLica);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipFizickogLicaExists(tipFizickogLica.TipFizickogLicaId))
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
            return View(tipFizickogLica);
        }

        // GET: TipFizickogLica/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipFizickogLica = await _context.TipFizickogLica
                .FirstOrDefaultAsync(m => m.TipFizickogLicaId == id);
            if (tipFizickogLica == null)
            {
                return NotFound();
            }

            return View(tipFizickogLica);
        }

        // POST: TipFizickogLica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipFizickogLica = await _context.TipFizickogLica.FindAsync(id);
            _context.TipFizickogLica.Remove(tipFizickogLica);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipFizickogLicaExists(int id)
        {
            return _context.TipFizickogLica.Any(e => e.TipFizickogLicaId == id);
        }
    }
}
