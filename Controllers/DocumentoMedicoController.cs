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

        // Lista en memoria (se borra cuando apagas el proyecto)
        private static List<DocumentoMedico> _documentos = new List<DocumentoMedico>();

        public DocumentoMedicoController(ILogger<DocumentoMedicoController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(_documentos);
        }

        [HttpPost]
        public IActionResult Subir(List<IFormFile> archivos)
        {
            if (archivos == null || !archivos.Any())
            {
                ViewData["Message"] = "No se seleccionaron archivos.";
                return RedirectToAction("Index");
            }

            foreach (var archivo in archivos)
            {
                if (archivo.Length > 0)
                {
                    var doc = new DocumentoMedico
                    {
                        Nombre = archivo.FileName,
                        Tamaño = archivo.Length,
                        FechaSubida = DateTime.Now
                    };

                    _documentos.Add(doc);
                }
            }

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