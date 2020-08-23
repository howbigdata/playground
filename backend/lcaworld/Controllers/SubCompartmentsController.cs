using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LcaWorld.Models;
using lcaworld.Db;

namespace lcaworld.Controllers
{
    public class SubCompartmentsController : Controller
    {
        private readonly LcaContext _context;

        public SubCompartmentsController(LcaContext context)
        {
            _context = context;
        }

        // GET: SubCompartments
        public async Task<IActionResult> Index()
        {
            var lcaContext = _context.SubCompartments.Include(s => s.Compartment);
            return View(await lcaContext.ToListAsync());
        }

        // GET: SubCompartments/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCompartment = await _context.SubCompartments
                .Include(s => s.Compartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCompartment == null)
            {
                return NotFound();
            }

            return View(subCompartment);
        }

        // GET: SubCompartments/Create
        public IActionResult Create()
        {
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name");
            return View();
        }

        // POST: SubCompartments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CompartmentId")] SubCompartment subCompartment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(subCompartment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", subCompartment.CompartmentId);
            return View(subCompartment);
        }

        // GET: SubCompartments/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCompartment = await _context.SubCompartments.FindAsync(id);
            if (subCompartment == null)
            {
                return NotFound();
            }
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", subCompartment.CompartmentId);
            return View(subCompartment);
        }

        // POST: SubCompartments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CompartmentId")] SubCompartment subCompartment)
        {
            if (id != subCompartment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(subCompartment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SubCompartmentExists(subCompartment.Id))
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
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", subCompartment.CompartmentId);
            return View(subCompartment);
        }

        // GET: SubCompartments/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var subCompartment = await _context.SubCompartments
                .Include(s => s.Compartment)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (subCompartment == null)
            {
                return NotFound();
            }

            return View(subCompartment);
        }

        // POST: SubCompartments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var subCompartment = await _context.SubCompartments.FindAsync(id);
            _context.SubCompartments.Remove(subCompartment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SubCompartmentExists(int id)
        {
            return _context.SubCompartments.Any(e => e.Id == id);
        }
    }
}
