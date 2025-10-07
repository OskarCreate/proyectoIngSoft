using Microsoft.AspNetCore.Mvc;
<<<<<<< HEAD
using Microsoft.EntityFrameworkCore;
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;
using System.Linq;
using System.Security.Claims;
=======
using proyectoIngSoft.Data;
using proyectoIngSoft.Models;
using System.Linq;
>>>>>>> origin/main

namespace proyectoIngSoft.Controllers
{
    public class NotificationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public NotificationController(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< HEAD
        public IActionResult Index()
        {
            // Obtener el ID del usuario logueado (según Identity)
            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);

            // 🔹 Si el usuario no está logueado o no hay claim, mostramos todas (modo desarrollo)
            if (string.IsNullOrEmpty(userIdClaim))
            {
                var todas = _context.Notifications
                    .OrderByDescending(n => n.Fecha)
                    .ToList();

                ViewBag.NombreUsuario = "Modo Prueba (sin login)";
                return View("Index", todas);
            }

            // Buscar al usuario en T_Usuarios para obtener su IdUser
            var usuario = _context.DbSetUser
                .FirstOrDefault(u => u.Email == User.Identity.Name);

            if (usuario == null)
            {
                ViewBag.NombreUsuario = "Usuario no encontrado";
                return View("Index", new List<Notification>());
            }

            // 🔹 Cargar solo las notificaciones de este usuario
            var notificaciones = _context.Notifications
                .Where(n => n.UserId == usuario.IdUser.ToString())
                .OrderByDescending(n => n.Fecha)
                .ToList();

            ViewBag.NombreUsuario = $"{usuario.Username} {usuario.Apellidos}";

            return View("Index", notificaciones);
=======
        // 🔹 Lista todas las notificaciones del usuario actual (ejemplo con User.Identity.Name)
        public IActionResult Index()
        {
            var userId = User.Identity?.Name; // O usa Id real de Identity
            var notificaciones = _context.Notifications
                .Where(n => n.UserId == userId)
                .OrderByDescending(n => n.Fecha)
                .ToList();

            return View(notificaciones);
        }
        
        

        // 🔹 Detalles de una notificación
        public IActionResult Details(int id)
        {
            var notificacion = _context.Notifications.FirstOrDefault(n => n.Id == id);
            if (notificacion == null)
                return NotFound();

            return PartialView("_NotificationDetail", notificacion);
        }

        // 🔹 Crear (cuando admin envía notificación a un usuario)
        [HttpPost]
        public IActionResult Create(Notification model)
        {
            if (ModelState.IsValid)
            {
                model.Fecha = DateTime.Now;
                _context.Notifications.Add(model);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
>>>>>>> origin/main
        }
    }
}
