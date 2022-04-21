using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using KvizAD.DbModels;
using Microsoft.AspNetCore.Mvc.Routing;

namespace KvizAD.Controllers
{
    public class QuestionsController : Controller
    {
        private readonly KvizAnaDContext _context;

        public QuestionsController(KvizAnaDContext context)
        {
            _context = context;
        }

        // GET: Questions
        public async Task<IActionResult> Index()
        {
            return View(await _context.Pitanja.ToListAsync());
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // GET: Questions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanja = await _context.Pitanja
                .FirstOrDefaultAsync(m => m.PitanjaId == id);
            if (pitanja == null)
            {
                return NotFound();
            }

            return View(pitanja);
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // GET: Questions/Create
        public IActionResult Create()
        {
            return View();
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // POST: Questions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PitanjaId,Text")] Pitanja pitanja)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pitanja);
                await _context.SaveChangesAsync();


                return RedirectToAction("Pitanja", "Pitanja");
            }
            return View(pitanja);
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // GET: Questions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanja = await _context.Pitanja.FindAsync(id);
            if (pitanja == null)
            {
                return NotFound();
            }
            return View(pitanja);
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // POST: Questions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PitanjaId,Text")] Pitanja pitanja)
        {
            if (id != pitanja.PitanjaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pitanja);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PitanjaExists(pitanja.PitanjaId))
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
            return View(pitanja);
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // GET: Questions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pitanja = await _context.Pitanja
                .FirstOrDefaultAsync(m => m.PitanjaId == id);
            if (pitanja == null)
            {
                return NotFound();
            }

            return View(pitanja);
        }

        [KvizAD.Startup.SessionAdminTimeout]
        // POST: Questions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pitanja = await _context.Pitanja.FindAsync(id);
            _context.Pitanja.Remove(pitanja);
            await _context.SaveChangesAsync();
            return RedirectToAction("Pitanja", "Pitanja");
        }

        private bool PitanjaExists(int id)
        {
            return _context.Pitanja.Any(e => e.PitanjaId == id);
        }
    }
}
