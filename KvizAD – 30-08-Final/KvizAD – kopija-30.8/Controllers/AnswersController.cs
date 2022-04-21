using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KvizAD.DbModels;

namespace KvizAD.Controllers
{
    public class AnswersController : Controller
    {
        private readonly KvizAnaDContext _context;

        public AnswersController(KvizAnaDContext context)
        {
            _context = context;
        }

        // GET: Answers
        public async Task<IActionResult> Index()
        {
            var kvizAnaDContext = _context.Odgovori.Include(o => o.Pitanja);
            return View(await kvizAnaDContext.ToListAsync());
        }

        // GET: Answers/Create
        [KvizAD.Startup.SessionAdminTimeout]
        public IActionResult Create()
        {
            // za dodavanje odgovora na temelju vec postojecih pitanja (asp-control="Answers" asp-action="Create"
            ViewData["PitanjaId"] = new SelectList(_context.Pitanja, "PitanjaId", "PitanjaId");
            return View();
        }

        // POST: Answers/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [KvizAD.Startup.SessionAdminTimeout]
        public async Task<IActionResult> Create([Bind("OdgovoriId,Text,PitanjaId,IsCorect")] Odgovori odgovori)
        {
            if (ModelState.IsValid)
            {
                _context.Add(odgovori);
                await _context.SaveChangesAsync();
                return RedirectToAction("Pitanja", "Pitanja");
            }
            ViewData["PitanjaId"] = new SelectList(_context.Pitanja, "PitanjaId", "PitanjaId", odgovori.PitanjaId);
            return View(odgovori);
        }

        // GET: Answers/Edit/5
        [KvizAD.Startup.SessionAdminTimeout]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovori = await _context.Odgovori.FindAsync(id);
            if (odgovori == null)
            {
                return NotFound();
            }
            ViewData["PitanjaId"] = new SelectList(_context.Pitanja, "PitanjaId", "Text", odgovori.PitanjaId); //izbornik da se odg pridoda drugom pitanju
            return View(odgovori);
        }

        // POST: Answers/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [KvizAD.Startup.SessionAdminTimeout]
        public async Task<IActionResult> Edit(int id, [Bind("OdgovoriId,Text,PitanjaId,IsCorect")] Odgovori odgovori)
        {
            if (id != odgovori.OdgovoriId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(odgovori);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OdgovoriExists(odgovori.OdgovoriId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Pitanja", "Pitanja");
            }
            ViewData["PitanjaId"] = new SelectList(_context.Pitanja, "PitanjaId", "PitanjaId", odgovori.PitanjaId);
            return View(odgovori);
        }

        // GET: Answers/Delete/5
        [KvizAD.Startup.SessionAdminTimeout] //nije korišteno
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var odgovori = await _context.Odgovori
                .Include(o => o.Pitanja)
                .FirstOrDefaultAsync(m => m.OdgovoriId == id);
            if (odgovori == null)
            {
                return NotFound();
            }

            return View(odgovori);
        }

        // POST: Answers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [KvizAD.Startup.SessionAdminTimeout]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var odgovori = await _context.Odgovori.FindAsync(id);
            _context.Odgovori.Remove(odgovori);
            await _context.SaveChangesAsync();
            return RedirectToAction("Pitanja", "Pitanja");
        }

        private bool OdgovoriExists(int id)
        {
            return _context.Odgovori.Any(e => e.OdgovoriId == id);
        }
    }
}
