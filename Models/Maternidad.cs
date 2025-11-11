using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace proyectoIngSoft.Models
{
    [Table("t_Maternidad")]
    public class Maternidad
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IdMater { get; set; }

        [Required]
        public DateOnly FechaParto { get; set; }

        [Required]
        public DateOnly FechaIni { get; set; }

        [Required]
        public DateOnly FechaFin { get; set; }

        [Required]
        public int SemanasGest { get; set; }

        [Required]
        public string PartoMult { get; set; }

        [Required]
        public DateOnly FechaUltM { get; set; }

        [Required]
        public string CentroMed { get; set; }

        [Required]
        public string MedicoT { get; set; }

        [Required]
        [Column("Descripcion")]
        public string Descripcion { get; set; }  // <<<<<< cerrada correctamente
    }
}
