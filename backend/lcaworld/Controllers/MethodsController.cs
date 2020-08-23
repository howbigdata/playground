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
    public class MethodsController : Controller
    {
        private readonly LcaContext _context;

        public MethodsController(LcaContext context)
        {
            _context = context;
        }

        // GET: MethodHeaders
        public async Task<IActionResult> Index()
        {
            return View(await _context.Methods.ToListAsync());
        }

        // GET: MethodHeaders/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodHeader = await _context.Methods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodHeader == null)
            {
                return NotFound();
            }

            return View(methodHeader);
        }

        // GET: MethodHeaders/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: MethodHeaders/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Unit")] Method methodHeader)
        {
            if (ModelState.IsValid)
            {
                _context.Add(methodHeader);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(methodHeader);
        }

        // GET: MethodHeaders/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodHeader = await _context.Methods.FindAsync(id);
            if (methodHeader == null)
            {
                return NotFound();
            }
            return View(methodHeader);
        }

        // POST: MethodHeaders/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Unit")] Method methodHeader)
        {
            if (id != methodHeader.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(methodHeader);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MethodHeaderExists(methodHeader.Id))
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
            return View(methodHeader);
        }

        // GET: MethodHeaders/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var methodHeader = await _context.Methods
                .FirstOrDefaultAsync(m => m.Id == id);
            if (methodHeader == null)
            {
                return NotFound();
            }

            return View(methodHeader);
        }

        // POST: MethodHeaders/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var methodHeader = await _context.Methods.FindAsync(id);
            _context.Methods.Remove(methodHeader);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MethodHeaderExists(int id)
        {
            return _context.Methods.Any(e => e.Id == id);
        }
    }
}
