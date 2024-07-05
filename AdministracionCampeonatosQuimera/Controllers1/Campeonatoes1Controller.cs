using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AdministracionCampeonatosQuimera.Contexto;
using AdministracionCampeonatosQuimera.Models;

namespace AdministracionCampeonatosQuimera.Controllers
{
    public class Campeonatoes1Controller : Controller
    {
        private readonly MyContext _context;

        public Campeonatoes1Controller(MyContext context)
        {
            _context = context;
        }

        // GET: Campeonatoes1
        public async Task<IActionResult> Index()
        {
            return View(await _context.Campeonatos.ToListAsync());
        }

        // GET: Campeonatoes1/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campeonato == null)
            {
                return NotFound();
            }

            return View(campeonato);
        }

        // GET: Campeonatoes1/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Campeonatoes1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CantEquipos,CostoInscripcion,Disciplina,FechaRealizacion,Modalidad,Nombre")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(campeonato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(campeonato);
        }

        // GET: Campeonatoes1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos.FindAsync(id);
            if (campeonato == null)
            {
                return NotFound();
            }
            return View(campeonato);
        }

        // POST: Campeonatoes1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CantEquipos,CostoInscripcion,Disciplina,FechaRealizacion,Modalidad,Nombre")] Campeonato campeonato)
        {
            if (id != campeonato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(campeonato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CampeonatoExists(campeonato.Id))
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
            return View(campeonato);
        }

        // GET: Campeonatoes1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var campeonato = await _context.Campeonatos
                .FirstOrDefaultAsync(m => m.Id == id);
            if (campeonato == null)
            {
                return NotFound();
            }

            return View(campeonato);
        }

        // POST: Campeonatoes1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var campeonato = await _context.Campeonatos.FindAsync(id);
            if (campeonato != null)
            {
                _context.Campeonatos.Remove(campeonato);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CampeonatoExists(int id)
        {
            return _context.Campeonatos.Any(e => e.Id == id);
        }
    }
}
