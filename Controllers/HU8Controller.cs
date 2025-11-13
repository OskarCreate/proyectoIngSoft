using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;

namespace proyectoIngSoft.Controllers
{
    public class HU8Controller : Controller
    {
        private readonly ApplicationDbContext _context;

        public HU8Controller(ApplicationDbContext context)
        {
            _context = context;
        }

        // Vista principal con lista de descansos médicos
        public async Task<IActionResult> IndexHu()
        {
            var descansos = await _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.TipoDescanso)
                .Include(d => d.Enfermedad)
                .Include(d => d.Accidente)
                .Include(d => d.Maternidad)
                .Include(d => d.Paternidad)
                .Include(d => d.Fallecimiento)
                .Include(d => d.EnfermedadFam)
                .ToListAsync();

            return View(descansos);
        }

        // Acción para obtener los detalles de un descanso (modal)
        public async Task<IActionResult> DetalleDescanso(int id)
        {
            var descanso = await _context.DbSetDescanso
                .Include(d => d.User)
                .Include(d => d.TipoDescanso)
                .Include(d => d.Enfermedad)
                .Include(d => d.Accidente)
                .Include(d => d.Maternidad)
                .Include(d => d.Paternidad)
                .Include(d => d.Fallecimiento)
                .Include(d => d.EnfermedadFam)
                .FirstOrDefaultAsync(d => d.IdDescanso == id);

            if (descanso == null) return NotFound();

             return PartialView("~/Views/Lista/DetalleDescansoModal.cshtml", descanso);
        }
    }
}
