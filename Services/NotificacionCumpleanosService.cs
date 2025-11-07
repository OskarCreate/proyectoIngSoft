using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;

namespace proyectoIngSoft.Services
{
    public class NotificacionCumpleanosService
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<NotificacionCumpleanosService> _logger;

        public NotificacionCumpleanosService(ApplicationDbContext context, ILogger<NotificacionCumpleanosService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task EnviarNotificacionesCumpleanos()
        {
            try
            {
                var hoy = DateTime.Today;
                
                // Buscar cumpleaños para hoy
                var cumpleanosHoy = await _context.DbSetCalendarioEvento
                    .Where(e => e.TipoEvento == "Cumpleaños" && 
                               e.FechaInicio.Date == hoy.Date)
                    .Include(e => e.User)
                    .ToListAsync();

                _logger.LogInformation($"Se encontraron {cumpleanosHoy.Count} cumpleaños para hoy");

                foreach (var evento in cumpleanosHoy)
                {
                    if (evento.User != null)
                    {
                        // Aquí puedes implementar el envío de notificaciones
                        // Por ejemplo: email, notificación push, etc.
                        _logger.LogInformation($"🎉 ¡Feliz cumpleaños a {evento.User.Username} {evento.User.Apellidos}! - {evento.Descripcion}");
                    }
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error al procesar notificaciones de cumpleaños");
                throw;
            }
        }
    }
}