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
    
    public class ListaController : Controller
    {
        private readonly ILogger<ListaController> _logger;

        private readonly ApplicationDbContext _context;

        public ListaController(ILogger<ListaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }
        

        

        public IActionResult Index()
        {
            var usuarios = _context.DbSetUser.ToList(); // T_Usuarios
            return View("Index", usuarios);
 
        }

        // Acción que muestra detalles de un usuario
        public IActionResult Detalles(int id)
        {
            var usuario = _context.DbSetUser.FirstOrDefault(u => u.Id == id);

            if (usuario == null)
            {
                return NotFound();
            }

            return View(usuario); // Envía el usuario a la vista Detalles.cshtml
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}