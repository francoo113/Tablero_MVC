using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tablero_MVC.Context;
using Tablero_MVC.Models;

namespace Tablero_MVC.Controllers
{
    public class TableroController : Controller
    {
        private readonly TableroDBContext _context;

        public TableroController(TableroDBContext context)
        {
            _context = context;
        }

        // GET: Tablero
        public async Task<IActionResult> Index()
        {
              return _context.Tableros != null ? 
                          View(await _context.Tableros.ToListAsync()) :
                          Problem("Entity set 'TableroDBContext.Tableros'  is null.");
        }

        // GET: Tablero/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Tableros == null)
            {
                return NotFound();
            }

            var tablero = await _context.Tableros
                .FirstOrDefaultAsync(m => m.IDTablero == id);
            if (tablero == null)
            {
                return NotFound();
            }

            return View(tablero);
        }

        // GET: Tablero/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tablero/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDTablero")] Tablero tablero)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tablero);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tablero);
        }

        // GET: Tablero/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Tableros == null)
            {
                return NotFound();
            }

            var tablero = await _context.Tableros.FindAsync(id);
            if (tablero == null)
            {
                return NotFound();
            }
            return View(tablero);
        }

        // POST: Tablero/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDTablero")] Tablero tablero)
        {
            if (id != tablero.IDTablero)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tablero);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TableroExists(tablero.IDTablero))
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
            return View(tablero);
        }

        // GET: Tablero/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Tableros == null)
            {
                return NotFound();
            }

            var tablero = await _context.Tableros
                .FirstOrDefaultAsync(m => m.IDTablero == id);
            if (tablero == null)
            {
                return NotFound();
            }

            return View(tablero);
        }

        // POST: Tablero/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Tableros == null)
            {
                return Problem("Entity set 'TableroDBContext.Tableros'  is null.");
            }
            var tablero = await _context.Tableros.FindAsync(id);
            if (tablero != null)
            {
                _context.Tableros.Remove(tablero);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TableroExists(int id)
        {
          return (_context.Tableros?.Any(e => e.IDTablero == id)).GetValueOrDefault();
        }
    }
}
