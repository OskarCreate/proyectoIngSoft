using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;

namespace proyectoIngSoft.Controllers
{
    public class DocumentoMedicoController : Controller
    {
        private readonly ILogger<DocumentoMedicoController> _logger;
        private readonly ApplicationDbContext _context;

        public DocumentoMedicoController(ILogger<DocumentoMedicoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var documentos = _context.DocumentosMedicos.ToList();
            return View(documentos);
        }

        [HttpPost]
        public IActionResult Subir(List<IFormFile> archivos)
        {
            if (archivos == null || !archivos.Any())
            {
                TempData["Message"] = "No se seleccionaron archivos.";
                return RedirectToAction("Index");
            }

            foreach (var archivo in archivos)
            {
                using (var stream = new MemoryStream())
                {
                    archivo.CopyTo(stream);
                    var doc = new DocumentoMedico
                    {
                        Nombre = archivo.FileName,
                        Tamaño = archivo.Length,
                        FechaSubida = DateTime.UtcNow,
                        Archivo = stream.ToArray() 
                    };

                    _context.DocumentosMedicos.Add(doc);
                }
            }

            _context.SaveChanges();
            TempData["Message"] = $"{archivos.Count} archivo(s) enviado(s) exitosamente.";
            return RedirectToAction("Index");
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}