using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    public class DocumentoMedico
    {
        [Key]
        public int IdDocumento { get; set; }

        [Required]
        public int DescansoId { get; set; }

        public Descanso Descanso { get; set; }

        [Required]
        [StringLength(255)]
        public string Nombre { get; set; } = string.Empty;

        public long Tamaño { get; set; }

        public byte[] Archivo { get; set; }

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        // 🔹 Propiedad calculada: tamaño en KB
        [NotMapped]
        public string TamañoKB => (Tamaño / 1024.0).ToString("F2") + " KB";

        // 🔹 Propiedades auxiliares para control en UI o validación
        [NotMapped]
        public string Ruta { get; set; } = string.Empty;

        [NotMapped]
        public bool EstaDuplicado { get; set; } = false;

        [NotMapped]
        public bool EstaFaltante { get; set; } = false;
    }
}
