using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore; // Necesario para Include
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;
using System;
using System.Linq;

namespace proyectoIngSoft.Controllers
{
    public class HU11Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public HU11Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Modal de edición
        [HttpGet]
        public IActionResult EditarDescanso(int id)
        {
            var descanso = _context.DbSetDescanso
    .Include(d => d.User)
    .Include(d => d.Accidente)
    .Include(d => d.Maternidad)
    .Include(d => d.Paternidad)
    .Include(d => d.Enfermedad)
    .Include(d => d.Fallecimiento)
    .Include(d => d.EnfermedadFam)
    .Include(d => d.TipoDescanso)
    .FirstOrDefault(d => d.IdDescanso == id);


            if (descanso == null)
                return NotFound();

            return PartialView("_EditarDescansoModal", descanso);
        }

        // POST: Guardar cambios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarDescanso(Descanso model)
        {
            if (!ModelState.IsValid)
                return PartialView("_EditarDescansoModal", model);

            var descansoDb = _context.DbSetDescanso
                .FirstOrDefault(d => d.IdDescanso == model.IdDescanso);

            if (descansoDb == null)
                return NotFound();

            // Actualizar campos editables
            descansoDb.FechaIni = model.FechaIni;
            descansoDb.FechaFin = model.FechaFin;
            descansoDb.EstadoESSALUD = model.EstadoESSALUD;
            descansoDb.EstadoSubsidioA = model.EstadoSubsidioA;
            descansoDb.EstadoSubsidioJ = model.EstadoSubsidioJ;

            // Registrar fecha de modificación
            descansoDb.FechaSolicitud = DateTime.Now;

            _context.SaveChanges();

            return Json(new { success = true, message = "Descanso médico actualizado correctamente." });
        }
    }
}
