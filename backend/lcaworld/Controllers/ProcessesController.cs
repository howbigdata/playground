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
    public class ProcessesController : Controller
    {
        private readonly LcaContext _context;

        public ProcessesController(LcaContext context)
        {
            _context = context;
        }

        // GET: ProcessMetas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Processes.ToListAsync());
        }

        // GET: ProcessMetas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Process = await _context.Processes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Process == null)
            {
                return NotFound();
            }

            return View(Process);
        }

        // GET: ProcessMetas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProcessMetas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name")] Process Process)
        {
            if (ModelState.IsValid)
            {
                _context.Add(Process);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Process);
        }

        // GET: ProcessMetas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Process = await _context.Processes.FindAsync(id);
            if (Process == null)
            {
                return NotFound();
            }
            return View(Process);
        }

        // POST: ProcessMetas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name")] Process Process)
        {
            if (id != Process.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(Process);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProcessMetaExists(Process.Id))
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
            return View(Process);
        }

        // GET: ProcessMetas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Process = await _context.Processes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (Process == null)
            {
                return NotFound();
            }

            return View(Process);
        }

        // POST: ProcessMetas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var Process = await _context.Processes.FindAsync(id);
            _context.Processes.Remove(Process);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProcessMetaExists(int id)
        {
            return _context.Processes.Any(e => e.Id == id);
        }
    }
}
