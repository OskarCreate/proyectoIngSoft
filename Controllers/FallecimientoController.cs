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
  
    public class FallecimientoController : Controller
    {
        private readonly ILogger<FallecimientoController> _logger;
        private readonly ApplicationDbContext _context;

        public FallecimientoController(ILogger<FallecimientoController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
       
        public IActionResult Registrar(Fallecimiento fallecimiento)
        {
            if (ModelState.IsValid)
            {
                try
                {

                    _context.DbSetFallecimiento.Add(fallecimiento);
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
            return View("Index");
            

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}