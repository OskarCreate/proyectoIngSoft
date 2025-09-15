using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Threading.Tasks;

namespace proyectoIngSoft.Models
{
    [Table("t_registrar_descanso")]
    public class RegistrarDescanso
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [StringLength(8, ErrorMessage = "El DNI debe tener 8 dígitos", MinimumLength = 8)]
        public string DNIPaciente { get; set; }

        [Required]
        public DateTime FechaAtencion { get; set; }
        [NotNull]
        [Required]
        public string NombreDoctor { get; set; }
        [NotNull]
        [Required]
        public string CodigoAtencion { get; set; }
        [NotNull]
        [Required]
        public string RazonDescanso { get; set; }
    
       

       
    }
}