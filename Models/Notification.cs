using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    public class Notification
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public string Titulo { get; set; }
        public string Mensaje { get; set; }
        public string Estado { get; set; } // En Observación, Aprobada, Rechazada
        public DateTime Fecha { get; set; }

        // 🔹 Para detalle
        public string Detalle { get; set; }
        public List<string> DocumentoAdjuntos { get; set; } = new List<string>();
    }
}