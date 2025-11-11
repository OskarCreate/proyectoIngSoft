using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoIngSoft.Models
{
    [Table("t_Enfermedad")]
    public class Enfermedad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnfermedad { get; set; }
       
        [Required]
        public string SubtipoSol { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaIni { get; set; }

        [Required]
        public DateOnly FechaFin { get; set; }

        [Required]
        public string NombreMedi { get; set; } = string.Empty;

        [Required]
        public string CentroMedico { get; set; } = string.Empty;

        [Required]
        public int DiasDesc { get; set; }

        [Required]
        public string Diagnostico { get; set; } = string.Empty;

        [Required]
        public string DescEnfe { get; set; } = string.Empty;

        // ⚠ Nullable-safe: puede ser null en la base de datos
        public string? CodigoEssalud { get; set; }
    }
}
