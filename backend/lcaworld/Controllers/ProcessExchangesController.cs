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
    public class ProcessExchangesController : Controller
    {
        private readonly LcaContext _context;

        public ProcessExchangesController(LcaContext context)
        {
            _context = context;
        }

        // GET: ProcessExchanges
        public async Task<IActionResult> Index()
        {
            var lcaContext = _context.ProcessExchanges.Include(p => p.ElementaryFlow).Include(p => p.Process);
            return View(await lcaContext.ToListAsync());
        }

        // GET: ProcessExchanges/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processExchanges = await _context.ProcessExchanges
                .Include(p => p.ElementaryFlow)
                .Include(p => p.Process)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processExchanges == null)
            {
                return NotFound();
            }

            return View(processExchanges);
        }

        // GET: ProcessExchanges/Create
        public IActionResult Create()
        {
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name");
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Name");
            return View();
        }

        // POST: ProcessExchanges/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ProcessId,ElementaryFlowId,Value")] ProcessExchanges processExchanges)
        {
            if (ModelState.IsValid)
            {
                _context.Add(processExchanges);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", processExchanges.ElementaryFlowId);
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Name", processExchanges.ProcessId);
            return View(processExchanges);
        }

        // GET: ProcessExchanges/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processExchanges = await _context.ProcessExchanges.FindAsync(id);
            if (processExchanges == null)
            {
                return NotFound();
            }
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", processExchanges.ElementaryFlowId);
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Name", processExchanges.ProcessId);
            return View(processExchanges);
        }

        // POST: ProcessExchanges/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ProcessId,ElementaryFlowId,Value")] ProcessExchanges processExchanges)
        {
            if (id != processExchanges.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(processExchanges);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessExchangesExists(processExchanges.Id))
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
            ViewData["ElementaryFlowId"] = new SelectList(_context.ElementaryFlows, "Id", "Name", processExchanges.ElementaryFlowId);
            ViewData["ProcessId"] = new SelectList(_context.Processes, "Id", "Name", processExchanges.ProcessId);
            return View(processExchanges);
        }

        // GET: ProcessExchanges/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var processExchanges = await _context.ProcessExchanges
                .Include(p => p.ElementaryFlow)
                .Include(p => p.Process)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (processExchanges == null)
            {
                return NotFound();
            }

            return View(processExchanges);
        }

        // POST: ProcessExchanges/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var processExchanges = await _context.ProcessExchanges.FindAsync(id);
            _context.ProcessExchanges.Remove(processExchanges);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessExchangesExists(int id)
        {
            return _context.ProcessExchanges.Any(e => e.Id == id);
        }
    }
}
