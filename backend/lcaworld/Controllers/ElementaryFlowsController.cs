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
    public class ElementaryFlowsController : Controller
    {
        private readonly LcaContext _context;

        public ElementaryFlowsController(LcaContext context)
        {
            _context = context;
        }

        // GET: ElementaryFlows
        public async Task<IActionResult> Index()
        {
            var lcaContext = _context.ElementaryFlows.Include(e => e.Compartment).Include(e => e.SubCompartment).Include(e => e.Unit);
            return View(await lcaContext.ToListAsync());
        }

        // GET: ElementaryFlows/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementaryFlow = await _context.ElementaryFlows
                .Include(e => e.Compartment)
                .Include(e => e.SubCompartment)
                .Include(e => e.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementaryFlow == null)
            {
                return NotFound();
            }

            return View(elementaryFlow);
        }

        // GET: ElementaryFlows/Create
        public IActionResult Create()
        {
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name");
            ViewData["SubCompartmentId"] = new SelectList(_context.SubCompartments, "Id", "Name");
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name");
            return View();
        }

        // POST: ElementaryFlows/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,CompartmentId,SubCompartmentId,UnitId")] ElementaryFlow elementaryFlow)
        {
            if (ModelState.IsValid)
            {
                _context.Add(elementaryFlow);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", elementaryFlow.CompartmentId);
            ViewData["SubCompartmentId"] = new SelectList(_context.SubCompartments, "Id", "Name", elementaryFlow.SubCompartmentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", elementaryFlow.UnitId);
            return View(elementaryFlow);
        }

        // GET: ElementaryFlows/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementaryFlow = await _context.ElementaryFlows.FindAsync(id);
            if (elementaryFlow == null)
            {
                return NotFound();
            }
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", elementaryFlow.CompartmentId);
            ViewData["SubCompartmentId"] = new SelectList(_context.SubCompartments, "Id", "Name", elementaryFlow.SubCompartmentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", elementaryFlow.UnitId);
            return View(elementaryFlow);
        }

        // POST: ElementaryFlows/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,CompartmentId,SubCompartmentId,UnitId")] ElementaryFlow elementaryFlow)
        {
            if (id != elementaryFlow.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(elementaryFlow);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ElementaryFlowExists(elementaryFlow.Id))
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
            ViewData["CompartmentId"] = new SelectList(_context.Compartments, "Id", "Name", elementaryFlow.CompartmentId);
            ViewData["SubCompartmentId"] = new SelectList(_context.SubCompartments, "Id", "Name", elementaryFlow.SubCompartmentId);
            ViewData["UnitId"] = new SelectList(_context.Units, "Id", "Name", elementaryFlow.UnitId);
            return View(elementaryFlow);
        }

        // GET: ElementaryFlows/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var elementaryFlow = await _context.ElementaryFlows
                .Include(e => e.Compartment)
                .Include(e => e.SubCompartment)
                .Include(e => e.Unit)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (elementaryFlow == null)
            {
                return NotFound();
            }

            return View(elementaryFlow);
        }

        // POST: ElementaryFlows/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var elementaryFlow = await _context.ElementaryFlows.FindAsync(id);
            _context.ElementaryFlows.Remove(elementaryFlow);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ElementaryFlowExists(int id)
        {
            return _context.ElementaryFlows.Any(e => e.Id == id);
        }
    }
}
