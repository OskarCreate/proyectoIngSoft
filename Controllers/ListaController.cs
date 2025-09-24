using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
            var lista = _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.Accidente)
                .Select(d => new Lista
                {
                    Username = d.User.Username,
                    Apellidos = d.User.Apellidos,
                    Dni = d.User.Dni,
                    Observaciones = d.Accidente != null ? d.Accidente.Observaciones : "N/A",
                    FechaSolicitud = d.FechaSolicitud,
                    Estado = "En Proceso", // Puedes mapear según tu lógica
                    IdUser = d.User.IdUser
                })
                .ToList();

            return View("Index", lista);
 
        }

        public IActionResult DetalleDescanso(int id)
        {
            var descanso = _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.TipoDescanso)
                .Include(d => d.Accidente)
                .FirstOrDefault(d => d.UserId == id);

            if (descanso == null)
            {
                return NotFound();
            }

            var vm = new
            {
                NombreCompleto = descanso.User.Username + " " + descanso.User.Apellidos,
                Dni = descanso.User.Dni,
                TipoLicencia = descanso.TipoDescanso.Nombre, // Ej: "Maternidad", "Fallecimiento"
                Observacion = descanso.Accidente != null ? descanso.Accidente.Observaciones : "N/A",
                FechaRegistro = descanso.FechaSolicitud,
                Estado = "En Proceso" // luego lo puedes mapear a tu BD
            };

            return PartialView("_DetalleDescanso", vm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}