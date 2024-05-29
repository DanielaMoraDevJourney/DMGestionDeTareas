using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DMGestionDeTareas.Models;

namespace DMGestionDeTareas.Controllers
{
    public class DMTareasController : Controller
    {
        private readonly DMGestionDeTareasContext _context;

        public DMTareasController(DMGestionDeTareasContext context)
        {
            _context = context;
        }

        // GET: DMTareas
        public async Task<IActionResult> Index()
        {
            var dMGestionDeTareasContext = _context.DMTarea.Include(d => d.DMCategoria).Include(d => d.DMPrioridad);
            return View(await dMGestionDeTareasContext.ToListAsync());
        }

        // GET: DMTareas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea
                .Include(d => d.DMCategoria)
                .Include(d => d.DMPrioridad)
                .FirstOrDefaultAsync(m => m.DMTareaId == id);
            if (dMTarea == null)
            {
                return NotFound();
            }

            return View(dMTarea);
        }

        // GET: DMTareas/Create
        public IActionResult Create()
        {
            ViewData["DMCategoriaId"] = new SelectList(_context.DMCategoria, "DMCategoriaId", "DMNombre");
            ViewData["DMPrioridadId"] = new SelectList(_context.DMPrioridad, "DMPrioridadId", "DMPrioridadId");
            return View();
        }

        // POST: DMTareas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DMTareaId,DMTitulo,DMDescripcion,DMFechaVencimiento,DMPrioridadId,DMCategoriaId")] DMTarea dMTarea)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMTarea);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["DMCategoriaId"] = new SelectList(_context.DMCategoria, "DMCategoriaId", "DMNombre", dMTarea.DMCategoriaId);
            ViewData["DMPrioridadId"] = new SelectList(_context.DMPrioridad, "DMPrioridadId", "DMPrioridadId", dMTarea.DMPrioridadId);
            return View(dMTarea);
        }

        // GET: DMTareas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea.FindAsync(id);
            if (dMTarea == null)
            {
                return NotFound();
            }
            ViewData["DMCategoriaId"] = new SelectList(_context.DMCategoria, "DMCategoriaId", "DMNombre", dMTarea.DMCategoriaId);
            ViewData["DMPrioridadId"] = new SelectList(_context.DMPrioridad, "DMPrioridadId", "DMPrioridadId", dMTarea.DMPrioridadId);
            return View(dMTarea);
        }

        // POST: DMTareas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DMTareaId,DMTitulo,DMDescripcion,DMFechaVencimiento,DMPrioridadId,DMCategoriaId")] DMTarea dMTarea)
        {
            if (id != dMTarea.DMTareaId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMTarea);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMTareaExists(dMTarea.DMTareaId))
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
            ViewData["DMCategoriaId"] = new SelectList(_context.DMCategoria, "DMCategoriaId", "DMNombre", dMTarea.DMCategoriaId);
            ViewData["DMPrioridadId"] = new SelectList(_context.DMPrioridad, "DMPrioridadId", "DMPrioridadId", dMTarea.DMPrioridadId);
            return View(dMTarea);
        }

        // GET: DMTareas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMTarea = await _context.DMTarea
                .Include(d => d.DMCategoria)
                .Include(d => d.DMPrioridad)
                .FirstOrDefaultAsync(m => m.DMTareaId == id);
            if (dMTarea == null)
            {
                return NotFound();
            }

            return View(dMTarea);
        }

        // POST: DMTareas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMTarea = await _context.DMTarea.FindAsync(id);
            if (dMTarea != null)
            {
                _context.DMTarea.Remove(dMTarea);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMTareaExists(int id)
        {
            return _context.DMTarea.Any(e => e.DMTareaId == id);
        }
    }
}
