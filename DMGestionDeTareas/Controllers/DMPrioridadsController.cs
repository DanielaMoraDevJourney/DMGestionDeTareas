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
    public class DMPrioridadsController : Controller
    {
        private readonly DMGestionDeTareasContext _context;

        public DMPrioridadsController(DMGestionDeTareasContext context)
        {
            _context = context;
        }

        // GET: DMPrioridads
        public async Task<IActionResult> Index()
        {
            return View(await _context.DMPrioridad.ToListAsync());
        }

        // GET: DMPrioridads/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMPrioridad = await _context.DMPrioridad
                .FirstOrDefaultAsync(m => m.DMPrioridadId == id);
            if (dMPrioridad == null)
            {
                return NotFound();
            }

            return View(dMPrioridad);
        }

        // GET: DMPrioridads/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DMPrioridads/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DMPrioridadId,DMNombre,DMDescripcion")] DMPrioridad dMPrioridad)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dMPrioridad);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dMPrioridad);
        }

        // GET: DMPrioridads/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMPrioridad = await _context.DMPrioridad.FindAsync(id);
            if (dMPrioridad == null)
            {
                return NotFound();
            }
            return View(dMPrioridad);
        }

        // POST: DMPrioridads/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("DMPrioridadId,DMNombre,DMDescripcion")] DMPrioridad dMPrioridad)
        {
            if (id != dMPrioridad.DMPrioridadId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dMPrioridad);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DMPrioridadExists(dMPrioridad.DMPrioridadId))
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
            return View(dMPrioridad);
        }

        // GET: DMPrioridads/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dMPrioridad = await _context.DMPrioridad
                .FirstOrDefaultAsync(m => m.DMPrioridadId == id);
            if (dMPrioridad == null)
            {
                return NotFound();
            }

            return View(dMPrioridad);
        }

        // POST: DMPrioridads/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dMPrioridad = await _context.DMPrioridad.FindAsync(id);
            if (dMPrioridad != null)
            {
                _context.DMPrioridad.Remove(dMPrioridad);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DMPrioridadExists(int id)
        {
            return _context.DMPrioridad.Any(e => e.DMPrioridadId == id);
        }
    }
}
