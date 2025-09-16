using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    public class DocumentoMedico
    {
        public string Nombre { get; set; } = string.Empty;
        public long Tamaño { get; set; }
        public DateTime FechaSubida { get; set; } = DateTime.Now;
        public string TamañoKB => (Tamaño / 1024.0).ToString("F2") + " KB";
    }
}