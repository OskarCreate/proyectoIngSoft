using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;
using System.Collections.Generic;
using System.Linq;

namespace proyectoIngSoft.Controllers
{
    public class HU15Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public HU15Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: HU15/Index - Vista principal mostrando todos los descansos
        public IActionResult Index()
        {
            var descansosList = _context.DbSetDescanso
                                        .Include(d => d.DocumentosMedicos)
                                        .Include(d => d.User)
                                        .ToList();

            var model = descansosList.Select(d => new DescansoViewModel
            {
                IdDescanso = d.IdDescanso,
                DNI = d.User?.Dni ?? "",
                NombreCompleto = d.User != null ? $"{d.User.Username} {d.User.Apellidos}" : "",
                RazonDescanso = d.RazonDescanso,
                FechaIni = d.FechaIni,
                FechaFin = d.FechaFin,
                EstadoSubsidioA = d.EstadoSubsidioA,
                TipoDescansoId = d.TipoDescansoId,
                DocumentosMedicos = d.DocumentosMedicos?.ToList() ?? new List<DocumentoMedico>()

            }).ToList();

            return View("~/Views/HU15/Index.cshtml", model);
        }

        // GET: Mostrar modal de documentos de un trabajador
        public IActionResult VerDocumentosTrabajador(int descansoId)
        {
            var descanso = _context.DbSetDescanso
                                   .Include(d => d.DocumentosMedicos)
                                   .Include(d => d.User)
                                   .FirstOrDefault(d => d.IdDescanso == descansoId);

            if (descanso == null)
                return Content("Descanso no encontrado.");

            var documentos = descanso.DocumentosMedicos.ToList();

            ViewBag.DescansoId = descansoId;
            ViewBag.NombreCompleto = descanso.User != null 
                ? $"{descanso.User.Username} {descanso.User.Apellidos}" 
                : "N/A";

            return PartialView("_DocumentosModal", documentos);
        }

        // GET: Detectar documentos incompletos
        public IActionResult DetectarIncompletos(int descansoId)
        {
            var descanso = _context.DbSetDescanso
                                   .Include(d => d.DocumentosMedicos)
                                   .FirstOrDefault(d => d.IdDescanso == descansoId);

            if (descanso == null)
                return Json(new { success = false, message = "Descanso no encontrado." });

            var documentosRequeridos = new List<string>();
            switch (descanso.TipoDescansoId)
            {
                case 1: documentosRequeridos.Add("CertificadoMedico.pdf"); break;
                case 2: documentosRequeridos.Add("CertificadoMaternidad.pdf"); break;
                case 3: documentosRequeridos.Add("CertificadoPaternidad.pdf"); break;
            }

            var documentosSubidos = descanso.DocumentosMedicos.Select(d => d.Nombre).ToList();
            var faltantes = documentosRequeridos.Except(documentosSubidos).ToList();

            return Json(new { success = true, documentosFaltantes = faltantes });
        }

        // POST: Eliminar documentos seleccionados
        [HttpPost]
        public IActionResult EliminarDocumentos(List<int> documentosSeleccionados)
        {
            if (documentosSeleccionados == null || !documentosSeleccionados.Any())
                return Json(new { success = false, message = "No se seleccionaron documentos." });

            foreach (var id in documentosSeleccionados)
            {
                var doc = _context.DocumentosMedicos.Find(id);
                if (doc != null)
                    _context.DocumentosMedicos.Remove(doc);
            }

            _context.SaveChanges();
            return Json(new { success = true, message = "Documentos eliminados correctamente." });
        }

        // GET: Ver documento en nueva pestaña
        public IActionResult VerDocumento(int id)
        {
            var doc = _context.DocumentosMedicos.Find(id);
            if (doc == null || doc.Archivo == null)
                return Content("Documento no encontrado.");

            return File(doc.Archivo, "application/pdf"); // Cambia MIME si no es PDF
        }

        // GET: Descargar documento
        public IActionResult DownloadDocumento(int id)
        {
            var doc = _context.DocumentosMedicos.Find(id);
            if (doc == null || doc.Archivo == null)
                return Content("Documento no encontrado.");

            return File(doc.Archivo, "application/octet-stream", doc.Nombre);
        }

        // GET: Controlar duplicados
        public IActionResult ControlarDuplicados(int descansoId)
        {
            var descanso = _context.DbSetDescanso
                                   .Include(d => d.DocumentosMedicos)
                                   .FirstOrDefault(d => d.IdDescanso == descansoId);

            if (descanso == null)
                return Json(new { success = false, message = "Descanso no encontrado." });

            var duplicados = descanso.DocumentosMedicos
                                     .GroupBy(d => d.Nombre)
                                     .Where(g => g.Count() > 1)
                                     .Select(g => g.Key)
                                     .ToList();

            return Json(new { success = true, documentosDuplicados = duplicados });
        }
    }
}
