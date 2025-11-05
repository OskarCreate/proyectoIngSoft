using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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
        public string Nombre { get; set; } = string.Empty;

        public long Tamaño { get; set; } 
        public byte[] Archivo { get; set; }

        public DateTime FechaSubida { get; set; } = DateTime.Now;

        [NotMapped]
        public string TamañoKB => (Tamaño / 1024.0).ToString("F2") + " KB";

        [NotMapped]
        public string Ruta { get; set; } = string.Empty;

        [NotMapped]
        public bool EstaDuplicado { get; set; } = false;

        [NotMapped]
        public bool EstaFaltante { get; set; } = false;
    }
}
