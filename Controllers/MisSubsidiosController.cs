using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using proyectoIngSoft.Data;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using System.IO;
using PdfSharpCore.Pdf;
using PdfSharpCore.Drawing;

namespace proyectoIngSoft.Controllers
{
    public class MisSubsidiosController : Controller
    {
        
        private readonly ApplicationDbContext _context;

        public MisSubsidiosController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: /MisSubsidios/Index
        public async Task<IActionResult> Index(int? idUser)
        {
            // Simulación: si no viene el idUser, usar uno de ejemplo (en tu app real sería el logueado)
            int usuarioId = idUser ?? 1;

            var subsidios = await _context.DbSetDescanso
                .Include(d => d.TipoDescanso)
                .Include(d => d.User)
                .Where(d => d.UserId == usuarioId)
                .ToListAsync();

            // Calcular días, pago diario y total
            decimal pagoPorDia = 78.25m;
            var subsidiosData = subsidios.Select(d => new
            {
                Tipo = d.TipoDescanso?.Nombre ?? "N/A",
                FechaInicio = d.FechaIni,
                FechaFin = d.FechaFin,
                Dias = (d.FechaFin - d.FechaIni).Days,
                PagoPorDia = pagoPorDia,
                Total = (decimal)((d.FechaFin - d.FechaIni).Days) * pagoPorDia,
                Estado = d.EstadoSubsidioA
            }).ToList();

            decimal totalCobrar = subsidiosData.Sum(s => s.Total);
            ViewBag.Trabajador = subsidios.FirstOrDefault()?.User?.Username ?? "Empleado";
            ViewBag.Dni = subsidios.FirstOrDefault()?.User?.Dni ?? "00000000";
            ViewBag.TotalCobrar = totalCobrar;
            ViewBag.UltimaActualizacion = DateTime.Now.ToString("dd/MM/yyyy, h:mm:ss tt");
            ViewBag.Subsidios = subsidiosData;

            return View();
        }

        // POST: /MisSubsidios/ExportarPDF
        [HttpPost]
        public IActionResult ExportarPDF(int? idUser)
        {
            int usuarioId = idUser ?? 1;

            var subsidios = _context.DbSetDescanso
                .Include(d => d.TipoDescanso)
                .Include(d => d.User)
                .Where(d => d.UserId == usuarioId)
                .ToList();

            decimal pagoPorDia = 78.25m;
            decimal totalCobrar = 0;

            using var stream = new MemoryStream();
            var document = new PdfDocument();
            var page = document.AddPage();
            var gfx = XGraphics.FromPdfPage(page);

            var fontTitle = new XFont("Arial", 16, XFontStyle.Bold);
            var font = new XFont("Arial", 10, XFontStyle.Regular);

            int y = 40;
            gfx.DrawString("Reporte de Subsidios del Trabajador", fontTitle, XBrushes.Black,
                new XRect(0, y, page.Width, page.Height), XStringFormats.TopCenter);
            y += 40;

            foreach (var s in subsidios)
            {
                int dias = (s.FechaFin - s.FechaIni).Days;
                decimal total = dias * pagoPorDia;
                totalCobrar += total;

                string text = $"{s.TipoDescanso?.Nombre} | {s.FechaIni:dd/MM/yyyy} - {s.FechaFin:dd/MM/yyyy} | Días: {dias} | Total: S/ {total:F2}";
                gfx.DrawString(text, font, XBrushes.Black, new XRect(40, y, page.Width - 80, page.Height), XStringFormats.TopLeft);
                y += 18;
            }

            y += 20;
            gfx.DrawString($"Total a Cobrar: S/ {totalCobrar:F2}", fontTitle, XBrushes.DarkBlue, new XRect(40, y, page.Width - 80, page.Height), XStringFormats.TopLeft);

            document.Save(stream, false);
            return File(stream.ToArray(), "application/pdf", "MisSubsidios.pdf");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}