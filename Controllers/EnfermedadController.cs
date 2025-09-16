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
    public class EnfermedadController : Controller
    {
        private readonly ILogger<EnfermedadController> _logger;
        private readonly ApplicationDbContext _context;

        public EnfermedadController(ILogger<EnfermedadController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Registrar(Enfermedad enfermedad)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.DbSetEnfermedad.Add(enfermedad);
                    _context.SaveChanges();
                    _logger.LogInformation("Descanso registrado exitosamente.");
                    ViewData["Message"] = "Se registró el descanso exitosamente.";

                }
                catch (Exception ex)
                {
                    _logger.LogError(ex, "Error al registrar el descanso.");
                    ViewData["Message"] = "Error al registrar el descanso: " + ex.Message;
                }
            }
            else
            {
                ViewData["Message"] = "Datos de entrada no válidos";
            }
            return RedirectToAction("Index", "DocumentoMedico");
            

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}