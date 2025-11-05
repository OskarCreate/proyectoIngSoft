using Microsoft.AspNetCore.Mvc;
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

        // GET: Obtener modal parcial
        [HttpGet]
        public IActionResult EditarDescanso(int id)
        {
            var descanso = _context.DbSetDescanso.FirstOrDefault(d => d.IdDescanso == id);

            if (descanso == null)
                return Content("Descanso no encontrado.");

            return PartialView("_EditarDescansoModal", descanso);
        }

        // POST: Guardar cambios
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditarDescanso(int IdDescanso, DateTime FechaIni, DateTime FechaFin)
        {
            var descansoDb = _context.DbSetDescanso.FirstOrDefault(d => d.IdDescanso == IdDescanso);
            if (descansoDb == null)
                return Json(new { success = false, message = "Descanso no encontrado." });

            try
            {
                // Convertir fechas a UTC para PostgreSQL
                descansoDb.FechaIni = DateTime.SpecifyKind(FechaIni, DateTimeKind.Utc);
                descansoDb.FechaFin = DateTime.SpecifyKind(FechaFin, DateTimeKind.Utc);

                _context.SaveChanges();

                return Json(new { success = true, message = "Descanso médico actualizado correctamente." });
            }
            catch (Exception ex)
            {
                // Captura de errores detallados
                return Json(new { success = false, message = "Error al guardar: " + ex.Message });
            }
        }
    }
}
