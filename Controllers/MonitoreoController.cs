using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace proyectoIngSoft.Controllers
{
    public class MonitoreoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public MonitoreoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // ✅ INDEX (vista principal de monitoreo)
        public async Task<IActionResult> Index(string tipo, string busqueda)
        {
            IQueryable<Descanso> query = _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.TipoDescanso)
                .AsQueryable();

            // 🔹 Filtro por tipo de subsidio
            if (!string.IsNullOrEmpty(tipo) && tipo.ToLower() == "subsidio")
            {
                query = query.Where(d => d.EstadoSubsidioA == "Descanso Activo");
            }

            // 🔹 Filtro por búsqueda (nombre, apellidos, dni o correo)
            if (!string.IsNullOrEmpty(busqueda))
            {
                busqueda = busqueda.ToLower();
                query = query.Where(d =>
                    d.User.Username.ToLower().Contains(busqueda) ||
                    d.User.Apellidos.ToLower().Contains(busqueda) ||
                    d.User.Email.ToLower().Contains(busqueda) ||
                    d.User.Dni.ToLower().Contains(busqueda));
            }

            // 🔹 Mapeo a modelo para la vista
            var lista = await query
                .Select(d => new MonitoreoViewModel
                {
                    Nombre = d.User.Username + " " + d.User.Apellidos,
                    TipoSubsidio = d.TipoDescanso.Nombre,
                    FechaInicio = d.FechaIni,
                    FechaFin = d.FechaFin,
                    Dias = (int)(d.FechaFin - d.FechaIni).TotalDays + 1,
                    PagoPorDia = 85.5m,
                    Total = ((int)(d.FechaFin - d.FechaIni).TotalDays + 1) * 85.5m,
                    Estado = d.EstadoSubsidioJ
                })
                .OrderByDescending(x => x.FechaInicio)
                .ToListAsync();

            ViewBag.TipoSeleccionado = tipo;
            ViewBag.Busqueda = busqueda;

            return View(lista);
        }

        // ✅ NUEVA VISTA HU16 (para tu nueva historia de usuario)
        [HttpGet]
        public async Task<IActionResult> HU16()
        {
            // 🔹 Traer todos los descansos con relaciones necesarias
            var descansos = await _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.TipoDescanso)
                .OrderByDescending(d => d.FechaIni)
                .Select(d => new MonitoreoViewModel
                {
                    Nombre = d.User.Username + " " + d.User.Apellidos,
                    TipoSubsidio = d.TipoDescanso.Nombre,
                    FechaInicio = d.FechaIni,
                    FechaFin = d.FechaFin,
                    Dias = (int)(d.FechaFin - d.FechaIni).TotalDays + 1,
                    PagoPorDia = 85.5m,
                    Total = ((int)(d.FechaFin - d.FechaIni).TotalDays + 1) * 85.5m,
                    Estado = d.EstadoSubsidioJ
                })
                .ToListAsync();

            // Si no hay registros, se envía una lista vacía (evita NullReference)
            return View(descansos ?? new List<MonitoreoViewModel>());
        }

        // ✅ DETALLES de un descanso
        public async Task<IActionResult> Detalles(int id)
        {
            var descanso = await _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.DocumentosMedicos)
                .Include(d => d.TipoDescanso)
                .FirstOrDefaultAsync(d => d.IdDescanso == id);

            if (descanso == null)
                return NotFound();

            return View(descanso);
        }

        // ✅ VER DOCUMENTO MÉDICO (PDF)
        public async Task<IActionResult> VerDocumento(int id)
        {
            var documento = await _context.DocumentosMedicos
                .Include(d => d.Descanso)
                .FirstOrDefaultAsync(d => d.IdDocumento == id);

            if (documento == null || documento.Archivo == null)
                return NotFound();

            return File(documento.Archivo, "application/pdf", documento.Nombre);
        }
    }

    // ✅ VIEWMODEL PARA VISTA HU16 Y INDEX
    public class MonitoreoViewModel
    {
        public string Nombre { get; set; }
        public string TipoSubsidio { get; set; }
        public DateTime FechaInicio { get; set; }
        public DateTime FechaFin { get; set; }
        public int Dias { get; set; }
        public decimal PagoPorDia { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
    }
}
