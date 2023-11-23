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
    public class UsuarioController : Controller
    {
        private readonly TableroDBContext _context;

        public UsuarioController(TableroDBContext context)
        {
            _context = context;
        }

        // GET: Usuario
        public async Task<IActionResult> Index()
        {
            return _context.Usuarios != null ?
                        View(await _context.Usuarios.ToListAsync()) :
                        Problem("Entity set 'TableroDBContext.Usuarios'  is null.");
        }

        // GET: Usuario/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // GET: Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Usuario/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        /*  [HttpPost]
          [ValidateAntiForgeryToken]
          public async Task<IActionResult> Create([Bind("IDUsuario,Nombre,Apellido,Institucion,Mail")] Usuario usuario)
          {
              if (ModelState.IsValid)
              {
                  _context.Add(usuario);
                  await _context.SaveChangesAsync();
                  return RedirectToAction(nameof(Index));
              }
              return View(usuario);
          }*/
        //ESTA MODIF PARA EL MAIL
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IDUsuario,Nombre,Apellido,Institucion,Mail")] Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                // Verificar si el correo electrónico ya existe en la base de datos
                var existeEmail = await _context.Usuarios.AnyAsync(u => u.Mail == usuario.Mail);
                if (existeEmail)
                {
                    // El correo electrónico ya está registrado
                    TempData["ErrorEmail"] = "El correo electrónico ya está registrado.";
                    return View(usuario);
                }

                // Agregar el usuario a la base de datos
                _context.Add(usuario);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(usuario);
        }

        // GET: Usuario/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        // POST: Usuario/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.

        //LO MISMO DE CREATE EN EL EDIT, CUESTION QUE NO PUEDA DUPLICAR MAIL SI EDITA
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IDUsuario,Nombre,Apellido,Institucion,Mail")] Usuario usuario)
        {
            if (id != usuario.IDUsuario)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {

                var existeEmail = await _context.Usuarios.AnyAsync(u => u.Mail == usuario.Mail && u.IDUsuario != id);
                if (existeEmail)
                {

                    TempData["ErrorEmail"] = "El correo electrónico ya está registrado.";
                }
                else
                {
                    try
                    {
                        _context.Update(usuario);
                        await _context.SaveChangesAsync();
                        return RedirectToAction(nameof(Index));
                    }
                    catch (DbUpdateConcurrencyException)
                    {
                        if (!UsuarioExists(usuario.IDUsuario))
                        {

                            return NotFound();

                        }
                        else
                        {
                            throw;
                        }
                    }
                }
            }
            return View(usuario);
        }

        // GET: Usuario/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Usuarios == null)
            {
                return NotFound();
            }

            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(m => m.IDUsuario == id);
            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        // POST: Usuario/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Usuarios == null)
            {
                return Problem("Entity set 'TableroDBContext.Usuarios'  is null.");
            }
            var usuario = await _context.Usuarios.FindAsync(id);
            if (usuario != null)
            {
                _context.Usuarios.Remove(usuario);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool UsuarioExists(int id)
        {
            return (_context.Usuarios?.Any(e => e.IDUsuario == id)).GetValueOrDefault();
        }
    }
}