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
    public class CharacterisationFactorsController : Controller
    {
        private readonly LcaContext _context;

        public CharacterisationFactorsController(LcaContext context)
        {
            _context = context;
        }

        // GET: CharacterisationFactor
        public async Task<IActionResult> Index()
        {
            var lcaContext = _context.CharacterisationFactors.Include(m => m.ElementaryFlow).Include(m => m.Method);
            return View(await lcaContext.ToListAsync());
        }

        // GET: CharacterisationFactor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodFactors = await _context.CharacterisationFactors
                .Include(m => m.ElementaryFlow)
                .Include(m => m.Method)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodFactors == null)
            {
                return NotFound();
            }

            return View(methodFactors);
        }

        // GET: CharacterisationFactor/Create
        public IActionResult Create()
        {
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name");
            ViewData["MethodId"] = new SelectList(_context.Set<Method>(), "Id", "Name");
            return View();
        }

        // POST: CharacterisationFactor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,MethodId,ElementaryFlowId,Factor")] CharacterisationFactor methodFactors)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodFactors);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", methodFactors.ElementaryFlowId);
            ViewData["MethodId"] = new SelectList(_context.Set<Method>(), "Id", "Name", methodFactors.MethodId);
            return View(methodFactors);
        }

        // GET: CharacterisationFactor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodFactors = await _context.CharacterisationFactors.FindAsync(id);
            if (methodFactors == null)
            {
                return NotFound();
            }
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", methodFactors.ElementaryFlowId);
            ViewData["MethodId"] = new SelectList(_context.Set<Method>(), "Id", "Name", methodFactors.MethodId);
            return View(methodFactors);
        }

        // POST: CharacterisationFactor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,MethodId,ElementaryFlowId,Factor")] CharacterisationFactor methodFactors)
        {
            if (id != methodFactors.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodFactors);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodFactorsExists(methodFactors.Id))
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
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", methodFactors.ElementaryFlowId);
            ViewData["MethodId"] = new SelectList(_context.Set<Method>(), "Id", "Name", methodFactors.MethodId);
            return View(methodFactors);
        }

        // GET: CharacterisationFactor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodFactors = await _context.CharacterisationFactors
                .Include(m => m.ElementaryFlow)
                .Include(m => m.Method)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodFactors == null)
            {
                return NotFound();
            }

            return View(methodFactors);
        }

        // POST: CharacterisationFactor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var methodFactors = await _context.CharacterisationFactors.FindAsync(id);
            _context.CharacterisationFactors.Remove(methodFactors);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodFactorsExists(int id)
        {
            return _context.CharacterisationFactors.Any(e => e.Id == id);
        }
    }
}
