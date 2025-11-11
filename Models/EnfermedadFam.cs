using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoIngSoft.Models
{
    [Table("t_EnfermedadFamiliar")]
    public class EnfermedadFam
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdEnfermedadFam { get; set; }
    
        [Required]
        public string NombreFamiliar { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaIni { get; set; }

        [Required]
        public DateOnly FechaFin { get; set; }

        [Required]
        public string Parentesco { get; set; } = string.Empty;

        [Required]
        public string CentroMedico { get; set; } = string.Empty;

        [Required]
        public string Medico { get; set; } = string.Empty;

        [Required]
        public string NumeroCMP { get; set; } = string.Empty;

        [Required]
        public DateOnly FechaDiag { get; set; }

        [Required]
        public int DiaSoli { get; set; }

        // ⚠ Nullable-safe: puede venir NULL desde la base de datos
        public string? CodigoEssalud { get; set; }
    }
}
