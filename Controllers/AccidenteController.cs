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
    
    public class AccidenteController : Controller
    {
        private readonly ILogger<AccidenteController> _logger;
        private readonly ApplicationDbContext _context;

        public AccidenteController(ILogger<AccidenteController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: /Accidente/Index
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Registrar(Accidente model)
        {
            if (!ModelState.IsValid)
            {
                ViewData["Message"] = "Datos no válidos";
                return View("Index");
            }

            try
            {
                // 1. Guardar Accidente
                _context.DbSetAccidente.Add(model);
                _context.SaveChanges();

                // 2. Obtener usuario logueado (simulado)
                var user = _context.DbSetUser.First(); // ⚠️ cambiar por usuario en sesión

                // 3. Crear Descanso
                var descanso = new Descanso
                {
                    UserId = user.IdUser,               // FK a T_Usuarios
                    TipoDescansoId = 6,                 // 1 = Accidente
                    FechaSolicitud = DateTime.UtcNow,
                    AccidenteId = model.IdAccidente     // FK al Accidente recién creado
                };

                _context.DbSetDescanso.Add(descanso);
                _context.SaveChanges();

                ViewData["Message"] = "Accidente registrado con éxito";
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al registrar Accidente");
                ViewData["Message"] = "Error al registrar: " + ex.Message;
            }

            return View("Index");
        }
    }
}