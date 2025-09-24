using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    [Table("t_DocumentoMedico")]
    public class DocumentoMedico
    {
        [Key]
        public int IdArchivo { get; set; }

        public string Nombre { get; set; } = string.Empty;
        public long Tamaño { get; set; }
        public DateTime FechaSubida { get; set; } = DateTime.Now;
        public byte[] Archivo { get; set; }

        public int DescansoId { get; set; }
        public Descanso Descanso { get; set; }

        public string TamañoKB => (Tamaño / 1024.0).ToString("F2") + " KB";

    }
}