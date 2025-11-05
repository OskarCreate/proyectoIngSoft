using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;


namespace proyectoIngSoft.Controllers
{
    public class CalendarioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public CalendarioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /Calendario
        public IActionResult Index(int? año, int? mes)
        {
            var fechaActual = DateTime.Now;
            var añoSeleccionado = año ?? fechaActual.Year;
            var mesSeleccionado = mes ?? fechaActual.Month;

            ViewBag.AñoActual = añoSeleccionado;
            ViewBag.MesActual = mesSeleccionado;
            ViewBag.MesNombre = CultureInfo.CurrentCulture.DateTimeFormat.GetMonthName(mesSeleccionado);
            ViewBag.FechaActual = fechaActual;

            // Obtener eventos del mes
            var primerDiaMes = new DateTime(añoSeleccionado, mesSeleccionado, 1);
            var ultimoDiaMes = primerDiaMes.AddMonths(1).AddDays(-1);

            var eventos = _context.DbSetCalendarioEvento
                .Where(e => e.FechaInicio.Date <= ultimoDiaMes.Date && 
                           (e.FechaFin == null || e.FechaFin.Value.Date >= primerDiaMes.Date))
                .Include(e => e.User)
                .ToList();

            ViewBag.Eventos = eventos;

            return View();
        }

        // GET: /Calendario/GetEventosDia
        public JsonResult GetEventosDia(int año, int mes, int dia)
        {
            var fecha = new DateTime(año, mes, dia);
            var eventos = _context.DbSetCalendarioEvento
                .Where(e => e.FechaInicio.Date <= fecha.Date && 
                           (e.FechaFin == null || e.FechaFin.Value.Date >= fecha.Date))
                .Include(e => e.User)
                .Select(e => new
                {
                    e.IdEvento,
                    e.Titulo,
                    e.Descripcion,
                    e.TipoEvento,
                    e.Color,
                    Empleado = e.User != null ? $"{e.User.Username} {e.User.Apellidos}" : null,
                    Dni = e.User != null ? e.User.Dni : null
                })
                .ToList();

            return Json(eventos);
        }

        // GET: /Calendario/BuscarEmpleados
        public JsonResult BuscarEmpleados(string termino)
        {
            if (string.IsNullOrWhiteSpace(termino))
                return Json(new List<object>());

            var empleados = _context.DbSetUser
                .Where(u => u.Username != null && u.Username.Contains(termino) || 
                           u.Apellidos != null && u.Apellidos.Contains(termino) || 
                           u.Dni != null && u.Dni.Contains(termino) ||
                           u.CargoLaboral != null && u.CargoLaboral.Contains(termino))
                .Take(10) // Máximo 10 resultados para el scroll
                .Select(u => new
                {
                    id = u.IdUser,
                    text = $"{u.Username} {u.Apellidos} - {u.Dni} - {u.CargoLaboral}",
                    nombre = u.Username,
                    apellidos = u.Apellidos,
                    dni = u.Dni,
                    cargo = u.CargoLaboral,
                    fechaNacimiento = u.FechaNacimiento.ToString("yyyy-MM-dd")
                })
                .ToList();

            return Json(empleados);
        }

        // POST: /Calendario/AgregarEvento
        [HttpPost]
        public async Task<IActionResult> AgregarEvento([FromBody] CalendarioEvento evento)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    evento.FechaCreacion = DateTime.Now;
                    
                    _context.DbSetCalendarioEvento.Add(evento);
                    await _context.SaveChangesAsync();

                    return Json(new { success = true, message = "Evento agregado correctamente", id = evento.IdEvento });
                }
                catch (Exception ex)
                {
                    return Json(new { success = false, message = $"Error al guardar: {ex.Message}" });
                }
            }

            return Json(new { success = false, message = "Datos del evento no válidos" });
        }
    }
}