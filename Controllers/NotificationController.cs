using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using proyectoIngSoft.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoIngSoft.Controllers
{
    public class NotificationController : Controller
    {
        // 🔹 Simulación (luego reemplazas con EF y SQL)
        private static List<Notification> _notificaciones = new List<Notification>
        {
            new Notification { Id=1, UserId="juan", Titulo="Solicitud de incapacidad laboral", Mensaje="Incapacidad temporal por lesión en el trabajo", Fecha=DateTime.Now.AddMonths(-8), Estado="En Observación", Detalle="Solicitud enviada el 08 de enero de 2025", DocumentoAdjuntos = new List<string>{"certificado_medico.pdf", "reporte_accidente.pdf"} },
            new Notification { Id=2, UserId="juan", Titulo="Licencia de maternidad", Mensaje="Preparto y postparto", Fecha=DateTime.Now.AddMonths(-11), Estado="Aprobada" },
            new Notification { Id=3, UserId="juan", Titulo="Licencia de paternidad", Mensaje="Nacimiento de hijo", Fecha=DateTime.Now.AddMonths(-12), Estado="Rechazada" },
            new Notification { Id=4, UserId="juan", Titulo="Licencia por muerte de familiar directo", Mensaje="Duelo", Fecha=DateTime.Now.AddYears(-1), Estado="Aprobada" }
        };

        public IActionResult Index()
        {
            return View(_notificaciones);
        }

        public IActionResult Details(int id)
        {
            var notificacion = _notificaciones.FirstOrDefault(n => n.Id == id);
            if (notificacion == null)
                return NotFound();

            return PartialView("_NotificationDetail", notificacion);
        }
    }
}